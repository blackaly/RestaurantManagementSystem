using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Services.MenuService.Interfaces;

namespace OrderingSystem.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuService menuService;
        public MenuViewComponent(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        public IViewComponentResult Invoke()
        {

            return View(menuService.GetMenuNames());
        }

    }
}
