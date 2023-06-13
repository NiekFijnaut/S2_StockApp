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
    public class AccountStockTest
    {
        [TestMethod]
        public void GetAccountStocksList() 
        {
            // Arrange
            int AccountID = 10;
            AccountStockSTUB accountStockSTUB = new AccountStockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), new AccountStockSTUB());
            List<AccountStockDTO> expected = accountStockSTUB.FakeAccountStocks;

            // Act
            List<AccountStock> list = alphaVantageContainer.GetAccountStockList(AccountID);

            // Assert
            Assert.AreEqual(expected.Count, list.Count);
        }
        
        [TestMethod]

        public void AddStock()
        {
            // Arrange
            int AccountID = 10;
            AccountStockSTUB accountStockSTUB = new AccountStockSTUB();
            APIResponseCallSTUB aPIResponseCallSTUB = new APIResponseCallSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(aPIResponseCallSTUB, accountStockSTUB);
            APIResponseCallDTO aPIResponseCallDTO = new APIResponseCallDTO(
                5,
                new DateTime(2023, 06, 12, 11, 30, 30),
                "KO",
                182.56,
                186.56,
                180.56,
                182.65,
                12000);
            APIResponseCall aPIResponseCall = new APIResponseCall(aPIResponseCallDTO.StockID, aPIResponseCallDTO.Date, aPIResponseCallDTO.Symbol, aPIResponseCallDTO.Open, aPIResponseCallDTO.High, aPIResponseCallDTO.Low, aPIResponseCallDTO.Close, aPIResponseCallDTO.Volume);
            
            // Act
            alphaVantageContainer.AddStock(aPIResponseCall, AccountID);

            // Assert
            Assert.AreEqual(5, accountStockSTUB.CreateFakeAccountStock.StockID);
            Assert.AreEqual("KO", accountStockSTUB.CreateFakeAccountStock.Symbol);
            Assert.AreEqual(10, accountStockSTUB.CreateFakeAccountStock.AccountID);
        }
    }
}
