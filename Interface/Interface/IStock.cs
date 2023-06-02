using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IStock
    {
        void AddStock(APIResponseCallDTO aPIResponseCallDTO, AccountStockDTO accountStockDTO);
        List<AccountStockDTO> GetAccountStockList();
        //void AddStockToAccount(SearchDTO searchDTO);
        void UpdateStockTable(APIResponseCallDTO aPIResponseCallDTO);
        void DeleteStock(string symbol);
    }
}
