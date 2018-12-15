using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace StockExchange
{
    
    public class StockParser : Stock
    {
        public static string stockHeaders = "";
        public  List<Stock> ParseStocks (string inputStream)
        {
            List<Stock> stockOrderList = new List<Stock>();
            
            
            if(inputStream == null)
            {
                return stockOrderList;
            }

            else
            {
                using (StreamReader str = new StreamReader(inputStream))
                {
                    stockHeaders = str.ReadLine();
                    stockHeaders = stockHeaders + ",Remaining Quantity,Status";
                    
                    while(!str.EndOfStream)
                    {
                        string[] rows = str.ReadLine().Split(',');
                        if(rows.Length==4)
                        {
                            Stock objStock = new Stock();
                            objStock.stockId = rows[0];
                            objStock.stockSide = rows[1];
                            objStock.stockCompany = rows[2];
                            objStock.stockQuantity = Convert.ToInt16(rows[3]);
                            objStock.stockRemQuantity = Convert.ToInt16(rows[3]);
                            objStock.stockStatus = "Open";

                            stockOrderList.Add(objStock);
                        }
                    }
                }
                return stockOrderList;
            }
        }
    }
}
