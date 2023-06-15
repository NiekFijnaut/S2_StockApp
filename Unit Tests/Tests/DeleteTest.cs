using Business;
using Business.Class;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.STUB;

namespace Unit_Tests.Tests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void DeleteStock(AccountStockDTO accountStockDTO)
        {
            // Arrange
            AccountStock accountStock = new AccountStock(
                accountStockDTO.StockID,
                accountStockDTO.Date,
                accountStockDTO.Symbol,
                accountStockDTO.AccountID);
            AccountStockSTUB accountStockSTUB = new AccountStockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), accountStockSTUB);
            
            // Act
            alphaVantageContainer.DeleteStock(accountStock);

            // Assert
            Assert.AreEqual(2, accountStockSTUB.FakeAccountStocks.Count);
            Assert.IsFalse(accountStockSTUB.FakeAccountStocks.Any(s => s.Symbol == accountStock.Symbol && s.AccountID == accountStock.AccountID && s.StockID == accountStock.StockID && s.Date == accountStock.Date));
        }
    }
}
