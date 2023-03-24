using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public record StockDTO(string Name, string Ticker, float Price, int Volume);
}
