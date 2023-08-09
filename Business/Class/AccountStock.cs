using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class AccountStock
    {
        public long StockID { get; }
        public DateTime Date { get; }
        public string Symbol { get; }
        public int AccountID { get; }

        public AccountStock(long stockID, DateTime date, string symbol, int accountID)
        {
            StockID = stockID;
            Date = date;
            Symbol = symbol;
            AccountID = accountID;
        }
    }
}
