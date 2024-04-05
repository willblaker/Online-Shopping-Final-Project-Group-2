using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping_Final_Project.Entities
{
    [Table("Items")]
    public class Item
    {
        public int ItemId { get; set; }
        [MaxLength(50)]
        public string ItemName { get; set; }
        [MaxLength(50)]
        public string ItemDescription { get; set; }
        public float ItemPrice { get; set; }
    }
}
