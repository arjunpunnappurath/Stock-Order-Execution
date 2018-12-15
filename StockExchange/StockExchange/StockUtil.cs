using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    class StockUtil 
    {
        public bool HasRecords(string currCompany, List<Stock> lst)
        {
            int buyRecordCount = lst.Where(b => b.stockCompany.Trim() == currCompany && b.stockSide.Trim() == "Buy" && b.stockRemQuantity > 0).Count();
            int sellRecordCount = lst.Where(b => b.stockCompany.Trim() == currCompany && b.stockSide.Trim() == "Sell" && b.stockRemQuantity > 0).Count();

            if (buyRecordCount > 0 && sellRecordCount > 0)
                return true;
            else
                return false;     
        }

        public void StockBuySellUpdate(ref List<Stock> stockOrderList, string stockId, int stockQty)
        {
            foreach (var item in stockOrderList.Where(b => (b.stockId == stockId)))
            {
                item.stockRemQuantity = stockQty;
                if (stockQty > 0)
                    item.stockStatus = "Open";
                else
                    item.stockStatus = "Close";
            }
               
            
        }
    }
}
