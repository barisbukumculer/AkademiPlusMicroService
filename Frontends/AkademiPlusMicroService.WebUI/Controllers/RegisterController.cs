using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
