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
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using Microsoft.Extensions.Hosting;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.EntityFrameworkCore.Metadata;

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

            if (result == null)
            {
                throw new ArgumentException("Invalid product identifier.");
            }

            return result;
        }

        public async Task<PagedProductDto> GetAllAsync(GetAllQueryModel query, string productType, QueryFilterModel? filter)
        {
            Expression<Func<Product, bool>> filterExpr = BuildFilterExpr(query.Category, query.OrderBy);

            var productPage = await CreateAndValidateProductPage(query, productType, filterExpr);

            await FetchAndFilterProducts(query, filterExpr, productPage, filter);

            return productPage;
        }



        private Expression<Func<Product, bool>> BuildFilterExpr(string? category, string orderBy)
        {
            if (string.IsNullOrEmpty(category))
            {
                if (orderBy == "Discount")
                {
                    return p => p.IsActive && p.DiscountId != null;
                }

                return p => p.IsActive;
            }

            if (orderBy == "Discount")
            {
                return p => p.IsActive && p.Category.Name.ToLower() == category && p.DiscountId != null;
            }

            return p => p.IsActive && p.Category.Name.ToLower() == category;
        }

        private async Task<PagedProductDto> CreateAndValidateProductPage(GetAllQueryModel query, string productType, Expression<Func<Product, bool>> filterExpr)
        {
            var productPage = await repo
                 .AllReadonly<ProductType>(p => p.Name.ToLower() == productType.ToLower())
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

        private async Task FetchAndFilterProducts(GetAllQueryModel query, Expression<Func<Product, bool>> filterExpr, PagedProductDto productPage, QueryFilterModel filterArgs)
        {
            var products = repo.AllReadonly<Product>(p => p.TypeId == productPage.ProductTypeId).Where(filterExpr);

            products = SortData(products, query.OrderBy, query.Desc);
            int skipCount = (query.Page - 1) * query.ItemsPerPage;

            productPage.Products = await products
                .Include(p => p.Discount)
                 .Where(BuildExpr(filterArgs))
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
                     IsInStock = p.IsInStock,
                     NewPrice = p.DiscountedPrice,
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

        private IQueryable<Product> SortData(IQueryable<Product> data, string orderBy, bool isDesc)
        {
            if (isDesc)
            {
                return orderBy switch
                {
                    "Discount" => data.OrderByDescending(p => p.Discount!.DiscountPercent),
                    "Name" => data.OrderByDescending(p => p.Name),
                    "Make" => data.OrderByDescending(p => p.Make.Name),
                    _ => data.OrderByDescending(p => p.DiscountId == null ? p.Price : (p.Price * (100 - p.Discount!.DiscountPercent) / 100)),
                };
            }
            else
            {
                return orderBy switch
                {                   
                    "Discount" => data.OrderBy(p => p.Discount!.DiscountPercent),
                    "Name" => data.OrderBy(p => p.Name),
                    "Make" => data.OrderBy(p => p.Make.Name),
                    _ => data.OrderBy(p => p.DiscountId == null ? p.Price : (p.Price * (100 - p.Discount!.DiscountPercent) / 100)),
                };
            }
        }

        private Expression<Func<Product, bool>> BuildExpr(QueryFilterModel filterArgs)
        {
            var param = Expression.Parameter(typeof(Product), "p");

            BinaryExpression? exprBody = null;

            if (filterArgs.InStock != null) //p => p.Items.Any(i => i.InStock > 0);
            {
                var prop = Expression.Property(param, nameof(Product.Items));
                var anyMethod = typeof(Enumerable).GetMethods()
                               .Single(m => m.Name == "Any" && m.GetParameters().Length == 2)
                               .MakeGenericMethod(typeof(Item));

                var itemParam = Expression.Parameter(typeof(Item), "i");
                var itemProp = Expression.Property(itemParam, nameof(Item.InStock));
                var itemConst = Expression.Constant(0);
                var itemExpr = Expression.GreaterThan(itemProp, itemConst);
                var itemLambda = Expression.Lambda<Func<Item, bool>>(itemExpr, itemParam);

                var anyCall = Expression.Call(anyMethod, prop, itemLambda);                
                var value = Expression.Constant(filterArgs.InStock);

                exprBody = Expression.Equal(anyCall, value);
            }

            if (filterArgs.Makes != null)
            {
                var splitMakes = filterArgs.Makes.Split(", ");
                var prop = Expression.Property(param, nameof(Product.MakeId));

                BinaryExpression? makesExpr = null;

                for (var i = 0; i < splitMakes.Length; i++)
                {
                    var value = Expression.Constant(Guid.Parse(splitMakes[i]));
                    var expr = Expression.Equal(prop, value);

                    if (i == 0)
                    {
                        makesExpr = expr;
                        continue;
                    }

                    makesExpr = Expression.OrElse(makesExpr!, expr);
                }

                exprBody = exprBody == null ? makesExpr : Expression.AndAlso(exprBody, makesExpr!);
            }

            if (filterArgs.MinPrice != null || filterArgs.MaxPrice != null)
            {
                var prop = Expression.Property(param, nameof(Product.Price));
                var minPrice = filterArgs.MinPrice == null ? Expression.Constant(0, typeof(decimal)) : Expression.Constant(filterArgs.MinPrice);
                var maxPrice = filterArgs.MaxPrice == null ? Expression.Constant(decimal.MaxValue) : Expression.Constant(filterArgs.MaxPrice);

                BinaryExpression priceExpr = Expression.AndAlso(Expression.GreaterThanOrEqual(prop, minPrice), Expression.LessThanOrEqual(prop, maxPrice));

                exprBody = exprBody == null ? priceExpr : Expression.AndAlso(exprBody, priceExpr);
            }

            if (filterArgs.Attributes != null) //p => p.AttributeValues.Any(av => attrValuesArr.Contains(av.Value))
            {
                var attrValuesArr = filterArgs.Attributes.Split(", ").AsQueryable();
                var prop = Expression.Property(param, nameof(Product.AttributeValues));
                var anyMethod = typeof(Enumerable).GetMethods()
                               .Single(m => m.Name == "Any" && m.GetParameters().Length == 2)
                               .MakeGenericMethod(typeof(ProductAttributeValue));

                var attrParam = Expression.Parameter(typeof(ProductAttributeValue), "pa");
                var attrProp = Expression.Property(attrParam, nameof(ProductAttributeValue.Value));
                var attrConst = Expression.Constant(attrValuesArr);
                var containsMethod = typeof(Enumerable).GetMethods()
                    .Where(m => m.Name == "Contains" && m.GetParameters().Length == 2)
                    .Single()
                    .MakeGenericMethod(typeof(string));

                var containsCall = Expression.Call(containsMethod!, attrConst, attrProp);
                var containLambda = Expression.Lambda<Func<ProductAttributeValue, bool>>(containsCall, attrParam);

                var anyCall = Expression.Call(anyMethod, prop, containLambda);

                if (exprBody == null)
                {
                    return Expression.Lambda<Func<Product, bool>>(anyCall, param);
                }

                exprBody = Expression.AndAlso(exprBody, anyCall);
            }

            return exprBody == null 
                ? Expression.Lambda<Func<Product, bool>>(Expression.Constant(true), param) 
                : Expression.Lambda<Func<Product, bool>>(exprBody, param);
        }


    }
}
