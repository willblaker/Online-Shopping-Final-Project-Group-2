using Online_Shopping.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Online_Shopping.Entities
{
    [Table("User")]
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}