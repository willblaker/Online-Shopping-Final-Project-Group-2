using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Entities
{
    [Table("OrderHistory")]
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
