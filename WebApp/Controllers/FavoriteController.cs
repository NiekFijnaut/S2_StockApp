using Business.Class;
using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Favorite()
        {
            return View();
        }

        AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new StockDAL());

        [HttpGet]
        public IActionResult GetFavorite(AccountViewModel accountViewModel)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            List<Favorite> favorites = alphaVantageContainer.GetFavoriteList(AccountID);

            FavoriteViewModel favoriteViewModel = new FavoriteViewModel(favorites);

            return PartialView("FavoriteTable", favoriteViewModel);
        }

        [HttpPost]
        public IActionResult AddToFavorite(string symbol)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            alphaVantageContainer.AddToFavorite(AccountID, symbol);

            return RedirectToAction("AccountStock", "AccountStock");
        }

    }
}
