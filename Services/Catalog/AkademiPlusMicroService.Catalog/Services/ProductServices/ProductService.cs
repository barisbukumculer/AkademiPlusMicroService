using AkademiPlusMicroService.Catalog.DTOs.ProductDTOs;
using AkademiPlusMicroService.Shared.DTOs;

namespace AkademiPlusMicroService.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
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
