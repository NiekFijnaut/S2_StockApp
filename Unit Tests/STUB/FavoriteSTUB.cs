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

        public void AddToFavorite(FavoriteDTO favoriteDTO)
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

        public void DeleteFavorite(FavoriteDTO favoriteDTO)
        {
            FavoriteDTO favorite = fakeFavorites.FirstOrDefault(s => s.StockID == favoriteDTO.StockID && s.Symbol == favoriteDTO.Symbol && s.AccountID == favoriteDTO.AccountID);
            if (favorite != null)
            {
                fakeFavorites.Remove(favorite);
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

        public void DeleteStock(AccountStockDTO accountStockDTO)
        {
            throw new NotImplementedException();
        }

        public void AddToFavorite(int AccountID, string Symbol)
        {
            throw new NotImplementedException();
        }

        
    }
}
