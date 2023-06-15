using Business;
using Business.Class;
using Data;
using Interface;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;
using WebApp.Models;

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

        public List<AccountStockModel> ToModel(List<AccountStock> accountStocks)
        {
            List<AccountStockModel> accountStockModels = new List<AccountStockModel>();

            foreach (var accountStock in accountStocks)
            {
                AccountStockModel accountStockModel = new AccountStockModel(
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

            List<AccountStockModel> accountStockModels = ToModel(accountStocks);

            AccountStockViewModel accountStockViewModel = new AccountStockViewModel(accountStockModels);

            return PartialView("StockAccountTable", accountStockViewModel);
        }

        [HttpPost]
        public IActionResult DeleteStock(AccountStockModel accountStockModel)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            AccountStock accountStock = new AccountStock(
                accountStockModel.StockID,
                accountStockModel.Date,
                accountStockModel.Symbol,
                AccountID);

            _alphaVantageContainer.DeleteStock(accountStock);
            return RedirectToAction("AccountStock", "AccountStock");
            
        }  
    }
}
