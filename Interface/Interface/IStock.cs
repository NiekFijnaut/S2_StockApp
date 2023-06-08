using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IStock
    {
        void AddStock(APIResponseCallDTO aPIResponseCallDTO, int? AccountID);
        List<AccountStockDTO> GetAccountStockList(int AccountID);
        //void AddStockToAccount(SearchDTO searchDTO);
        //void UpdateStockTable(APIResponseCallDTO aPIResponseCallDTO);
        void DeleteStock(string symbol);
    }
}
