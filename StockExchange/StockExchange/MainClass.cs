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
            string inputFilePath = ConfigurationSettings.AppSettings["inputFilePath"];
            string ouputFilePath = ConfigurationSettings.AppSettings["outputFilePath"];

            IStockParser stockParser = new FileStockParser(inputFilePath);
            StockProcessor stockProcessor = new StockProcessor();
            StockOutput stockOutput = new StockOutput();
            List<Stock> parsedStockOrderList = stockParser.Parse();
             List<Stock> processedStockOrderList = stockProcessor.ProcessstockOrderList(parsedStockOrderList);
            stockOutput.WriteOutputToTxtFile(ouputFilePath, processedStockOrderList);
            Console.Read();
        }
    }
}
