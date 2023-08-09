using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{ 
    public class APIResponseCall
    {
        public long? StockID { get; }
        public DateTime Date { get; }
        public string Symbol { get; }
        public double Open { get; }
        public double High { get; }
        public double Low { get; }
        public double Close { get; }
        public int Volume { get; }


        public APIResponseCall(long? stockID, DateTime date, string symbol, double open, double high, double low, double close, int volume)
        {
            StockID = stockID;
            Date = date;
            Symbol = symbol;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

    }
}
