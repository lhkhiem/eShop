using eShop.ViewModels.Catalog.Products;
using eShop.ViewModels.Catalog.Products.Public;
using eShop.ViewModels.Common;
using System.Threading.Tasks;

namespace eShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllCategoryId(GetProductPagingRequest request);
    }
}
