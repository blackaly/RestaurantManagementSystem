using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Services.MenuService.Interfaces;

namespace OrderingSystem.Services.Menu.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly OrderDbContext dbContext;
        public MenuService(OrderDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Models.DbModels.Menu> GetMenuNames()
        {
            var item = dbContext.Menus.ToList();

            return item;
        }
    }
}
