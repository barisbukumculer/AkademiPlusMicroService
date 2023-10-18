using AkademiPlusMicroService.Shared.DTOs;
using AkademiPlusMicroService.WebUI.DTOs.CategoryDTOs;

namespace AkademiPlusMicroService.WebUI.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDTO>>> GetAllCategories();
        Task<Response<ResultCategoryDTO>> GetByIdCategory(string id);
        Task<Response<NoContent>> CreateCategory(CreateCategoryDTO createCategoryDTO);
        Task<Response<NoContent>> UpdateCategory(UpdateCategoryDTO updateCategoryDTO);
        Task<Response<NoContent>> DeleteCategory(string id);
    }
}
