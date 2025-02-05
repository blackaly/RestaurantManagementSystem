using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.ViewModel;

namespace OrderingSystem.Controllers
{
    public class MenuController : Controller
    {
        OrderDbContext context;
        public MenuController(OrderDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var items = context.Menus.Select(x => new ShowMenu
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View(items);
        }

        public IActionResult MenuItems(int id)
        {
            if(id > 0)
            {

                ICollection<MenuItems> item = context.MenuItems.Include(x => x.Category).Where(x => x.MenuId == id).ToList();

                return View("Items", item);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
