using Business;
using Business.Class;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountStockController : Controller
    {
        [HttpGet]
        public IActionResult AccountStock()
        {
            return View();
        }

        AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new StockDAL());

        [HttpGet]
        public IActionResult GetAccountStock() 
        {
            AccountViewModel accountViewModel = new AccountViewModel();
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;
            accountViewModel.AccountID = AccountID;
            List<AccountStock> accountStocks = alphaVantageContainer.GetAccountStockList(AccountID);

            AccountStockViewModel accountStockViewModel = new AccountStockViewModel(accountStocks);

            return PartialView("StockAccountTable", accountStockViewModel);
        }

        [HttpPost]
        public IActionResult DeleteStock(string Symbol)
        { 
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;
            alphaVantageContainer.DeleteStock(Symbol, AccountID);
            return RedirectToAction("AccountStock", "AccountStock"); 
        }  
    }
}
