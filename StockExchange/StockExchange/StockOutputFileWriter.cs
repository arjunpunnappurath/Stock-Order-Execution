using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StockExchange
{/// <summary>
/// Class that contains the method to write the output txt file.
/// </summary>
    class StockOutputFileWriter
    {
        private string headers = "StockId,Company,Side,Quantity,Remaining Quantity,Status";

        //Method to write the output file.
        public  void Write( List<Stock> stockOrderList)
        {
            string outFilePath = OutFilePath();
            StringBuilder sb = new StringBuilder();
            if(!string.IsNullOrEmpty(outFilePath))
            {
                StreamWriter strWriteLogFile = new StreamWriter(outFilePath, true);
                strWriteLogFile.WriteLine(headers);
                foreach (var item in stockOrderList)
                {
                    strWriteLogFile.WriteLine(ToExportRows(item));
                }
                strWriteLogFile.Flush();
                strWriteLogFile.Close();
            }
        }
        //Method to export the rows from the stock object for writing to the file.
        public string ToExportRows(Stock sd)
        {
            return sd.Id + "," + sd.Company + "," +sd.Side + ","   + sd.Quantity.ToString() + "," + sd.RemQuantity.ToString() + "," + sd.Status;
        }
        //Method to get the outfile name and path
         string OutFilePath()
        {
            string fileName = Path.GetTempFileName();
            return fileName;
        }
    }
}
