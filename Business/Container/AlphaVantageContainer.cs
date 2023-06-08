using Business.Class;
using Data;
using Interface;
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

        public AlphaVantageContainer(IAlphaVantage aLphaVantage)
        {
            _alphaVantage = aLphaVantage;
        }

        public StockDAL stockDAL = new StockDAL();
        public AlphaVantageDAL alphaVantageDAL = new AlphaVantageDAL();

        public void AddStock(APIResponseCall aPIResponseCall, int? AccountID)
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
            
            stockDAL.AddStock(aPIResponseCallDTO, AccountID);
        }

        public List<APIResponseCall> GetAPIResponseCalls()
        {
            List<APIResponseCall> aPIResponseCall = new List<APIResponseCall>();
            List<APIResponseCallDTO> aPIResponseCallDTOs = alphaVantageDAL.GetAPIResponseCallList();
            foreach (APIResponseCallDTO aPIResponseCallDTO in aPIResponseCallDTOs)
            {
                aPIResponseCall.Add(
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
            return aPIResponseCall;
        }

        public List<AccountStock> GetAccountStock(int AccountID)
        {
            List<AccountStock> accountStocks= new List<AccountStock>();
            List<AccountStockDTO> accountStockDTOs= stockDAL.GetAccountStockList(AccountID);
            foreach (AccountStockDTO accountStockDTO in accountStockDTOs)
            {
                accountStocks.Add(
                    new AccountStock(
                        accountStockDTO.Date,
                        accountStockDTO.Symbol
                        ));
            }
            return accountStocks;
        }

        public async Task<List<APIResponseCall>> SearchStock(Search search)
        {
            SearchDTO searchDTO = new SearchDTO(
                search.Symbol,
                search.Interval,
                null);

            List<APIResponseCall> aPIResponses = new List<APIResponseCall>();
            List<APIResponseCallDTO> aPIResponseCallDTOs = await alphaVantageDAL.SearchStock(searchDTO);
            foreach(APIResponseCallDTO aPIResponseCallDTO in aPIResponseCallDTOs)
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

         
        public void DeleteStock(string Symbol)
        {
            try
            {
                stockDAL.DeleteStock(Symbol);
            }
            catch(Exception ex)
            {
                if (ex.Message == "There are no stocks added to this account")
                {
                    throw;
                }
            }
        }

        //public void UpdateStockTable(APIResponseCallDTO aPIResponseCallDTO)
        //{
        //    stockDAL.UpdateStockTable(aPIResponseCallDTO);
        //}

        public List<AccountStock> GetAccountStockList(int AccountID)
        {
            List<AccountStock> accountStock = new List<AccountStock>();
            List<AccountStockDTO> accountStockDTOList = stockDAL.GetAccountStockList(AccountID);
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
    }
}
