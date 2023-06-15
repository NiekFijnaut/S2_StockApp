
using WebApp.Model;

namespace WebApp.Models
{
    public class AccountStockViewModel
    {
        public List<AccountStockModel> AccountStockModels { get; set; }

        public AccountStockViewModel() { }

        public AccountStockViewModel(List<AccountStockModel> accountStockModels)
        {
            AccountStockModels = accountStockModels;
        }
    }
}
