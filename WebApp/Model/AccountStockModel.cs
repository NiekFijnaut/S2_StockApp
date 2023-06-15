namespace WebApp.Model
{
    public class AccountStockModel
    {
        public long StockID { get; }
        public DateTime Date { get; }
        public string Symbol { get; }
        public int AccountID { get; }

        public AccountStockModel()
        {

        }
        public AccountStockModel(long stockID, DateTime date, string symbol, int accountID)
        {
            StockID = stockID;
            Date = date;
            Symbol = symbol;
            AccountID = accountID;
        }
    }
}
