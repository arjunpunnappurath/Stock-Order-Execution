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

            Stock sObj1 = new Stock("1","ABC",StockSide.Buy,10);
            Stock sObj2 = new Stock("2", "ABC", StockSide.Sell, 10);
            Stock sObj3 = new Stock("3", "XYZ", StockSide.Buy, 10);

            sObj1.RemQuantity = 10;
            sObj1.Status = StockState.Open;

            sObj2.RemQuantity = 10;
            sObj2.Status = StockState.Open;

            sObj3.RemQuantity = 10;
            sObj3.Status = StockState.Open;

            StockProcessor stockProcessor = new StockProcessor();

            List<Stock> processimp = new List<Stock>();

            //sObj1.Id = "1";
            //sObj1.Side = "Buy";
            //sObj1.Company = "ABC";
            //sObj1.Quantity = 10;
            //sObj1.RemQuantity = 10;
            //sObj1.Status = "Open";


            //sObj2.Id = "2";
            //sObj2.Side = "Sell";
            //sObj2.Company = "ABC";
            //sObj2.Quantity = 10;
            //sObj2.RemQuantity = 10;
            //sObj2.Status = "Open";


            //sObj3.Id = "3";
            //sObj3.Side = "Buy";
            //sObj3.Company = "XYZ";
            //sObj3.Quantity = 10;
            //sObj3.RemQuantity = 10;
            //sObj3.Status = "Open";

            processimp.Add(sObj1);
            processimp.Add(sObj2);
            processimp.Add(sObj3);




            Stock out1 = new Stock("1","ABC",StockSide.Buy,10);
            Stock out2 = new Stock("2", "ABC", StockSide.Sell, 10);

            out1.RemQuantity = 0;
            out1.Status = StockState.Close;

            out2.RemQuantity = 0;
            out2.Status = StockState.Close;

            //out1.Id = "1";
            //out1.Side = "Buy";
            //out1.Company = "ABC";
            //out1.Quantity = 10;
            //out1.RemQuantity = 0;
            //out1.Status = "Close";

            //Stock out2 = new Stock();

            //out2.Id = "2";
            //out2.Side = "Sell";
            //out2.Company = "ABC";
            //out2.Quantity = 10;
            //out2.RemQuantity = 0;
            //out2.Status = "Close";

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
                Stock sObj1 = new Stock("1","ABC",StockSide.Buy,10);
                Stock sObj2 = new Stock("2","ABC",StockSide.Buy,10);
                Stock sObj3 = new Stock("3", "XYZ", StockSide.Buy, 10);

            sObj1.RemQuantity = 10;
            sObj1.Status = StockState.Open;

            sObj2.RemQuantity = 10;
            sObj2.Status = StockState.Open;

            sObj3.RemQuantity = 10;
            sObj3.Status = StockState.Open;

            StockProcessor stockProcessor = new StockProcessor();

                List<Stock> processimp = new List<Stock>();

            processimp.Add(sObj1);
            processimp.Add(sObj2);
            processimp.Add(sObj3);




                List<Stock> processOut = new List<Stock>();

                processOut.Add(sObj1);
                processOut.Add(sObj2);
                processOut.Add(sObj3);

                List<Stock> assertOutput = new List<Stock>();
                assertOutput = stockProcessor.ProcessstockOrderList(processimp);
                CollectionAssert.AreEqual(processOut, assertOutput);
        }

        [Test]
        public void ProcessThirdCase()
        {
            Stock sObj1 = new Stock("1", "ABC", StockSide.Sell, 10);
            Stock sObj2 = new Stock("2","ABC",StockSide.Sell,10);
            Stock sObj3 = new Stock("3","XYZ",StockSide.Sell,10);


            sObj1.RemQuantity = 10;
            sObj1.Status = StockState.Open;

            sObj2.RemQuantity = 10;
            sObj2.Status = StockState.Open;

            sObj3.RemQuantity = 10;
            sObj3.Status = StockState.Open;

            StockProcessor stockProcessor = new StockProcessor();

            List<Stock> processimp = new List<Stock>();


            processimp.Add(sObj1);
            processimp.Add(sObj2);
            processimp.Add(sObj3);

            List<Stock> processOut = new List<Stock>();

            processOut.Add(sObj1);
            processOut.Add(sObj2);
            processOut.Add(sObj3);

            List<Stock> assertOutput = new List<Stock>();
            assertOutput = stockProcessor.ProcessstockOrderList(processimp);
            CollectionAssert.AreEqual(processOut, assertOutput);
        }
    }
}
