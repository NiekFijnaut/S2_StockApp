namespace WebApp.Model
{
    public class FavoriteModel
    {
        public long StockID { get; }
        public string Symbol { get; }
        public int AccountID { get; }

        public FavoriteModel()
        {

        }
        public FavoriteModel(long stockID, string symbol, int accountID)
        {
            StockID = stockID;
            Symbol = symbol;
            AccountID = accountID;
        }
    }
}
