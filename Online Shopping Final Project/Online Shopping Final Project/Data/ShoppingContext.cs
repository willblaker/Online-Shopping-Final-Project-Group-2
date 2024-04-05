using Microsoft.EntityFrameworkCore;
using Online_Shopping.Entities;

namespace Online_Shopping.Data
{
    public class ShoppingContext:DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<Order> OrderHistory { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
