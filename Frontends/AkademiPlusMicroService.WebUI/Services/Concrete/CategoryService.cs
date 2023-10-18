using AkademiPlusMicroService.Shared.DTOs;
using AkademiPlusMicroService.WebUI.DTOs.CategoryDTOs;
using AkademiPlusMicroService.WebUI.Services.Abstract;
using Newtonsoft.Json;

namespace AkademiPlusMicroService.WebUI.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClient;

        public CategoryService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Response<NoContent>> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteCategory(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<ResultCategoryDTO>>> GetAllCategories()
        {
            var client = _httpClient.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5011/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<Response<List<ResultCategoryDTO>>>(jsonData);
            return values;
        }

        public Task<Response<ResultCategoryDTO>> GetByIdCategory(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
