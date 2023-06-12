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
        private IAlphaVantage _alphaVantage;
        private IStock _stock;
        private AlphaVantageContainer _alphaVantageContainer;

        public AccountStockController(IAlphaVantage alphaVantage, IStock stock)
        {
            _alphaVantage= alphaVantage;
            _stock= stock;
            _alphaVantageContainer = new AlphaVantageContainer(_alphaVantage, _stock);
        }

        [HttpGet]
        public IActionResult AccountStock()
        {
            return View();
        }
 

        [HttpGet]
        public IActionResult GetAccountStock() 
        {
            try
            {
                AccountViewModel accountViewModel = new AccountViewModel();
                int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;
                accountViewModel.AccountID = AccountID;
                List<AccountStock> accountStocks = _alphaVantageContainer.GetAccountStockList(AccountID);

                AccountStockViewModel accountStockViewModel = new AccountStockViewModel(accountStocks);

                return PartialView("StockAccountTable", accountStockViewModel);
            }
            catch(Exception ex)
            {
                string errorMessage = ex.Message;
                return View("AccountStock", errorMessage);
            }
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
