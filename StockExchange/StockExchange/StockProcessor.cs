using System;
using System.Collections.Generic;

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
                if (existingOrders == null)
                {
                    List<Stock> stocks = new List<Stock>();
                    stocks.Add(stock);
                    stockState.Add(stock.Company, stocks);
                }
                else if (stock.Side == StockSide.Sell)
                {
                    ProcessSellingIn(existingOrders, stock);
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

        private void ProcessSellingIn(List<Stock> existingOrders, Stock currentStock)
        {
            foreach (var existingStock in existingOrders)
            {
                if (existingStock.Side != StockSide.Buy)
                    continue;
                SellAndCloseOrder(existingStock, currentStock);
                if (currentStock.IsClosed)
                    break;
            }
        }

        private bool SellAndCloseOrder(Stock existingStock, Stock currentStock)
        {
            Stock left = existingStock;
            Stock right = currentStock;
            if (currentStock.RemQuantity > existingStock.RemQuantity)
            {
                left = currentStock;
                right = existingStock;
            }
            int buffQty = left.RemQuantity - right.RemQuantity;
            left.UpdateRemainingQuantity(buffQty);
            right.UpdateRemainingQuantity(0);
            return true;
        }
    }
}