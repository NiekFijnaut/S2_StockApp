using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAlphaVantage
    {
        Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO);
        //List<AccountStockDTO> GetAccountStockList(int AccountID);
        Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO);
        
    }
}
