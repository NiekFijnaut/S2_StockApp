using Business.Class;
using Interface;
using Interface.DTO;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.STUB
{
    public class AccountStockSTUB : IStock
    {
        public List<AccountStock> FakeAccountStock = new List<AccountStock>();

        public AccountStockDTO CreateFakeAccountStock;

        public bool Create(AccountStockDTO accountStockDTO)
        {
            CreateFakeAccountStock= accountStockDTO;

            if(accountStockDTO == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int AccountID = 10;

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

        public void DeleteStock(string symbol, int accountID)
        {
            AccountStockDTO stock = FakeAccountStocks.FirstOrDefault(s => s.Symbol == symbol && s.AccountID == accountID);
            if (stock != null)
            {
                FakeAccountStocks.Remove(stock);
            }
        }

        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            return FakeAccountStocks;
        }

        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
        {
            throw new NotImplementedException();
        }

        public void AddToFavorite(int AccountID, string Symbol)
        {
            throw new NotImplementedException();
        }

        public List<FavoriteDTO> GetFavoriteList(int AccountID)
        {
            throw new NotImplementedException();
        }

        public void DeleteFavorite(string Symbol, int AccountID)
        {
            throw new NotImplementedException();
        }
    }
}
