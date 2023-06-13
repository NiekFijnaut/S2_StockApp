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
    public class FavoriteTest : IStock
    {
        [TestMethod]
        public void GetFavoriteListTest()
        {
            // Arrange
            int AccountID = 10;
            FavoriteSTUB favoriteSTUB = new FavoriteSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), favoriteSTUB);
            List<FavoriteDTO> expected = favoriteSTUB.fakeFavorites;

            // Act
            List<Favorite> list = alphaVantageContainer.GetFavoriteList(AccountID);

            // Assert
            Assert.AreEqual(expected.Count, list.Count);
        }

        public void AddToFavorite(int AccountID, string Symbol)
        {
            // Arrange
            FavoriteSTUB favoriteSTUB = new FavoriteSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), favoriteSTUB);

            // Act
            alphaVantageContainer.AddToFavorite(AccountID, Symbol);

            // Assert
            Assert.AreEqual(1, favoriteSTUB.CreateFakeFavoriteDTO.StockID);
            Assert.AreEqual("AAPL", favoriteSTUB.CreateFakeFavoriteDTO.Symbol);
            Assert.AreEqual(10, favoriteSTUB.CreateFakeFavoriteDTO.AccountID);
        }

        public void DeleteFavorite(string Symbol, int AccountID)
        {
            throw new NotImplementedException();
        }

        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
        {
            throw new NotImplementedException();
        }      

        public void DeleteStock(string symbol, int AcountID)
        {
            throw new NotImplementedException();
        }

        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            throw new NotImplementedException();
        }

        public List<FavoriteDTO> GetFavoriteList(int AccountID)
        {
            throw new NotImplementedException();
        }
    }
}
