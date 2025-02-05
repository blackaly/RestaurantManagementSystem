
using OrderingSystem.Models.DbModels;

namespace OrderingSystemDashboard.Models.ViewModels.Shared
{
    public class MenuViewModelAndMenuModel
    {
        public MenuViewModelShared menuViewModel { get; set; }
        public ICollection<Menu> menu { get; set; }
    }
}
