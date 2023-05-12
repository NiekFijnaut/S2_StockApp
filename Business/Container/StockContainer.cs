using Business.Class;
using Data;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StockContainer
    {
        public StockDAL stockDAL = new StockDAL();
        public AlphaVantageDAL alphaVantageDAL = new AlphaVantageDAL();
        public void AddStock(Stock stock, APIResponseCall aPIResponseCall, AccountStock accountStock)
        {
            APIResponseCallDTO aPIResponseCallDTO = new APIResponseCallDTO(aPIResponseCall.StockID,
                aPIResponseCall.Date,
                aPIResponseCall.Symbol,
                aPIResponseCall.Open,
                aPIResponseCall.High,
                aPIResponseCall.Low,
                aPIResponseCall.Close,
                aPIResponseCall.Volume
                );

            StockDTO stockDTO = new StockDTO(
                stock.StockID,
                stock.Date,
                stock.Symbol,
                stock.Open,
                stock.High,
                stock.Low,
                stock.Close,
                stock.Volume
                );

            AccountStockDTO accountStockDTO = new AccountStockDTO(
                accountStock.StockID,
                accountStock.Date,
                accountStock.Symbol,
                accountStock.AccountID);
            
            stockDAL.AddStock(stockDTO, aPIResponseCallDTO, accountStockDTO);
        }

        //public List<APIResponseCall> GetAPIResponse()
        //{
        //    List<APIResponseCall> aPIResponseCall = new List<APIResponseCall>();
        //    List<APIResponseCallDTO> aPIResponseCallDTOs = alphaVantageDAL.GetAPIResponse();
        //}

        public void SearchStock(Search search)
        {
            SearchDTO searchDTO = new SearchDTO(
                search.Symbol,
                search.Interval);

            alphaVantageDAL.SearchStock(searchDTO);
        }

        public void DeleteStock(ulong StockID)
        {
            try
            {
                stockDAL.DeleteStock(StockID);
            }
            catch(Exception ex)
            {
                if (ex.Message == "There are no stocks added to this account")
                {
                    throw;
                }
            }
        }

        public void UpdateStockTable(StockDTO stockDTO)
        {
            stockDAL.UpdateStockTable(stockDTO);
        }

        public List<AccountStock> GetAccountStockList()
        {
            List<AccountStock> accountStock = new List<AccountStock>();
            List<AccountStockDTO> accountStockDTOList = stockDAL.GetAccountStockList();
            foreach (AccountStockDTO accountStockDTO in accountStockDTOList)
            {
                accountStock.Add(
                    new AccountStock(
                        accountStockDTO.Date,
                        accountStockDTO.Symbol));
            }
            return accountStock;
        }
    }
}
