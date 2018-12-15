using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StockExchange
{
     class MainClass

    {
        static void Main(string[] args)
        {
     
            StockParser stockParser = new StockParser();
            StockProcessor stockProcessor = new StockProcessor();
            StockOutput stockOutput = new StockOutput();

            string inputFilePath = ConfigurationSettings.AppSettings["inputFilePath"];
            string ouputFilePath = ConfigurationSettings.AppSettings["outputFilePath"];
            List<Stock> parsedStockOrderList = stockParser.ParseStocks(inputFilePath);

            List<Stock> processedStockOrderList = stockProcessor.ProcessstockOrderList(parsedStockOrderList);

            stockOutput.WriteOutputToTxtFile(ouputFilePath, processedStockOrderList);

            Console.Read();
        }
    }
}
