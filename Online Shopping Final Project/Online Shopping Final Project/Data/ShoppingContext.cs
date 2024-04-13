using Microsoft.EntityFrameworkCore;
using Online_Shopping_Final_Project.Client.Pages;
using Online_Shopping_Final_Project.Entities;

namespace Online_Shopping_Final_Project.Data
{
    public class ShoppingContext:DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<Order> OrderHistory { get; set; }

        // UNCOMMENT WHEN MIGRATIONS FOR THESE ARE BUILT

        //public DbSet<M_Tshirts> tShirts { get; set; }

        //public DbSet<M_Hoodies> hoodies { get; set; }

        //public DbSet<M_Shorts> shorts { get; set; }

        //public DbSet<M_Pants> pants { get; set; }

        //public DbSet<M_Shoes> shoes { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
