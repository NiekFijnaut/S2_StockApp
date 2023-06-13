using Business;
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
        public void DeleteStock_StockDeletedSuccessfully()
        {
            // Arrange
            string symbol = "AAPL";
            int accountId = 10;
            AccountStockSTUB accountStockSTUB = new AccountStockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), new AccountStockSTUB());

            // Act
            alphaVantageContainer.DeleteStock(symbol, accountId);

            // Assert
            Assert.AreEqual(2, accountStockSTUB.FakeAccountStocks.Count);
            Assert.IsFalse(accountStockSTUB.FakeAccountStocks.Any(s => s.Symbol == symbol && s.AccountID == accountId));
        }
    }
}
