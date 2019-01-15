using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StockExchange
{/// <summary>
/// Class that contains the method to write the output txt file.
/// </summary>
    class StockOutput
    {    //Method to write the output file.
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
        //Method to export the rows from the stock object for writing to the file.
        public string ToExportRows(Stock sd)
        {
            return sd.Id + "," + sd.Company + "," +sd.Side + ","   + sd.Quantity.ToString() + "," + sd.RemQuantity.ToString() + "," + sd.Status;
        }
    }
}
