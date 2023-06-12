using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IStock
    {
        void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID);
        List<AccountStockDTO> GetAccountStockList(int AccountID);
        void DeleteStock(string symbol, int AcountID);
        void AddToFavorite(int AccountID, string Symbol);
        List<FavoriteDTO> GetFavoriteList(int AccountID);
        void DeleteFavorite(string Symbol, int AccountID);
    }
}
