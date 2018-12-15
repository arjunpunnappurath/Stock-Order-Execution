using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class StockProcessor 
    {
      
        public  List<Stock> ProcessstockOrderList(List<Stock> stockOrderList)
        {

            StockUtil stockUtil = new StockUtil();
            if(stockOrderList.Count ==0)
            {
                return stockOrderList;
            }
            else
            {
                var distinctCompany = stockOrderList.Select(b => b.stockCompany).Distinct();
                foreach (string  currCompany in distinctCompany)
                {
                    while(stockUtil.HasRecords(currCompany,stockOrderList))
                    {
                        int buyQty = 0; string buyId = "";
                        int sellQty = 0; string sellId = "";
                        //for (int currCount = 0; currCount < maxRecordCount; currCount++)
                        //{                            
                        var currBuyRecord = stockOrderList.Where(b => b.stockCompany.Trim() == currCompany && b.stockSide.Trim() == "Buy" && b.stockRemQuantity > 0).FirstOrDefault();
                        if (currBuyRecord != null)
                        {
                            buyQty = currBuyRecord.stockRemQuantity;
                            buyId = currBuyRecord.stockId;
                        }

                        var currSellRecord = stockOrderList.Where(s => s.stockCompany.Trim() == currCompany && s.stockSide.Trim() == "Sell" && s.stockRemQuantity > 0).FirstOrDefault();
                        if (currSellRecord != null)
                        {
                            sellQty = currSellRecord.stockRemQuantity;
                            sellId = currSellRecord.stockId;
                        }

                        if (buyQty > 0 && sellQty > 0)
                        {
                            if (buyQty >= sellQty)
                            {
                                buyQty = buyQty - sellQty;
                                sellQty = 0;
                            }
                            else if (sellQty >= buyQty)
                            {
                                sellQty = sellQty - buyQty;
                                buyQty = 0;
                            }

                            stockUtil.StockBuySellUpdate(ref stockOrderList, buyId, buyQty);
                            stockUtil.StockBuySellUpdate(ref stockOrderList, sellId, sellQty);

                            /*   foreach (var buystck in stockOrderList.Where(b => (b.stockId == buyId)))
                               {
                                   buystck.stockRemQuantity = buyQty;
                                   if (buyQty > 1)
                                       buystck.stockStatus = "Open";
                                   else
                                       buystck.stockStatus = "Close";
                               }

                               foreach (var sellstck in stockOrderList.Where(b => (b.stockId == sellId)))
                               {
                                   sellstck.stockRemQuantity = sellQty;
                                   if (sellQty > 1)
                                       sellstck.stockStatus = "Open";
                                   else
                                       sellstck.stockStatus = "Close";

                               }*/
                        }
                    }

                }

                return stockOrderList;
            }
        }
    }
}
