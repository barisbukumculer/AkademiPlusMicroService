using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Catalog.Models;
using AkademiPlusMicroService.Catalog.Settings;
using AkademiPlusMicroService.Shared.DTOs;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiPlusMicroService.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
           var value=_mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(value);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteCategory(string id)
        {
            var values = await _categoryCollection.DeleteOneAsync(x=>x.CategoryId==id);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultCategoryDTO>>> GetAllCategories()
        {
            var values=await _categoryCollection.Find(x=> true ).ToListAsync();
            return Response<List<ResultCategoryDTO>>.Success(_mapper.Map<List<ResultCategoryDTO>>(values), 200);
        }

        public async Task<Response<ResultCategoryDTO>> GetByIdCategory(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();
           if(values == null)
            {
                return Response<ResultCategoryDTO>.Fail("Kategori Bulunamadı", 404);
            }
            else
            {
                return Response<ResultCategoryDTO>.Success(_mapper.Map<ResultCategoryDTO>(values), 200);
            }
        }

        public async Task<Response<NoContent>> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var values=  _mapper.Map<Category>(updateCategoryDTO);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDTO.CategoryId, values);

            if(result == null)
            {
                return Response<NoContent>.Fail("Kategori Bulunamadı", 404);
            }
            return Response<NoContent>.Success(204);
        }
    }
}
