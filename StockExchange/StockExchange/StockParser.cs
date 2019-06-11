using System;
using System.Collections.Generic;
using System.IO;

namespace StockExchange
{
    //Interface used to declare the funtion that is used to read an input to the parser. 
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

        public FileStockParser(string inputFile)
        {
            if (inputFile == null)
                throw new Exception("Input file can't be null");

            if (!File.Exists(inputFile))
                throw new Exception("File not found");

            this.inputFile = inputFile;
        }

        //Function to parse the input file.
        public List<Stock> Parse()
        {
            List<Stock> stockOrderList = new List<Stock>();
            var lines = File.ReadAllLines(inputFile);
            for (int i = 0; i < lines.Length; i++)
            {
                var isHeader = i == 0;
                if (isHeader)
                    continue;

                var stock = ParseStock(lines[i]);
                if (stock != null)
                    stockOrderList.Add(stock);
            }

            return stockOrderList;
        }

        private Stock ParseStock(string line)
        {
            string[] rows = line.Split(',');
            if (rows.Length != 4)
                return null;

            if (!int.TryParse(rows[3], out int qty))
                throw new Exception("Invalid value for quantity");

            StockSide side = StockSide.Sell;
            if (rows[2].ToLower() == "buy")
                side = StockSide.Buy;

            return new Stock(rows[0], rows[1], side, qty);
        }
    }
}