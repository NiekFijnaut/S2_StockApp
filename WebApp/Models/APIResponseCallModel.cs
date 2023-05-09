namespace WebApp.Models
{
    public class APIResponseCallModel
    {
        public long StockID { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public int Volume { get; set; }

        public APIResponseCallModel(DateTime date, string symbol, double open, double high, double low, double close, int volume)
        {
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
