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
        public List<Stock> ProcessstockOrderList(List<Stock> stockOrderList)
        {
           
            foreach (var stock in stockOrderList)
            {
                var existingOrders = GetExisingOrdersForCompany(stock);
                if(existingOrders == null)
                {
                    List<Stock> stocks = new List<Stock>();
                    stocks.Add(stock);
                    stockState.Add(stock.Company, stocks);
                }
                else if(existingOrders != null && stock.Side == StockSide.Sell)
                {
                    processSellingIn(existingOrders, stock);
                }
            }
            return stockOrderList;
        }

        private List<Stock> GetExisingOrdersForCompany(Stock stock)
        {
            List<Stock> existingOrders = new List<Stock>();
            if (stockState.TryGetValue(stock.Company, out existingOrders))
            {
                if (stock.Side == StockSide.Buy)
                    existingOrders.Add(stock);
                return existingOrders;
            }
            return null;
        }

        private void processSellingIn(List<Stock> existingOrders, Stock stock)
        {
            foreach (var item in existingOrders)
            {
                //int buffQty;

                if (stock.RemQuantity > item.RemQuantity && item.Side == StockSide.Buy)
                {
                    //buffQty = stock.RemQuantity - item.RemQuantity;
                    //stock.UpdateRemainingQuantity(buffQty);
                    //item.UpdateRemainingQuantity(0);
                    SellAndCloseCurrentOrder(item, stock);
                }
                else if (item.RemQuantity > stock.RemQuantity && item.Side == StockSide.Buy)
                {
                    //buffQty = item.RemQuantity - stock.RemQuantity;
                    //item.UpdateRemainingQuantity(buffQty);
                    //stock.UpdateRemainingQuantity(0);
                    bool val = SellAndCloseExistingOrder(item, stock);
                    break;
                }
                else if (item.RemQuantity == stock.RemQuantity && item.Side == StockSide.Buy)
                {
                    //buffQty = Math.Abs(stock.RemQuantity - item.RemQuantity);
                    //stock.UpdateRemainingQuantity(buffQty);
                    //item.UpdateRemainingQuantity(buffQty);
                    bool val = SellandCloseBothItems(item, stock);
                    break;
                }
            }
        }

        private bool SellandCloseBothItems(Stock item, Stock stock)
        {
            try
            {
                int buffQty = Math.Abs(stock.RemQuantity - item.RemQuantity);
                stock.UpdateRemainingQuantity(buffQty);
                item.UpdateRemainingQuantity(buffQty);
                return true;
            }
           catch
            {
                return false;
            }
        }

        private void SellAndCloseCurrentOrder(Stock item, Stock stock)
        {
            int buffQty = stock.RemQuantity - item.RemQuantity;
            stock.UpdateRemainingQuantity(buffQty);
            item.UpdateRemainingQuantity(0);
        }

        private bool SellAndCloseExistingOrder(Stock item, Stock stock)
        {
            try
            {
                int buffQty = item.RemQuantity - stock.RemQuantity;
                item.UpdateRemainingQuantity(buffQty);
                stock.UpdateRemainingQuantity(0);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
