﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public record AccountStockDTO(
        long StockID,
        DateTime Date,
        string Symbol,
        int AccountID);
}
