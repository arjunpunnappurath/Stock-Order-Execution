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

            IStockParser stockParser = new FileStockParser(inputFilePath);
            StockProcessor stockProcessor = new StockProcessor();
            StockOutputFileWriter stockOutput = new StockOutputFileWriter();
            List<Stock> parsedStockOrderList = stockParser.Parse();
             List<Stock> processedStockOrderList = stockProcessor.ProcessstockOrderList(parsedStockOrderList);
            stockOutput.Write( processedStockOrderList);
            Console.WriteLine("Outputfile Created successfully");
            Console.Read();
        }
    }
}
