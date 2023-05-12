namespace WebApp.Models
{
    public class AccountStockModel
    {
        public long? StockID { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public long? AccountID { get; set; }

        public AccountStockModel() { }

        public AccountStockModel(DateTime date, string symbol)
        {
            Date = date;
            Symbol = symbol;
        }
    }
}
