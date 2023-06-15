namespace WebApp.Model
{
    public class APIResponseCallModel
    {
        public long? StockID { get; }
        public DateTime Date { get; }
        public string Symbol { get; }
        public double Open { get; }
        public double High { get; }
        public double Low { get; }
        public double Close { get; }
        public int Volume { get; }



        public APIResponseCallModel(long? stockID, DateTime date, string symbol, double open, double high, double low, double close, int volume)
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
