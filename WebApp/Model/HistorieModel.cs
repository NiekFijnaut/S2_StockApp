namespace WebApp.Model
{
    public class HistorieModel
    {
        public long? HistorieID { get; set; }
        public DateTime Date { get; }
        public string Symbol { get; }
        public double Open { get; }
        public double High { get; }
        public double Low { get; }
        public double Close { get; }
        public int Volume { get; }


        public HistorieModel(DateTime date, string symbol, double open, double high, double low, double close, int volume)
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
