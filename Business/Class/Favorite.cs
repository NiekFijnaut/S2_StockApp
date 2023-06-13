﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class Favorite
    {
        public long? StockID { get; }
        public string Symbol { get; }
        public int? AccountID { get; }

        public Favorite(string symbol)
        {
            Symbol = symbol;
        }
    }
}
