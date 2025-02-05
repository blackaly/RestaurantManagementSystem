using OrderingSystem.Models.DbModels;

namespace OrderingSystem.Services.MenuService.Interfaces
{
    public interface IMenuService
    {
        List<OrderingSystem.Models.DbModels.Menu> GetMenuNames();
    }
}
