using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping_Final_Project.Entities
{
    [Table("CartEntry")]
    public class CartEntry
    {
        public int CartEntryId { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}