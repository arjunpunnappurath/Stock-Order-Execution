using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    /// <summary>
    /// The class which contains methods that are responsible for processing the input list.
    /// </summary>
    public class StockProcessor 
    {
        Dictionary<string, List<Stock>> stockState = new Dictionary<string, List<Stock>>();
        public  List<Stock> ProcessstockOrderList(List<Stock> stockOrderList)
        {
            List<Stock> existingOrders = new List<Stock>();
            foreach (var stock in stockOrderList)
            {
                if (stockState.TryGetValue(stock.Company,  out existingOrders))
                {
                    if (stock.Side == StockSide.Buy)
                        existingOrders.Add(stock);
                    else 
                    {
                        foreach (var item in existingOrders)
                        {
                            int buffQty;
                            if(stock.RemQuantity > item.RemQuantity && item.Side == StockSide.Buy)
                            {
                                buffQty = stock.RemQuantity - item.RemQuantity;
                                stock.UpdateRemainingQuantity(buffQty);
                                item.UpdateRemainingQuantity(0);
                            }
                            else if (item.RemQuantity > stock.RemQuantity && item.Side == StockSide.Buy)
                            {
                                buffQty = item.RemQuantity - stock.RemQuantity;
                                item.UpdateRemainingQuantity(buffQty);
                                stock.UpdateRemainingQuantity(0);
                                break;
                            }
                            else if(item.RemQuantity == stock.RemQuantity && item.Side == StockSide.Buy)
                            {
                                buffQty = Math.Abs(stock.RemQuantity - item.RemQuantity);
                                stock.UpdateRemainingQuantity(buffQty);
                                item.UpdateRemainingQuantity(buffQty);
                                break;
                            }
                         
                        }
                    }
                }
                else
                {
                    List<Stock> stocks = new List<Stock>();
                    stocks.Add(stock);
                    stockState.Add(stock.Company, stocks);
                }
            }
            return stockOrderList;
        }

    }
}
