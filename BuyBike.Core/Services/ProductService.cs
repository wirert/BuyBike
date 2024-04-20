namespace BuyBike.Core.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Constants;
    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Core.Models.Manufacturer;
    using BuyBike.Infrastructure.Data.Utils;

    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ProductDetailsDto> GetById(Guid id)
        {
            var result = await repo.AllReadonly<Product>(b => b.IsActive && b.Id == id)
                .Select(b => new ProductDetailsDto
                {
                    Name = b.Name,
                    Make = b.Make.Name,
                    MakeLogoUrl = AppConstants.MinIo_EndPoint + b.Make.LogoUrl,
                    ImageUrl = AppConstants.MinIo_EndPoint + b.ImageUrl,
                    Price = b.Price,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                    Color = b.Color,
                    Category = b.Category.Name,
                    Gender = b.Gender,
                    Description = b.Description,
                    Items = b.Items.Select(i => new ItemDto
                    {
                        Id = i.Id,
                        Size = i.Size.ToString()!,
                        Sku = i.Sku,
                        IsInStock = i.InStock > 0
                    }),
                    Specification = b.Specification,
                    Attributes = b.AttributeValues.Select(av => new ProductAttributeDto()
                    {
                        Name = av.Attribute.Name,
                        Value = av.Value,
                    })
                }).FirstOrDefaultAsync();

            return result == null 
                ? throw new ArgumentException("Invalid product identifier.") 
                : result;
        }

        public async Task<PagedProductDto> GetAllAsync(AllProductQueryModel queryArgs)
        {
            Expression<Func<Product, bool>> filterExpr = BuildFilterExpr(queryArgs);

            var productPage = await CreateAndValidateProductPage(queryArgs, filterExpr);

            await FetchAndFilterProducts(queryArgs, filterExpr, productPage);

            return productPage;
        }

        private Expression<Func<Product, bool>> BuildFilterExpr(AllProductQueryModel queryArgs)
        {     
            Expression<Func<Product, bool>> exprBody = PredicateBuilder.True<Product>();

            exprBody = exprBody.And(p => (p.DiscountId == null ? p.Price : (p.Price * (100 - p.Discount!.DiscountPercent) / 100)) >= queryArgs.MinPrice);
            exprBody = exprBody.And(p => (p.DiscountId == null ? p.Price : (p.Price * (100 - p.Discount!.DiscountPercent) / 100)) <= queryArgs.MaxPrice);

            if(queryArgs.OrderBy == "Discount")
            {
                exprBody = string.IsNullOrEmpty(queryArgs.Category)
                    ? exprBody.And(p => p.DiscountId != null)
                    : exprBody.And(p => p.Category.Name.ToLower() == queryArgs.Category && p.DiscountId != null);
            }
            else
            {
                if(string.IsNullOrEmpty(queryArgs.Category) == false)
                {
                    exprBody = exprBody.And(p => p.Category.Name.ToLower() == queryArgs.Category);
                }
            }

            if(queryArgs.InStock != null)
            {
                exprBody = exprBody.And(p => p.Items.Any(i => i.InStock > 0));
            }

            if (string.IsNullOrWhiteSpace( queryArgs.Makes) == false)
            {
                var splitMakes = queryArgs.Makes.Split(", ");

                exprBody = exprBody.And(p => splitMakes.Contains(p.MakeId.ToString()));
            }

            if(string.IsNullOrWhiteSpace(queryArgs.Attributes) == false)
            {
                var attrValuesArr = queryArgs.Attributes.Split(", ");

                exprBody = exprBody.And(p => p.AttributeValues.Any(av => attrValuesArr.Contains(av.Value)));
            }

            return exprBody;
        }

        private async Task<PagedProductDto> CreateAndValidateProductPage(AllProductQueryModel query, Expression<Func<Product, bool>> filterExpr)
        {
            var productPage = await repo
                 .AllReadonly<ProductType>(p => p.Name.ToLower() == query.ProductType.ToLower())
                 .Select(t => new PagedProductDto()
                 {
                     ProductTypeId = t.Id,
                     CategoryImageUrl = t.ImageUrl == null ? "" : AppConstants.MinIo_EndPoint + t.ImageUrl,
                     Attributes = t.Properties.Select(p => new AttributeValuesDto()
                     {
                         Id = p.Id,
                         Name = p.Name,
                         Values = new HashSet<string>()
                     }).ToList()
                 }).FirstOrDefaultAsync();

            var productCount = await repo.AllReadonly<Product>(p => p.TypeId == productPage!.ProductTypeId).CountAsync(filterExpr);

            int skipCount = (query.Page - 1) * query.ItemsPerPage;

            if (productPage == null || productCount == 0)
            {
                throw new FileNotFoundException("Няма намерени продукти.");
            }

            if (productCount <= skipCount)
            {
                throw new ArgumentException("Невалиден номер на страница.");
            }

            if (query.ItemsPerPage > productCount)
            {
                query.ItemsPerPage = productCount;
            }

            productPage!.TotalProducts = productCount;

            return productPage;
        }

        private IQueryable<Product> SortData(IQueryable<Product> data, string orderBy, bool isDesc)
        {
            if (isDesc)
            {
                return orderBy switch
                {
                    "Discount" => data.OrderByDescending(p => p.Discount!.DiscountPercent),
                    "Name" => data.OrderByDescending(p => p.Name),
                    "Make" => data.OrderByDescending(p => p.Make.Name),
                    _ => data.OrderByDescending(ProductExtention.GetDiscountedPrice()),
                };
            }
            else
            {
                return orderBy switch
                {
                    "Discount" => data.OrderBy(p => p.Discount!.DiscountPercent),
                    "Name" => data.OrderBy(p => p.Name),
                    "Make" => data.OrderBy(p => p.Make.Name),
                    _ => data.OrderBy(ProductExtention.GetDiscountedPrice()),
                };
            }
        }

        private async Task FetchAndFilterProducts(AllProductQueryModel query, Expression<Func<Product, bool>> filterExpr, PagedProductDto productPage)
        {
            var products = repo.AllReadonly<Product>(p => p.TypeId == productPage.ProductTypeId).Where(filterExpr);

            products = SortData(products, query.OrderBy, query.Desc);

            int skipCount = (query.Page - 1) * query.ItemsPerPage;

            productPage.Products = await products  
                 .Include(p => p.Discount)
                 .Skip(skipCount)
                 .Take(query.ItemsPerPage)
                 .Select(p => new ProductDto
                 {
                     Id = p.Id,
                     Name = $"{p.Category.Name} {p.Make.Name} {p.Name} {p.Color ?? string.Empty}",
                     Make = new ManufacutrerDto()
                     {
                         Id = p.Make.Id,
                         Name = p.Make.Name,
                         ImageUrl = AppConstants.MinIo_EndPoint + p.Make.LogoUrl,
                     },
                     ImageUrl = AppConstants.MinIo_EndPoint + p.ImageUrl,
                     Price = p.Price,
                     Color = p.Color,
                     Category = p.Category.Name,
                     DiscountPercent = p.Discount != null ? p.Discount.DiscountPercent : null,
                     IsInStock = p.Items.Any(i => i.InStock > 0),
                     NewPrice = p.GetDiscountedPrice(),
                     Properties = p.AttributeValues.Select(av => new ProductAttributeDto()
                     {
                         Name = av.Attribute.Name,
                         Value = av.Value,
                     })
                 })
                 .ToListAsync();

            var allAttrValues = productPage.Products.SelectMany(p => p.Properties).ToList();

            foreach (var productAttr in allAttrValues)
            {
                var attr = productPage.Attributes.FirstOrDefault(p => p.Name == productAttr.Name);
                if (attr != null)
                {
                    attr.Values.Add(productAttr.Value);
                }
            }
        }
    }
}
