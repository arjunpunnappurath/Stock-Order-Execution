using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Compatibility;
using NUnit.Framework;
using StockExchange;




namespace UnitTest
{
    [TestFixture]
    class StockExchangeTest
    {
        [Test]
        public void ProcessFirstCase()
        {

            Stock sObj1 = new Stock();
            Stock sObj2 = new Stock();
            Stock sObj3 = new Stock();

            StockProcessor stockProcessor = new StockProcessor();

            List<Stock> processimp = new List<Stock>();

            sObj1.stockId = "1";
            sObj1.stockSide = "Buy";
            sObj1.stockCompany = "ABC";
            sObj1.stockQuantity = 10;
            sObj1.stockRemQuantity = 10;
            sObj1.stockStatus = "Open";


            sObj2.stockId = "2";
            sObj2.stockSide = "Sell";
            sObj2.stockCompany = "ABC";
            sObj2.stockQuantity = 10;
            sObj2.stockRemQuantity = 10;
            sObj2.stockStatus = "Open";


            sObj3.stockId = "3";
            sObj3.stockSide = "Buy";
            sObj3.stockCompany = "XYZ";
            sObj3.stockQuantity = 10;
            sObj3.stockRemQuantity = 10;
            sObj3.stockStatus = "Open";

            processimp.Add(sObj1);
            processimp.Add(sObj2);
            processimp.Add(sObj3);




            Stock out1 = new Stock();

            out1.stockId = "1";
            out1.stockSide = "Buy";
            out1.stockCompany = "ABC";
            out1.stockQuantity = 10;
            out1.stockRemQuantity = 0;
            out1.stockStatus = "Close";

            Stock out2 = new Stock();

            out2.stockId = "2";
            out2.stockSide = "Sell";
            out2.stockCompany = "ABC";
            out2.stockQuantity = 10;
            out2.stockRemQuantity = 0;
            out2.stockStatus = "Close";

            List<Stock> processOut = new List<Stock>();

            processOut.Add(out1);
            processOut.Add(out2);
            processOut.Add(sObj3);

            List<Stock> assertOutput = new List<Stock>();
            assertOutput = stockProcessor.ProcessstockOrderList(processimp);
            CollectionAssert.AreEqual(processOut, assertOutput);

        }

        [Test]
        public void ProessSecondCase()
        {
                Stock sObj1 = new Stock();
                Stock sObj2 = new Stock();
                Stock sObj3 = new Stock();
            
                StockProcessor stockProcessor = new StockProcessor();

                List<Stock> processimp = new List<Stock>();

                sObj1.stockId = "1";
                sObj1.stockSide = "Buy";
                sObj1.stockCompany = "ABC";
                sObj1.stockQuantity = 10;
                sObj1.stockRemQuantity = 10;
                sObj1.stockStatus = "Open";


                sObj2.stockId = "2";
                sObj2.stockSide = "Buy";
                sObj2.stockCompany = "ABC";
                sObj2.stockQuantity = 10;
                sObj2.stockRemQuantity = 10;
                sObj2.stockStatus = "Open";


                sObj3.stockId = "3";
                sObj3.stockSide = "Buy";
                sObj3.stockCompany = "XYZ";
                sObj3.stockQuantity = 10;
                sObj3.stockRemQuantity = 10;
                sObj3.stockStatus = "Open";

                processimp.Add(sObj1);
                processimp.Add(sObj2);
                processimp.Add(sObj3);




                Stock out1 = new Stock();

                out1.stockId = "1";
                out1.stockSide = "Buy";
                out1.stockCompany = "ABC";
                out1.stockQuantity = 10;
                out1.stockRemQuantity = 0;
                out1.stockStatus = "Open";

                Stock out2 = new Stock();

                out2.stockId = "2";
                out2.stockSide = "Buy";
                out2.stockCompany = "ABC";
                out2.stockQuantity = 10;
                out2.stockRemQuantity = 0;
                out2.stockStatus = "Open";

                List<Stock> processOut = new List<Stock>();

                processOut.Add(out1);
                processOut.Add(out2);
                processOut.Add(sObj3);

                List<Stock> assertOutput = new List<Stock>();
                assertOutput = stockProcessor.ProcessstockOrderList(processimp);
                CollectionAssert.AreEqual(processOut, assertOutput);
        }

        [Test]
        public void ProcessThirdCase()
        {
            Stock sObj1 = new Stock();
            Stock sObj2 = new Stock();
            Stock sObj3 = new Stock();

            StockProcessor stockProcessor = new StockProcessor();

            List<Stock> processimp = new List<Stock>();

            sObj1.stockId = "1";
            sObj1.stockSide = "Sell";
            sObj1.stockCompany = "ABC";
            sObj1.stockQuantity = 10;
            sObj1.stockRemQuantity = 10;
            sObj1.stockStatus = "Open";


            sObj2.stockId = "2";
            sObj2.stockSide = "Sell";
            sObj2.stockCompany = "ABC";
            sObj2.stockQuantity = 10;
            sObj2.stockRemQuantity = 10;
            sObj2.stockStatus = "Open";


            sObj3.stockId = "3";
            sObj3.stockSide = "Sell";
            sObj3.stockCompany = "XYZ";
            sObj3.stockQuantity = 10;
            sObj3.stockRemQuantity = 10;
            sObj3.stockStatus = "Open";

            processimp.Add(sObj1);
            processimp.Add(sObj2);
            processimp.Add(sObj3);




            Stock out1 = new Stock();

            out1.stockId = "1";
            out1.stockSide = "Sell";
            out1.stockCompany = "ABC";
            out1.stockQuantity = 10;
            out1.stockRemQuantity = 0;
            out1.stockStatus = "Open";

            Stock out2 = new Stock();

            out2.stockId = "2";
            out2.stockSide = "Sell";
            out2.stockCompany = "ABC";
            out2.stockQuantity = 10;
            out2.stockRemQuantity = 0;
            out2.stockStatus = "Open";

            List<Stock> processOut = new List<Stock>();

            processOut.Add(out1);
            processOut.Add(out2);
            processOut.Add(sObj3);

            List<Stock> assertOutput = new List<Stock>();
            assertOutput = stockProcessor.ProcessstockOrderList(processimp);
            CollectionAssert.AreEqual(processOut, assertOutput);
        }
    }
}
