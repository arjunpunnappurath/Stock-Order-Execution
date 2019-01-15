using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StockExchange;
using System.Configuration;

namespace StockExchangeTest
{/// <summary>
/// Class that is in place to test the Parser logic in the project. 
/// </summary>
    [TestFixture]
    class StockParserTest
    {   //Test function to read an input form a file and assert it with the expected data set.
        [Test]
        public  void ReadInp()
        {
            string path = ConfigurationSettings.AppSettings["readInput"];
            FileStockParser parserTestObject = new FileStockParser(path);
            Stock sObj1 = new Stock("1","ABC",StockSide.Buy,20);
            Stock sObj2 = new Stock("2", "ABC", StockSide.Sell, 10);
            Stock sObj3 = new Stock("3","XYZ",StockSide.Buy,10);
            sObj1.RemQuantity = 20;
            sObj1.Status = StockState.Open;
            sObj2.RemQuantity = 10;
            sObj2.Status = StockState.Open;
            sObj3.RemQuantity = 10;
            sObj3.Status = StockState.Open;
            List<Stock> testAssertParseList = new List<Stock>();
            List<Stock> testOutputParseList = new List<Stock>();
            testAssertParseList.Add(sObj1);
            testAssertParseList.Add(sObj2);
            testAssertParseList.Add(sObj3);
            testOutputParseList = parserTestObject.Parse();
            CollectionAssert.AreEqual(testOutputParseList, testAssertParseList);
        }
        //Test function to try and assert whether an error is prompted or not when we try to read a file when the path parameter is absent.
        [Test]
        public void TestNullInput()
        {
            string path = null;
            FileStockParser parserTestObject;
            var ex = Assert.Throws<Exception>(() => parserTestObject = new FileStockParser(path));
            Assert.That(ex.Message, Is.EqualTo("Input file can't be null"));
        } 
        //Test function to assert whether an error is prompted when try to read a file that is not found in the given path.
        [Test]
        public void FilenotFound()
        {
            string path = ConfigurationSettings.AppSettings["fileNotFound"];
            FileStockParser parserTestObject;
            var ex = Assert.Throws<Exception>(() => parserTestObject = new FileStockParser(path));
            Assert.That(ex.Message, Is.EqualTo("File not found"));
        }
        //Test function to assert whether a correct error is prompted or not when we try to read a file with wrong input in it.
        [Test]
        public void TestWrongInput()
        {
            string path = ConfigurationSettings.AppSettings["wrongInput"];
            FileStockParser paseTObj = new FileStockParser(path);
            var ex = Assert.Throws<Exception>(() => paseTObj.Parse());
            Assert.That(ex.Message, Is.EqualTo("Invalid value for quantity"));
        }
    }
}
