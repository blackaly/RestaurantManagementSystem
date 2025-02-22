using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.ViewModel;

namespace OrderingSystem.Controllers
{
    public class ItemDetailsController : Controller
    {
        private OrderDbContext context;
        public ItemDetailsController(OrderDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(int id)
        {
            var data = context.MenuItems.Find(id);
            if(data != null)
            {
                MenuItemViewModel viewModel = new MenuItemViewModel();
                viewModel.Description = data.Description;
                viewModel.Name = data.Name;
                viewModel.ImageUrl = data.ImageUrl;
                viewModel.Price = data.Price;
                viewModel.Category = context.Categories.Find(data.CategoryId)?.Name;
                viewModel.id = data.Id;

                return View(viewModel);
            }
            return View(null);
        }
    }
}
