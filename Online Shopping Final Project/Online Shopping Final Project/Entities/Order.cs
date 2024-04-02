using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping_Final_Project.Entities
{
    [Table("OrderHistory")]
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
