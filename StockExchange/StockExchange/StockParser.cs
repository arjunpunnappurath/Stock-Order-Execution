using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace StockExchange
{
    public interface IStockParser
    {
        List<Stock> Parse();
    }
    public class FileStockParser : IStockParser
    {
        string inputFile = string.Empty;

        public FileStockParser(string inputfile)
        {
            try
            {
                this.inputFile = inputfile;
                if (inputFile == null)
                    throw new Exception("Input file can't be null");

                if (!File.Exists(inputFile))
                    throw new Exception("File not found");
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static string stockHeaders = "";
        public  List<Stock> Parse ()
        {
            List<Stock> stockOrderList = new List<Stock>();

                using (StreamReader str = new StreamReader(inputFile))
                {
                    stockHeaders = str.ReadLine();
                    stockHeaders = stockHeaders + ",Remaining Quantity,Status";
                    
                    while(!str.EndOfStream)
                    {
                        string[] rows = str.ReadLine().Split(',');
                        if(rows.Length==4)
                        {
                        int qty = 0;
                        if (!int.TryParse(rows[3], out qty))
                            throw new Exception("Invalid value for quantity");

                        StockSide side;
                        if (rows[2] == "Buy" || rows[2] == "BUY" || rows[2] == "buy")
                            side = StockSide.Buy;
                        else
                            side = StockSide.Sell;
                        Stock stock = new Stock(rows[0],  rows[1], side, qty);
                        stock.RemQuantity = qty;
                        stock.Status = StockState.Open;
                        stockOrderList.Add(stock);
                        }
                    }
                }
                return stockOrderList;
            
        }
    }
}
