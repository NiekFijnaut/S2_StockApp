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
            catch(Exception ex)
            {
                if(ex.Message == "Stock cannot be added")
                {
                    throw;
                }
            }            
        }

        public void AddToFavorite(int AccountID, string Symbol)
        {
            try
            {
                _stock.AddToFavorite(AccountID, Symbol);
            }
            catch(Exception ex)
            {
                if(ex.Message == "Stock cannot be added to favorite")
                {
                    throw;
                }
            }
        }

        public List<Favorite> GetFavoriteList(int AccountID)
        {
            try
            {
                List<Favorite> favorites = new List<Favorite>();
                List<FavoriteDTO> favoriteDTOs = _stock.GetFavoriteList(AccountID);
                foreach (FavoriteDTO favoriteDTO in favoriteDTOs)
                {
                    favorites.Add(
                        new Favorite(
                            favoriteDTO.Symbol
                            ));
                }
                return favorites;
            }
            catch(Exception ex)
            {
                if(ex.Message == "Favorite list cannot be received")
                {
                    throw;
                }
                return null;
            }
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
            catch(Exception ex)
            {
                if (ex.Message == "StockIntel cannot be received")
                {
                    throw;
                }
                return null;
            }
        }

        public void DeleteStock(string Symbol, int AccountID)
        {
            try
            {
                _stock.DeleteStock(Symbol, AccountID);
            }
            catch(Exception ex)
            {
                if (ex.Message == "Stock cannot be deleted")
                {
                    throw;
                }
            }
        }

        public void DeleteFavorite(string Symbol, int AccountID)
        {
            try
            {
                _stock.DeleteFavorite(Symbol, AccountID);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Stock cannot be deleted from favorites")
                {
                    throw;
                }
            }
        }

        public List<AccountStock> GetAccountStockList(int AccountID)
        {
            try
            {
                List<AccountStock> accountStock = new List<AccountStock>();
                List<AccountStockDTO> accountStockDTOList = _stock.GetAccountStockList(AccountID);
                foreach (AccountStockDTO accountStockDTO in accountStockDTOList)
                {
                    accountStock.Add(
                        new AccountStock(
                            accountStockDTO.Date,
                            accountStockDTO.Symbol
                            ));
                }
                return accountStock;
            }
            catch(Exception ex )
            {
                if(ex.Message == "AccountStocks cannot be received")
                {
                    throw;
                }
                return null;
            }
        }
    }
}
