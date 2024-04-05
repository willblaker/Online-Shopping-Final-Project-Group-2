using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping.Entities
{
    [Table("OrderHistory")]
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
