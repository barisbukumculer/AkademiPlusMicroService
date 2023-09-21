using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Catalog.DTOs.ProductDTOs;
using AkademiPlusMicroService.Catalog.Models;
using AkademiPlusMicroService.Catalog.Settings;
using AkademiPlusMicroService.Shared.DTOs;
using AutoMapper;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace AkademiPlusMicroService.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;

		public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
		{
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}

		public async Task<Response<NoContent>> CreateProduct(CreateProductDTO createProductDTO)
        {
            var values=_mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteProduct(string id)
        {
          await _productCollection.DeleteOneAsync(x => x.ProductId == id);
			return Response<NoContent>.Success(204);
		}

        public async Task<Response<List<ResultProductDTO>>> GetAllProducts()
		{
			var values = await _productCollection.Find(x => true).ToListAsync();
			return Response<List<ResultProductDTO>>.Success(_mapper.Map<List<ResultProductDTO>>(values), 200);
		}

        public async Task<Response<ResultProductDTO>> GetByIdProduct(string id)
        {
			var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
			if (values == null)
			{
				return Response<ResultProductDTO>.Fail("Kategori Bulunamadı", 404);
			}
			else
			{
				return Response<ResultProductDTO>.Success(_mapper.Map<ResultProductDTO>(values), 200);
			}
		}

        public async Task<Response<NoContent>> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
			var values=_mapper.Map<Product>(updateProductDTO);
			await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDTO.ProductId, values);
			return Response<NoContent>.Success(200);
		}
    }
}
