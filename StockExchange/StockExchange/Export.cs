using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    class Export
    {

        public string ToExportRows(Stock sd)
        {
            return sd.stockId + "," + sd.stockSide + "," + sd.stockCompany + "," + sd.stockQuantity.ToString() + "," + sd.stockRemQuantity.ToString() + "," + sd.stockStatus;
        }
    }
}
