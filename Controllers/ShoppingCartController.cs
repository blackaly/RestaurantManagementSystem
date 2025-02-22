using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
