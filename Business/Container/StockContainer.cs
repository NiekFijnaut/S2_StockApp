using Business.Class;
using Data;
using Interface;
using Interface.DTO;
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
        public void AddStock(Stock stock, APIResponseCall aPIResponseCall, AccountStock accountStock)
        {
            Interface.APIResponseCallDTO stockDTO = new Interface.APIResponseCallDTO(
                stock.StockID, 
                stock.Date,
                stock.Symbol,
                stock.Open, 
                stock.High,
                stock.Low, 
                stock.Close,
                stock.Volume);

            Interface.DTO.APIResponseCallDTO aPIResponseCallDTO = new Interface.DTO.APIResponseCallDTO(
                aPIResponseCall.StockID,
                aPIResponseCall.Date,
                aPIResponseCall.Symbol,
                aPIResponseCall.Open,
                aPIResponseCall.High,
                aPIResponseCall.Low,
                aPIResponseCall.Close,
                aPIResponseCall.Volume);

            AccountStockDTO accountStockDTO = new AccountStockDTO(
                accountStock.StockID,
                accountStock.Date,
                accountStock.Symbol,
                accountStock.AccountID);
            
            stockDAL.AddStock(stockDTO, aPIResponseCallDTO, accountStockDTO);
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

        public void UpdateStockTable(Interface.APIResponseCallDTO stockDTO)
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
