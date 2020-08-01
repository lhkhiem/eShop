using eShop.Application.Catalog.Products.Dtos;
using eShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PagedViewModel<ProductViewModel> GetAllByCategory(int categoryId, int pageIndex, int pageSize);
    }
}
