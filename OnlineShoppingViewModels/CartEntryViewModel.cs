using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingViewModels
{
    public class CartEntryViewModel
    {
        public int CartEntryId { get; set; }

        public string ItemName { get; set; }

        public float ItemPrice { get; set; }

        public float TotalPrice { get { return ItemPrice * Quantity; } }

        public int Quantity { get; set; }
    }
}
