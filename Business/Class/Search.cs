﻿using System;
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
        public string Slice { get; set; }

        public Search(string symbol, string interval, string slice)
        {
            Symbol = symbol;
            Interval = interval;
            Slice = slice;
        }
    }
}
