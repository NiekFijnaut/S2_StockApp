using Business.Class;
using Interface;
using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.STUB
{
    public class FavoriteSTUB : IStock
    {
        public List<Favorite> FakeFavorite = new List<Favorite>();

        public FavoriteDTO CreateFakeFavoriteDTO;

        public void AddFavorite(FavoriteDTO favoriteDTO)
        {
            CreateFakeFavoriteDTO = favoriteDTO;
        }

        public List<FavoriteDTO> fakeFavorites = new List<FavoriteDTO>()
        {
            new FavoriteDTO(
                1,
                "AAPL",
                10),
            new FavoriteDTO(
                2,
                "GOOG",
                10),
            new FavoriteDTO(
                3,
                "MSFT",
                10)
        };

        public List<FavoriteDTO> GetFavoriteList(int AccountID)
        {
            return fakeFavorites;
        }

        public void DeleteFavorite(string symbol, int accountID)
        {
            FavoriteDTO stock = fakeFavorites.FirstOrDefault(s => s.Symbol == symbol && s.AccountID == accountID);
            if (stock != null)
            {
                fakeFavorites.Remove(stock);
            }
        }

        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
        {
            throw new NotImplementedException();
        }

        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            throw new NotImplementedException();
        }

        public void DeleteStock(string symbol, int AcountID)
        {
            throw new NotImplementedException();
        }

        public void AddToFavorite(int AccountID, string Symbol)
        {
            throw new NotImplementedException();
        }

        
    }
}
