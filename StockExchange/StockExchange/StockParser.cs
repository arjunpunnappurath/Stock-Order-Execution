using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace StockExchange
{   //Interface used to declare the funtion that is used to read an input to the parser. 
    public interface IStockParser
    {
        List<Stock> Parse();
    }
    /// <summary>
    /// The parser class that is primarily responsible for the reading aspect of the program where it consumes a .csv file and loads the data
    /// to a list of "Stock" datatype.
    /// </summary>
    public class FileStockParser : IStockParser
    {
        string inputFile = string.Empty;
        public FileStockParser(string inputfile)
        {
                this.inputFile = inputfile;
                if (inputFile == null)
                    throw new Exception("Input file can't be null");

                if (!File.Exists(inputFile))
                    throw new Exception("File not found");
        }
        public static string stockHeaders = "";
        //Function to parse the input file.
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
                        if(rows[2].ToLower() == "buy")
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
