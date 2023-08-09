using Business;
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
    public class StockSTUB : IStock
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

        public List<AccountStock> FakeAccountStock = new List<AccountStock>();

        public AccountStockDTO CreateFakeAccountStock;

        public bool Create(AccountStockDTO accountStockDTO)
        {
            CreateFakeAccountStock = accountStockDTO;

            if (accountStockDTO == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AccountStockDTO> FakeAccountStocks = new List<AccountStockDTO>()
        {
            new AccountStockDTO(
                1,
                new DateTime (2023,06,12,11,30,30),
                "AAPL",
                10),
            new AccountStockDTO(
                2,
                new DateTime (2023,06,12,11,30,30),
                "GOOG",
                10),
            new AccountStockDTO(
                3,
                new DateTime (2023,06,12,11,30,30),
                "MSFT",
                10)
        };

        public void DeleteStock(AccountStockDTO accountStockDTO)
        {
            AccountStockDTO stock = FakeAccountStocks.FirstOrDefault(s => s.Symbol == accountStockDTO.Symbol && s.AccountID == accountStockDTO.AccountID && s.StockID == accountStockDTO.StockID && s.Date == accountStockDTO.Date);
            if (stock != null)
            {
                FakeAccountStocks.Remove(stock);
            }
        }

        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            return FakeAccountStocks;
        }

        public List<APIResponseCall> FakeAPIResponseCall = new List<APIResponseCall>();

        public APIResponseCallDTO CreateFakeAPIResponseCall;

        public bool Create(APIResponseCallDTO aPIResponseCallDTO)
        {
            CreateFakeAPIResponseCall = aPIResponseCallDTO;

            if (aPIResponseCallDTO == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
        {
            List<APIResponseCallDTO> aPIResponseCallDTOs = FakeAPIResponseCalls;
        }

        List<APIResponseCallDTO> FakeAPIResponseCalls = new List<APIResponseCallDTO>()
        {
            new APIResponseCallDTO(
                1,
                new DateTime(2023, 06, 12, 11, 30, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
            new APIResponseCallDTO(
                1,
                new DateTime(2023, 06, 12, 11, 15, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
            new APIResponseCallDTO(
                1,
                new DateTime(2023, 06, 12, 10, 00, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
        };
    }
}
