using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IALphaVantage
    {
        void SearchStock(string Symbol, string ddlInterval);
        void AddStockToAccount(string Symbol, string ddlInterval);
    }
}
