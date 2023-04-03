using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Stock
    {
        public long StockID { get; set; }
        public double AdjustedClose { get; set; }
        public string Date { get; set; }
        public string Symbol { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double DividendAmount { get; set; }
        public int Volume { get; set; }

        public Stock(double adjustedClose, string date, string symbol, double open, double high, double low, double close, double dividendAmount, int volume)
        {
            AdjustedClose= adjustedClose;
            Date= date; 
            Symbol= symbol;
            Open= open;
            High= high;
            Low= low;
            Close= close;
            DividendAmount= dividendAmount;
            Volume= volume;

        }
    }
}
