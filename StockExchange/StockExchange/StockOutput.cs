using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StockExchange
{
    class StockOutput
    {
       
        public  void WriteOutputToTxtFile(string outFilePath, List<Stock> stockOrderList)
        {
            StringBuilder sb = new StringBuilder();
            Stock sd = new Stock();

            if(!string.IsNullOrEmpty(outFilePath))
            {
                StreamWriter strWriteLogFile = new StreamWriter(outFilePath, true);

                strWriteLogFile.WriteLine(StockParser.stockHeaders);

                foreach (var item in stockOrderList)
                {
                    strWriteLogFile.WriteLine(ToExportRows(item));
                }

                strWriteLogFile.Flush();
                strWriteLogFile.Close();
                Console.WriteLine("Output File Creation Successful");

                Console.Read();

            }
        }

        public string ToExportRows(Stock sd)
        {
            return sd.stockId + "," + sd.stockSide + "," + sd.stockCompany + "," + sd.stockQuantity.ToString() + "," + sd.stockRemQuantity.ToString() + "," + sd.stockStatus;
        }

    }
}
