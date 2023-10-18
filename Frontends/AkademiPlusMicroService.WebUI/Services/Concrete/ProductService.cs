using AkademiPlusMicroService.Shared.DTOs;
using AkademiPlusMicroService.WebUI.DTOs.ProductDTOs;
using AkademiPlusMicroService.WebUI.Services.Abstract;

namespace AkademiPlusMicroService.WebUI.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Response<NoContent>> CreateProduct(CreateProductDTO createProductDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultProductDTO>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultProductDTO>> GetByIdProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            throw new NotImplementedException();
        }
    }
}
