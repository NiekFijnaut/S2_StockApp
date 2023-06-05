﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public class AccountStock
    {
        public long? StockID { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public long? AccountID { get; set; }

        public AccountStock()
        {

        }
        public AccountStock(DateTime date, string symbol)
        {
            Date = date;
            Symbol = symbol;
        }
    }
}