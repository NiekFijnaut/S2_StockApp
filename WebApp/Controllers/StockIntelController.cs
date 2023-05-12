//using Business;
//using Business.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Globalization;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StockIntelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StockIntel()
        {
            return View();
        }

        //[HttpPost]
    }
}
/*
else
{
    return BadRequest("Time series data not available.");
}
                
else
{
    return BadRequest($"API request failed with status code: {response.StatusCode}");
}
*/