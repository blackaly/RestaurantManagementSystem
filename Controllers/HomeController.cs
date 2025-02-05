using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.DbContext;

namespace OrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        OrderDbContext context;
        public HomeController(OrderDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
