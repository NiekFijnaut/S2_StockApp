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
        public string Name { get; set; }
        public string Ticker { get; set; }
        public float Price { get; set; }
        public int Volume { get; set; }

        public Stock(string name, string ticker, float price, int volume)
        {
            Name= name;
            Ticker= ticker;
            Price= price;
            Volume= volume;
        }
    }
}
