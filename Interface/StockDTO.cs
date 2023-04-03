using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public record StockDTO(
        long StockID, 
        double AdjustedClose,
        string Date,
        string Symbol, 
        double Open,
        double High,
        double Low,
        double Close,
        double DividendAmount, 
        int Volume);
}
