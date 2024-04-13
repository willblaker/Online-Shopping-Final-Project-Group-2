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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = 1,
                    Username = "user 1", 
                    Email = "user1@onlineshopping.com", 
                    PasswordHash = "hashedpassword1", 
                    FirstName = "User", 
                    LastName = "User1", 
                    Address = "123 User1 St", 
                    City = "City1", 
                    State = "State1", 
                    PostalCode = "45219" 
                },
                new User
                {
                    UserId = 2,
                    Username = "user 2",
                    Email = "user2@onlineshopping.com",
                    PasswordHash = "hashedpassword2",
                    FirstName = "User",
                    LastName = "User2",
                    Address = "123 User2 St",
                    City = "City2",
                    State = "State2",
                    PostalCode = "45219"
                },
                new User
                {   
                    UserId = 3,
                    Username = "user 3",
                    Email = "user3@onlineshopping.com",
                    PasswordHash = "hashedpassword3",
                    FirstName = "User",
                    LastName = "User3",
                    Address = "123 User3 St",
                    City = "City3",
                    State = "State3",
                    PostalCode = "45219"
                }
            );
        }
    }
}
