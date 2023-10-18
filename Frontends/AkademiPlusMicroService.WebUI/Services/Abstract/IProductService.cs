using AkademiPlusMicroService.Shared.DTOs;
using AkademiPlusMicroService.WebUI.DTOs.ProductDTOs;

namespace AkademiPlusMicroService.WebUI.Services.Abstract
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
