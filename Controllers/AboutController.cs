using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
