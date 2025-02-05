namespace OrderingSystemDashboard.Models.ViewModels
{
    public class ShowMenuItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public int NumberOfAvaliableItem { get; set; }
        public string ImageUrl { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int NumberOfPromotions { get ; set; } 
    }
}
