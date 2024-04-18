using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping_Final_Project.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
