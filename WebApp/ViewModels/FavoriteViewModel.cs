namespace WebApp.ViewModels
{
    public class FavoriteViewModel
    {
        public long StockID { get; set; }
        public string Symbol { get; set; }
        public int AccountID { get; set; }

        public FavoriteViewModel()
        {

        }
        public FavoriteViewModel(long stockID, string symbol, int accountID)
        {
            StockID = stockID;
            Symbol = symbol;
            AccountID = accountID;
        }
    }
}
