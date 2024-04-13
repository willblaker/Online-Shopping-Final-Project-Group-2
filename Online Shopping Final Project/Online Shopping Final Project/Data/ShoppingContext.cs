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

        public DbSet<CartEntry> CartEntries { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
            new Item { ItemId = 1, ItemName = "Mens - Black T-shirt", ItemDescription = "Black cotton crew neck T-shirt for Men", ItemPrice = 15.50f },
            new Item { ItemId = 2, ItemName = "Mens - Green T-shirt", ItemDescription = "Green cotton crew neck T-shirt for Men", ItemPrice = 15.25f },
            new Item { ItemId = 3, ItemName = "Mens - Pink T-shirt", ItemDescription = "Pink cotton crew neck T-shirt for Men", ItemPrice = 14.50f },
            new Item { ItemId = 4, ItemName = "Mens - Biege T-shirt", ItemDescription = "Biege cotton crew neck T-shirt for Men", ItemPrice = 13.00f },
            new Item { ItemId = 5, ItemName = "Mens - Light Blue Jeans", ItemDescription = "Light Blue Denim Jeans for Men", ItemPrice = 22.25f },
            new Item { ItemId = 6, ItemName = "Mens - Black Jeans", ItemDescription = "Black Denim Jeans for Men", ItemPrice = 25.50f },
            new Item { ItemId = 7, ItemName = "Mens - Grey Jeans", ItemDescription = "Grey Denim Jeans for Men", ItemPrice = 27.25f },
            new Item { ItemId = 8, ItemName = "Mens - Blue Jeans", ItemDescription = "Grey Denim Jeans for Men", ItemPrice = 30.00f });
        }
    }
}
