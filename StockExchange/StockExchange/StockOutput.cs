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

            if(!string.IsNullOrEmpty(outFilePath))
            {
                StreamWriter strWriteLogFile = new StreamWriter(outFilePath, true);

                strWriteLogFile.WriteLine(FileStockParser.stockHeaders);

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
            return sd.Id + "," + sd.Company + "," +sd.Side + ","   + sd.Quantity.ToString() + "," + sd.RemQuantity.ToString() + "," + sd.Status;
        }

    }
}
