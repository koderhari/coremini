using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniWebReceipt.Insfrastructure.Model
{
    public class ReceiptItem
    {
        public string Product { get; set; }
        public int Qty { get; set; }

        public decimal Price { get; set; }
    }
}
