using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using NuGet.Protocol.Plugins;
using OrderingSystem.Areas.Dashboard.Models.ViewModels;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystemDashboard.Models;
using OrderingSystemDashboard.Models.ViewModels;
using OrderingSystemDashboard.Models.ViewModels.Shared;
using System;

namespace OrderingSystem.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MenuController : Controller
    {
        private OrderDbContext context;
        private readonly IWebHostEnvironment environment;

        public MenuController(OrderDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMenu()
        {
            MenuViewModelAndMenuModel model = new MenuViewModelAndMenuModel();
            model.menu = context.Menus.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddMenu(MenuViewModelAndMenuModel menu)
        {
            if (!menu.menuViewModel.Name.IsNullOrEmpty())
            {
                Menu m = new Menu();
                m.Name = menu.menuViewModel.Name;
                context.Menus.Add(m);
                context.SaveChanges();
                return RedirectToAction("AddMenu");

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult MenuItems()
        {
            ViewData["MenuCategory"] = context.Menus.ToList();
            ViewData["Category"] = context.Categories.ToList();
            return View();
        }

        public IActionResult AddMenuItems(MenuItemsViewModel items)
        {
            if (ModelState.IsValid)
            {
                bool categoryOk = context.Categories.Any(x => x.Id == items.CategoryId);
                bool menuOk = context.Menus.Any(x => x.Id == items.MenuId);

                if (categoryOk && menuOk && items.ImageUrl != null && items.ImageUrl.Length > 0)
                {
                    var uploadsFolder = Path.Combine(environment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + items.ImageUrl.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    try
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            items.ImageUrl.CopyTo(fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);

                        return View("Index", items);
                    }


                    MenuItems item = new MenuItems();
                    item.CategoryId = items.CategoryId;
                    item.Description = items.Description;
                    item.MenuId = items.MenuId;
                    item.Name = items.Name;
                    item.Price = items.Price;
                    item.Availability = items.Availability;
                    item.ImageUrl = uniqueFileName;
                    item.NumberOfAvailableItem = items.NumberofAvaliableItem;

                    context.MenuItems.Add(item);
                    context.SaveChanges();

                    return View("Index");
                }

                return RedirectToAction("MenuItems", items);
            }
            return RedirectToAction("MenuItems");
        }

        [HttpGet]
        public IActionResult ShowMenuItems()
        {
            var items = context.MenuItems.Select(x => new ShowMenuItemViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Availability = x.Availability,
                ImageUrl = x.ImageUrl,
                MenuId = x.MenuId,
                MenuName = x.Menu.Name,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                NumberOfPromotions = x.Promotion.MenuItemPromotions.Count(),
                NumberOfAvaliableItem = x.NumberOfAvailableItem
                

            }).ToList();

            return View(items);
        }

        [HttpGet]
        public IActionResult EditMenuItem(int id)
        {
            if(id <= 0)
            return RedirectToAction("Home", "Index");


            ViewData["MenuCategory"] = context.Menus.ToList();
            ViewData["Category"] = context.Categories.ToList();
      
            var item = context.MenuItems.FirstOrDefault(x => x.Id == id);
            if(item == null) return RedirectToAction("Home", "Index");
            
            MenuItemsViewModel itemViewModel = new MenuItemsViewModel();
            itemViewModel.Price = item.Price;
            itemViewModel.Availability = item.Availability;
            ViewData["Image"] = item.ImageUrl;
            itemViewModel.NumberofAvaliableItem = item.NumberOfAvailableItem;
            itemViewModel.Name = item.Name;
            itemViewModel.Description = item.Description;
            itemViewModel.CategoryId = item.CategoryId;
            itemViewModel.MenuId = item.MenuId;

            return View(itemViewModel);
        }

        [HttpPost]
        public IActionResult EditMenuItem(int id, MenuItemsViewModel items)
        {

            var item = context.MenuItems.FirstOrDefault(x => x.Id == id);

            if (item is not null)
            {
                if (ModelState.IsValid)
                {
                    bool categoryOk = context.Categories.Any(x => x.Id == items.CategoryId);
                    bool menuOk = context.Menus.Any(x => x.Id == items.MenuId);

                    if (categoryOk && menuOk && items.ImageUrl != null && items.ImageUrl.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(environment.WebRootPath, "uploads");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + items.ImageUrl.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        try
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                items.ImageUrl.CopyTo(fileStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", ex.Message);


                        }
                        if (items.ImageUrl.Length != 0) item.ImageUrl = uniqueFileName;
                    }
                    item.CategoryId = items.CategoryId;
                    item.Description = items.Description;
                    item.MenuId = items.MenuId;
                    item.Name = items.Name;
                    item.Price = items.Price;
                    item.Availability = items.Availability;
                    item.NumberOfAvailableItem = items.NumberofAvaliableItem;
                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();

                    return View("Index", items);
                }
                else
                    return View(items);
            }


            return RedirectToAction("MenuItems");
        }

        public IActionResult Delete(int id)
        {

            var item = context.MenuItems.Find(id);

            if (item is null)
            {
                ModelState.AddModelError("", "There is no table with this number");
                return View();
            }



            return View(new ShowMenuItemViewModel
            {
                MenuId = item.Id,
                MenuName = item.Name,
                Description = item.Description
            });
        }
        [HttpPost]
        public IActionResult DeleteItemMenu(int MenuId)
        {

            var item = context.MenuItems.Find(MenuId);
            if (item is null)
                return View();
            context.MenuItems.Remove(item);
            context.SaveChanges();
            return RedirectToAction("ShowMenuItems");
        }

    }
}
