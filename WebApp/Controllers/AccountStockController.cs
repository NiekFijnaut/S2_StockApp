using Business;
using Business.Class;
using Data;
using Interface;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpGet]
        public IActionResult GetAccountStock() 
        {
            AccountViewModel accountViewModel = new AccountViewModel();
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;
            accountViewModel.AccountID = AccountID;
            List<AccountStock> accountStocks = _alphaVantageContainer.GetAccountStockList(AccountID);

            AccountStockViewModel accountStockViewModel = new AccountStockViewModel(accountStocks);

            return PartialView("StockAccountTable", accountStockViewModel);
        }

        [HttpPost]
        public IActionResult DeleteStock(string Symbol)
        {
           
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;
            _alphaVantageContainer.DeleteStock(Symbol, AccountID);
            return RedirectToAction("AccountStock", "AccountStock");
            
        }  
    }
}
