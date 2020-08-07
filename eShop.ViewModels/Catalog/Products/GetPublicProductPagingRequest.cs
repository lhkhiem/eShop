using eShop.ViewModels.Common;

namespace eShop.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string languageId { set; get; }
        public int? CategoryId { get; set; }
    }
}