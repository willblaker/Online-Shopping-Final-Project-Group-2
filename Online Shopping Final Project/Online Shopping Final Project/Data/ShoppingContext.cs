using Microsoft.EntityFrameworkCore;
using Online_Shopping_Final_Project.Entities;

namespace Online_Shopping_Final_Project.Data
{
    public class ShoppingContext:DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<Order> OrderHistory { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}
