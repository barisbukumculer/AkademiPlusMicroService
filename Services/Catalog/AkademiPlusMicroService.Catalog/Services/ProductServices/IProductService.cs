using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Catalog.DTOs.ProductDTOs;
using AkademiPlusMicroService.Shared.DTOs;

namespace AkademiPlusMicroService.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDTO>>> GetAllProducts();
        Task<Response<ResultProductDTO>> GetByIdProduct(string id);
        Task<Response<NoContent>> CreateProduct(CreateProductDTO createProductDTO);
        Task<Response<NoContent>> UpdateProduct(UpdateProductDTO updateProductDTO);
        Task<Response<NoContent>> DeleteProduct(string id);
    }
}
