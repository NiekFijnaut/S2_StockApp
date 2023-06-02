using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Search
    {
        public string Symbol { get; set; }
        public string Interval { get; set; }

        public Search(string symbol, string interval)
        {
            Symbol = symbol;
            Interval = interval;
        }

        public Search()
        {
        }
    }
}
