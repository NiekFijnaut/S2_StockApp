using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StockHistorie : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        //public IActionResult Historie() 
        //{
        //    private const string APIKEY = "ZN0C9Q4C0LG3REEE";

        //    private const string BaseUrl = "https://www.alphavantage.co/query";

        //    string ApiFunction = "TIME_SERIES_INTRADAY_EXTENDED";

        //}
    }
}
