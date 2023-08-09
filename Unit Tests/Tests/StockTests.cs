using Business;
using Business.Class;
using Interface;
using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.STUB;

namespace Unit_Tests.Tests
{
    [TestClass]
    public class StockTests : IStock
    {
        [TestMethod]
        public List<FavoriteDTO> GetFavoriteList(int AccountID)
        {
            // Arrange
            AccountID = 10;
            StockSTUB favoriteSTUB = new StockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), favoriteSTUB);
            List<FavoriteDTO> expected = favoriteSTUB.fakeFavorites;

            // Act
            List<Favorite> list = alphaVantageContainer.GetFavoriteList(AccountID);

            // Assert
            Assert.AreEqual(expected[0].Symbol, list[0].Symbol);
            Assert.AreEqual(expected[1].Symbol, list[1].Symbol);
            Assert.AreEqual(expected[2].Symbol, list[2].Symbol);
            return expected;
        }

        public void AddToFavorite(FavoriteDTO favoriteDTO)
        {
            // Arrange
            Favorite favorite = new Favorite(
                favoriteDTO.StockID,
                favoriteDTO.Symbol,
                favoriteDTO.AccountID);
            StockSTUB favoriteSTUB = new StockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), favoriteSTUB);

            // Act
            alphaVantageContainer.AddToFavorite(favorite);

            // Assert
            Assert.AreEqual(1, favoriteSTUB.CreateFakeFavoriteDTO.StockID);
            Assert.AreEqual("AAPL", favoriteSTUB.CreateFakeFavoriteDTO.Symbol);
            Assert.AreEqual(10, favoriteSTUB.CreateFakeFavoriteDTO.AccountID);
        }

        public void DeleteFavorite(FavoriteDTO favoriteDTO)
        {
            // Arrange
            Favorite favorite = new Favorite(
                favoriteDTO.StockID,
                favoriteDTO.Symbol,
                favoriteDTO.AccountID);
            StockSTUB favoriteSTUB = new StockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), favoriteSTUB);

            // Act
            alphaVantageContainer.DeleteFavorite(favorite);

            // Assert
            Assert.AreEqual(2, favoriteSTUB.fakeFavorites.Count);
            Assert.IsFalse(favoriteSTUB.fakeFavorites.Any(s => s.Symbol == favorite.Symbol && s.AccountID == favorite.AccountID && s.StockID == favorite.StockID));
        }


        [TestMethod]
        public void DeleteStock(AccountStockDTO accountStockDTO)
        {
            // Arrange
            AccountStock accountStock = new AccountStock(
                accountStockDTO.StockID,
                accountStockDTO.Date,
                accountStockDTO.Symbol,
                accountStockDTO.AccountID);
            StockSTUB accountStockSTUB = new StockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), accountStockSTUB);

            // Act
            alphaVantageContainer.DeleteStock(accountStock);

            // Assert
            Assert.AreEqual(2, accountStockSTUB.FakeAccountStocks.Count);
            Assert.IsFalse(accountStockSTUB.FakeAccountStocks.Any(s => s.Symbol == accountStock.Symbol && s.AccountID == accountStock.AccountID && s.StockID == accountStock.StockID && s.Date == accountStock.Date));
        }

        [TestMethod]
        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            // Arrange
            AccountID = 10;
            StockSTUB accountStockSTUB = new StockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), accountStockSTUB);

            // Act
            List<AccountStock> list = alphaVantageContainer.GetAccountStockList(AccountID);

            // Assert
            var expectedList = accountStockSTUB.GetAccountStockList(AccountID);

            Assert.AreEqual(expectedList.Count, list.Count);

            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i].StockID, list[i].StockID);
                Assert.AreEqual(expectedList[i].Date, list[i].Date);
                Assert.AreEqual(expectedList[i].Symbol, list[i].Symbol);
                Assert.AreEqual(expectedList[i].AccountID, list[i].AccountID);
            }
            return expectedList;
        }

        [TestMethod]
        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
        {
            // Arrange
            AccountID = 10;
            StockSTUB accountStockSTUB = new StockSTUB();
            StockSTUB stockSTUB = new StockSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), accountStockSTUB);
            
            APIResponseCall aPIResponseCall = new APIResponseCall(aPIResponseCallDTO.StockID, aPIResponseCallDTO.Date, aPIResponseCallDTO.Symbol, aPIResponseCallDTO.Open, aPIResponseCallDTO.High, aPIResponseCallDTO.Low, aPIResponseCallDTO.Close, aPIResponseCallDTO.Volume);

            // Act
            alphaVantageContainer.AddStock(aPIResponseCall, AccountID);

            // Assert
            Assert.AreEqual(5, stockSTUB.CreateFakeAPIResponseCall.StockID);
            Assert.AreEqual("KO", stockSTUB.CreateFakeAPIResponseCall.Symbol);
            Assert.AreEqual(10, stockSTUB.CreateFakeAPIResponseCall.StockID);
        }
    }
}
