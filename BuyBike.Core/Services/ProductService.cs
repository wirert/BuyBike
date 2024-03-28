namespace BuyBike.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using BuyBike.Core.Models;
    using BuyBike.Core.Services.Contracts;
    using BuyBike.Infrastructure.Contracts;
    using BuyBike.Infrastructure.Data.Entities;
    using BuyBike.Infrastructure.Data.Entities.Enumerations;

    /// <summary>
    /// Product Service
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private const string ImgBaseUrl = @"http://localhost:9000/buy-bike/";

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ICollection<ProductDto>> GetAllModelsAsync(BikeType? bikeType)
        {
            Expression<Func<Product, bool>> searchTerms = b => b.IsActive;

            if (bikeType != null)
            {
                searchTerms = b => b.IsActive && b.Category.Name == bikeType.ToString();
            }

            return await repo.AllReadonly(searchTerms)
                .Select(b => new ProductDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Make = b.Make.Name,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    Price = b.Price,
                    Color = b.Color,
                    Type = b.Category.Name,
                    TyreSize = 28

                }).ToListAsync();
        }

        public async Task<ProductDetailsDto> GetById(Guid id)
        {            
            var result =  await repo.AllReadonly<Product>(b => b.IsActive && b.Id == id)
                .Select(b => new ProductDetailsDto
                {
                    Name = b.Name,
                    Make = b.Make.Name,
                    MakeLogoUrl = ImgBaseUrl + b.Make.LogoUrl,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    Price = b.Price,
                    DiscountPercent = b.Discount != null ? b.Discount.DiscountPercent : null,
                    Color = b.Color,
                    Type = b.Category.Name,
                    Gender = b.Gender,
                    Description = b.Description,
                    Items = b.Items.Select(i => new ItemDto 
                    { 
                        Id = i.Id,
                        Size = i.Size.ToString()!,
                        Sku = i.Sku,
                        IsInStock = i.InStock > 0
                    }),
                    Attributes = b.AttributeValues.Select(av => new AttributeDto
                    {
                        Name = av.Attribute.Name,
                        Value = av.Value
                    })
                } ).FirstOrDefaultAsync();


            if (result == null)
            {
                throw new ArgumentException("Invalid bicycle identifier.");
            }

           var tyreSize = result.Attributes?.FirstOrDefault(a => a.Name == "TyreSize")?.Value;

            if (tyreSize != null)
            {
                result.TyreSize = double.Parse(tyreSize);
            }

            return result;
        }

        public async Task<PagedProductsDto> GetPagedModelsAsync(int page, int pageSize, string orderBy, bool isDesc, BikeType? bikeType)
        {
            int skipCount = (page - 1) * pageSize;

            if (skipCount < 0)
            {
                throw new ArgumentException("Incorrect page number or page size.");
            }

            Expression<Func<Product, bool>> searchTerms = b => b.IsActive;

            if (bikeType != null)
            {
                searchTerms = b => b.IsActive && b.Category.Name == bikeType.ToString();
            }

            int totalCount = await repo.AllReadonly(searchTerms).CountAsync();

            if (totalCount <= skipCount)
            {
                throw new ArgumentException("Incorrect page number.");
            }

            if (pageSize > totalCount)
            {
                pageSize = totalCount;
            }

            var data = repo.AllReadonly(searchTerms)
                .Select(b => new ProductDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Make = b.Make.Name,
                    ImageUrl = ImgBaseUrl + b.ImageUrl,
                    Price = b.Price,
                    Color = b.Color,
                    Type = b.Category.Name,

                }).AsQueryable();

            var result = new PagedProductsDto()
            {
                TotalProducts = totalCount,
                Products = await SortAndFetchData(data, orderBy, isDesc, skipCount, pageSize)
            };

            return result;
        }

        private async Task<ICollection<ProductDto>> SortAndFetchData(IQueryable<ProductDto> data, string orderBy, bool isDesc, int skipCount, int pageSize)
        {
            orderBy = orderBy.ToLower();

            if (isDesc)
            {
                if (orderBy == "price")
                    return await data
                        .OrderByDescending(m => m.Price)
                        .Skip(skipCount)
                        .Take(pageSize)
                        .ToListAsync();
                else if (orderBy == "manufacturer")
                    return await data
                       .OrderByDescending(m => m.Make)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();

                else if (orderBy == "name")
                    return await data
                       .OrderByDescending(m => m.Name)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();

                else
                    return await data
                    .OrderByDescending(m => m)
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();

            }
            else
            {
                if (orderBy == "price")
                    return await data
                        .OrderBy(m => m.Price)
                        .Skip(skipCount)
                        .Take(pageSize)
                        .ToListAsync();
                else if (orderBy == "manufacturer")
                    return await data
                       .OrderBy(m => m.Make)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();
                else if (orderBy == "name")
                    return await data
                       .OrderBy(m => m.Name)
                       .Skip(skipCount)
                       .Take(pageSize)
                       .ToListAsync();
                else
                    return await data
                    .OrderBy(m => m)
                    .Skip(skipCount)
                    .Take(pageSize)
                    .ToListAsync();
            }
        }
    }
}
