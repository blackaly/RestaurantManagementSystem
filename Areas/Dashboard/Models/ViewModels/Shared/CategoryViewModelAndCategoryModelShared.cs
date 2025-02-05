namespace OrderingSystemDashboard.Models.ViewModels.Shared
{
    public class CategoryViewModelAndCategoryModelShared
    {
        public CategoryViewModel categoryViewModel { get; set; }
        public ICollection<CategoryViewModel> listOfCategoryViewModel { get; set; }
    }
}
