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
        public void ProcessBuyandSell()
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
            processimp.Add(sObj1);
            processimp.Add(sObj2);
            processimp.Add(sObj3);
            Stock out1 = new Stock("1","ABC",StockSide.Buy,10);
            Stock out2 = new Stock("2", "ABC", StockSide.Sell, 10);
            out1.RemQuantity = 0;
            out1.Status = StockState.Closed;
            out2.RemQuantity = 0;
            out2.Status = StockState.Closed;
            List<Stock> processOut = new List<Stock>();
            processOut.Add(out1);
            processOut.Add(out2);
            processOut.Add(sObj3);
            List<Stock> assertOutput = new List<Stock>();
            assertOutput = stockProcessor.ProcessstockOrderList(processimp);
            CollectionAssert.AreEqual(processOut, assertOutput);

        }
        [Test]
        public void ProessOnlyBuy()
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
        public void ProcessOnlySell()
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
