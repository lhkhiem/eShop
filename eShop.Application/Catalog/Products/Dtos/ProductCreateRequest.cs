using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Application.Catalog.Products.Dtos
{
    public class ProductCreateRequest
    {
        public string Name { set; get; }
        public decimal Price { set; get; }
    }
}
