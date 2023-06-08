using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public record HistorieDTO
        (long? HistorieID,
        DateTime Date,
        string Symbol,
        double Open,
        double High,
        double Low,
        double Close,
        int Volume);
}
