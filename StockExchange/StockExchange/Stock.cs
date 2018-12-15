using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Stock
    {
        public string stockId { get; set; }
        public string stockSide { get; set; }
        public string stockCompany { get; set; }
        public int stockQuantity { get; set; }
        public int stockRemQuantity { get; set; }
        public string stockStatus { get; set; }

        public override bool Equals(object obj)
        {
            var arg = obj as Stock;
            if (stockId.Equals(arg.stockId) && stockSide.Equals(arg.stockSide) && stockCompany.Equals(arg.stockCompany) && stockQuantity.Equals(arg.stockQuantity) && stockStatus.Equals(arg.stockStatus))
                return true;
            return false;
        }
    }
}
