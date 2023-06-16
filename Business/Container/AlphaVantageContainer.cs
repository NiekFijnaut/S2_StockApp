using Business.Class;
using Data;
using Interface;
using Interface.DTO;
using Interface.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    
    public class AlphaVantageContainer
    {
        private IAlphaVantage _alphaVantage;
        private IStock _stock;

        public AlphaVantageContainer(IAlphaVantage aLphaVantage, IStock stock)
        {
            _alphaVantage = aLphaVantage;
            _stock = stock;
        }

        public void AddStock(APIResponseCall aPIResponseCall, int AccountID)
        {
            try
            {
                APIResponseCallDTO aPIResponseCallDTO = new APIResponseCallDTO(
            null,
            aPIResponseCall.Date,
            aPIResponseCall.Symbol,
            aPIResponseCall.Open,
            aPIResponseCall.High,
            aPIResponseCall.Low,
            aPIResponseCall.Close,
            aPIResponseCall.Volume
            );

                _stock.AddStock(aPIResponseCallDTO, AccountID);
            }
            catch
            {
                throw new Exception("Cannot add stock to account");
            }
                 
        }

        public void AddToFavorite(Favorite favorite)
        {
            try
            {
                FavoriteDTO favoriteDTO = new FavoriteDTO(
                favorite.StockID,
                favorite.Symbol,
                favorite.AccountID
                );
                _stock.AddToFavorite(favoriteDTO);
            }
            catch
            {
                throw new Exception("Cannot add stock to favorite");
            }
        }

        public List<Favorite> GetFavoriteList(int AccountID)
        {
            
            List<Favorite> favorites = new List<Favorite>();
            List<FavoriteDTO> favoriteDTOs = _stock.GetFavoriteList(AccountID);
            foreach (FavoriteDTO favoriteDTO in favoriteDTOs)
            {
                favorites.Add(
                    new Favorite(
                        favoriteDTO.StockID,
                        favoriteDTO.Symbol,
                        favoriteDTO.AccountID
                        ));
            }
            return favorites;
            
        }

        public async Task<List<APIResponseCall>> SearchStock(Search search)
        {
            try
            {
                SearchDTO searchDTO = new SearchDTO(
            search.Symbol,
            search.Interval,
            null);

                List<APIResponseCall> aPIResponses = new List<APIResponseCall>();
                List<APIResponseCallDTO> aPIResponseCallDTOs = await _alphaVantage.SearchStock(searchDTO);
                foreach (APIResponseCallDTO aPIResponseCallDTO in aPIResponseCallDTOs)
                {
                    aPIResponses.Add(
                        new APIResponseCall(
                            null,
                            aPIResponseCallDTO.Date,
                            aPIResponseCallDTO.Symbol,
                            aPIResponseCallDTO.Open,
                            aPIResponseCallDTO.High,
                            aPIResponseCallDTO.Low,
                            aPIResponseCallDTO.Close,
                            aPIResponseCallDTO.Volume
                            ));
                }
                return aPIResponses;
            }
            catch
            {
                throw new Exception("cannot search stock intel");
            }
            
        }

        public void DeleteStock(AccountStock accountStock)
        {
            AccountStockDTO accountStockDTO = new AccountStockDTO(
            accountStock.StockID,
            accountStock.Date,
            accountStock.Symbol,
            accountStock.AccountID);
            _stock.DeleteStock(accountStockDTO);
            
        }

        public void DeleteFavorite(Favorite favorite)
        {
            FavoriteDTO favoriteDTO = new FavoriteDTO(
                favorite.StockID,
                favorite.Symbol,
                favorite.AccountID);
            _stock.DeleteFavorite(favoriteDTO);
        }

        public List<AccountStock> GetAccountStockList(int AccountID)
        {
            List<AccountStock> accountStock = new List<AccountStock>();
            List<AccountStockDTO> accountStockDTOList = _stock.GetAccountStockList(AccountID);
            foreach (AccountStockDTO accountStockDTO in accountStockDTOList)
            {
                accountStock.Add(
                    new AccountStock(
                        accountStockDTO.StockID,
                        accountStockDTO.Date,
                        accountStockDTO.Symbol,
                        accountStockDTO.AccountID
                        ));
            }
            return accountStock;
        }
    }
}
