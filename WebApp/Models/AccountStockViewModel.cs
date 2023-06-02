using Business.Class;

namespace WebApp.Models
{
    public class AccountStockViewModel
    {
        public List<AccountStock> AccountStocks { get; set; }

        public AccountStockViewModel() { }

        public AccountStockViewModel(List<AccountStock> accountStocks)
        {
            AccountStocks = accountStocks;
        }
    }
}
