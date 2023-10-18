using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		[HttpGet]
		public async Task<IActionResult> GetCategoryList()
		{
			var values= await _categoryService.GetAllCategories();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
		{
			await _categoryService.CreateCategory(createCategoryDTO);
			return Ok("Kategori Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteCategory(id);
			return Ok("Kategori Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
		{
			await _categoryService.UpdateCategory(updateCategoryDTO);
			return Ok("Güncelleme Yapıldı");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(string id)
		{
			var values=await _categoryService.GetByIdCategory(id);
			return Ok(values);
		}
	}
}
