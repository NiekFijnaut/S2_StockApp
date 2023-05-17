using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IALphaVantage
    {
        Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO);
        Task<List<AccountStockDTO>> AddStockToAccount(string Symbol, string ddlInterval);
    }
}
