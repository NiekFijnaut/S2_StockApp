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
            List<AccountStock> accountStocks = alphaVantageContainer.GetAccountStockList();

            AccountStockViewModel accountStockViewModel = new AccountStockViewModel(accountStocks);

            return PartialView("StockAccountTable", accountStockViewModel);
        }
    }
}
