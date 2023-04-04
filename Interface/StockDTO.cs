﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public record StockDTO(
        long StockID,
        DateTime Date,
        string Symbol, 
        double Open,
        double High,
        double Low,
        double Close,
        int Volume);
}
