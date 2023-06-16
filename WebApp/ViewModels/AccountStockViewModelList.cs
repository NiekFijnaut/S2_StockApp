
namespace WebApp.ViewModels
{
    public class AccountStockViewModelList
    {
        public List<AccountStockViewModel> AccountStockModels { get; set; }

        public AccountStockViewModelList() { }

        public AccountStockViewModelList(List<AccountStockViewModel> accountStockModels)
        {
            AccountStockModels = accountStockModels;
        }
    }
}
