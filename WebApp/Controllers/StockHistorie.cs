using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StockHistorie : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Historie() 
        {
            return View();
        }
    }
}
