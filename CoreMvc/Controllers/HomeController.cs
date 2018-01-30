using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}