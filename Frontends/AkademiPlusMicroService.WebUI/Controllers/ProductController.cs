using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
