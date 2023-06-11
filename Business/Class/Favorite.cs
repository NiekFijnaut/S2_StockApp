using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class Favorite
    {
        public long? StockID { get; set; }
        
        public string Symbol { get; set; }
        public int? AccountID { get; set; }

        public Favorite(string symbol)
        {
            Symbol = symbol;
        }
    }
}
