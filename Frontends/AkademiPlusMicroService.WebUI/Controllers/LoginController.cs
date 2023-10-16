using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
