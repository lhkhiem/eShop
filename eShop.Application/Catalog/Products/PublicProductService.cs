﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eShop.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShop.ViewModels.Catalog.Products;
using eShop.ViewModels.Common;
using eShop.ViewModels.Catalog.Products.Public;

namespace eShop.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllCategoryId(GetProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
                query = query.Where(x=>x.pic.CategoryId==request.CategoryId);
            //3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //4. Select and projection
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;
        }
    }
}