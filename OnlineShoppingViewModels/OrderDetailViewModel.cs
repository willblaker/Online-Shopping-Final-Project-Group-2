using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
