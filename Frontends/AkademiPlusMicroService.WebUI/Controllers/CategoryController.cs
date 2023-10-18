using AkademiPlusMicroService.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.WebUI.Controllers
{
    public class CategoryController : Controller
    { private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task< IActionResult> Index()
        {
            var values=await _categoryService.GetAllCategories();
            return View(values);
        }
    }
}
