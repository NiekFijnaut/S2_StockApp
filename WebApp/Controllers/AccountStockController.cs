using Business;
using Business.Class;
using Data;
using Interface;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountStockController : Controller
    {
        private AlphaVantageContainer _alphaVantageContainer;

        public AccountStockController()
        {
            _alphaVantageContainer = new AlphaVantageContainer(new AlphaVantageDAL(), new StockDAL());
        }

        [HttpGet]
        public IActionResult AccountStock()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public List<AccountStockViewModel> ToModel(List<AccountStock> accountStocks)
        {
            List<AccountStockViewModel> accountStockModels = new List<AccountStockViewModel>();

            foreach (var accountStock in accountStocks)
            {
                AccountStockViewModel accountStockModel = new AccountStockViewModel(
                    accountStock.StockID,
                    accountStock.Date,
                    accountStock.Symbol,
                    accountStock.AccountID);
                accountStockModels.Add(accountStockModel);
            }
            return accountStockModels;
        }

        [HttpGet]
        public IActionResult GetAccountStock() 
        {
            AccountViewModel accountViewModel = new AccountViewModel();

            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            accountViewModel.AccountID = AccountID;

            List<AccountStock> accountStocks = _alphaVantageContainer.GetAccountStockList(AccountID);

            List<AccountStockViewModel> accountStockModels = ToModel(accountStocks);

            AccountStockViewModelList accountStockViewModel = new AccountStockViewModelList(accountStockModels);

            return PartialView("StockAccountTable", accountStockViewModel);
        }

        [HttpPost]
        public IActionResult DeleteStock(AccountStockViewModel accountStockModel)
        {
            if(ModelState.IsValid)
            {
                int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

                AccountStock accountStock = new AccountStock(
                    accountStockModel.StockID,
                    accountStockModel.Date,
                    accountStockModel.Symbol,
                    AccountID);

                _alphaVantageContainer.DeleteStock(accountStock);
                
            }
            return RedirectToAction("AccountStock", "AccountStock");
        }  
    }
}
