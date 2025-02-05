using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.DbModels;

namespace OrderingSystem.Models.DbContext
{
    public class OrderDbContext : IdentityDbContext<ApplicationUser>
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItemPromotions> MenuItemPromotions { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<GuestSpecialRequest> GuestSpecialRequest { get; set; }
    }
}
