namespace WebApp.ViewModels
{
    public class AccountStockViewModel
    {
        public long StockID { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public int AccountID { get; set; }

        public AccountStockViewModel()
        {

        }
        public AccountStockViewModel(long stockID, DateTime date, string symbol, int accountID)
        {
            StockID = stockID;
            Date = date;
            Symbol = symbol;
            AccountID = accountID;
        }
    }
}
