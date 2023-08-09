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
        void DeleteStock(AccountStockDTO accountStockDTO);
        void AddToFavorite(FavoriteDTO favoriteDTO);
        List<FavoriteDTO> GetFavoriteList(int AccountID);
        void DeleteFavorite(FavoriteDTO favoriteDTO);
    }
}
