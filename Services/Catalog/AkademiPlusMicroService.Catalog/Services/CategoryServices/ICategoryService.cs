using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Shared.DTOs;

namespace AkademiPlusMicroService.Catalog.Services.CategoryServices
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
