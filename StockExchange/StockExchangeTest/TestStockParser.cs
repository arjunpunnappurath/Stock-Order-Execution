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

        

        [Test]
        public  void ReadInp()
        {

            string path = @"C:\Arjun\Sahaj\Test\TestInput.csv";
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

        [Test]
        public void TestNullInput()

        {
            string path = null;

            FileStockParser parserTestObject;

            var ex = Assert.Throws<Exception>(() => parserTestObject = new FileStockParser(path));

            Assert.That(ex.Message, Is.EqualTo("Input file can't be null"));



        }

        [Test]
        public void FilenotFound()
        {
            string path = @"C:\Arjun\Sahaj\Test\FileNotFound.csv";
            FileStockParser parserTestObject;

            var ex = Assert.Throws<Exception>(() => parserTestObject = new FileStockParser(path));

            Assert.That(ex.Message, Is.EqualTo("File not found"));
        }

        [Test]
        public void TestWrongInput()
        {
            string path = @"C:\Arjun\Sahaj\Test\TestWrongInput.csv";
            FileStockParser paseTObj = new FileStockParser(path);
            var ex = Assert.Throws<Exception>(() => paseTObj.Parse());
            Assert.That(ex.Message, Is.EqualTo("Invalid value for quantity"));
        }
    }
}
