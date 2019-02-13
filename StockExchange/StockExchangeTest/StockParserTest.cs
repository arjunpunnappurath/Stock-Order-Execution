using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StockExchange;
using System.IO;
using System.Configuration;

namespace StockExchangeTest
{
    [TestFixture]
    class StockParserTest
    {  
        [Test]
        public  void ReadInp()
        {
            string path = GetFilePath();
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
            string path = ConfigurationSettings.AppSettings["fileNotFound"];
            FileStockParser parserTestObject;
            var ex = Assert.Throws<Exception>(() => parserTestObject = new FileStockParser(path));
            Assert.That(ex.Message, Is.EqualTo("File not found"));
        }
        [Test]
        public void TestWrongInput()
        {
            string path = WrongInput();
            FileStockParser paseTObj = new FileStockParser(path);
            var ex = Assert.Throws<Exception>(() => paseTObj.Parse());
            Assert.That(ex.Message, Is.EqualTo("Invalid value for quantity"));
        }


        private string GetFilePath()
        {
            string content = @"StockId,Company,Side,Quantity
1,ABC,Buy,20
2,ABC,Sell,10
3,XYZ,Buy,10
";
            string fileName = Path.GetTempFileName();
            File.WriteAllText(fileName, content);
            return fileName;
        }

        private string WrongInput()
        {
            string content = @"StockId,Company,Side,Quantity
1,ABC,Buy,22.2
2,ABC,Sell,23.5
3,XYZ,Buy,33.6
";
            string fileName = Path.GetTempFileName();
            File.WriteAllText(fileName, content);
            return fileName;
        }
    }
}
