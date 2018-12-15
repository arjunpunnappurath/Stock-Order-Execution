using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StockExchange;


namespace StockExchangeTest
{
    [TestFixture]
    class TestStockParser
    {

        StockParser parserTestObject = new StockParser();

        [Test]
        public  void ReadInp()
        {

            string path = @"C:\Arjun\Sahaj\Test\TestInput.csv";
            Stock sObj1 = new Stock();
            Stock sObj2 = new Stock();
            Stock sObj3 = new Stock();

            List<Stock> testAssertParseList = new List<Stock>();
            List<Stock> testOutputParseList = new List<Stock>();

            sObj1.stockId = "1";
            sObj1.stockSide = "Buy";
            sObj1.stockCompany = "ABC";
            sObj1.stockQuantity = 20;
            sObj1.stockRemQuantity = 20;
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

            testAssertParseList.Add(sObj1);
            testAssertParseList.Add(sObj2);
            testAssertParseList.Add(sObj3);

            testOutputParseList = parserTestObject.ParseStocks(path);

            CollectionAssert.AreEqual(testOutputParseList, testAssertParseList);
        }

        [Test]
        public void TestNoFile()

        {
            string path = null;
               List<Stock> testOutputParseList = parserTestObject.ParseStocks(path);
            CollectionAssert.IsEmpty(testOutputParseList);
        }

        [Test]
        public void WrongInputFile()
        {
            string path = @"C:\Arjun\Sahaj\Test\TestWrongInput.csv";
            List<Stock> testOutputParseList = parserTestObject.ParseStocks(path);
            CollectionAssert.IsEmpty(testOutputParseList);
        }
    }
}
