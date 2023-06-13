using Business.Class;
using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private AlphaVantageContainer _alphaVantageContainer;

        public FavoriteController()
        {
            _alphaVantageContainer = new AlphaVantageContainer(new AlphaVantageDAL(), new StockDAL());
        }

        public IActionResult Favorite()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetFavorite(AccountViewModel accountViewModel)
        {
           
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            List<Favorite> favorites = _alphaVantageContainer.GetFavoriteList(AccountID);

            FavoriteViewModel favoriteViewModel = new FavoriteViewModel(favorites);

            return PartialView("FavoriteTable", favoriteViewModel);
            
        }

        [HttpPost]
        public IActionResult AddToFavorite(string symbol)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            _alphaVantageContainer.AddToFavorite(AccountID, symbol);

            return RedirectToAction("AccountStock", "AccountStock");
           
        }

        [HttpPost]
        public IActionResult DeleteFavorite(string Symbol)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;
            _alphaVantageContainer.DeleteFavorite(Symbol, AccountID);
            return RedirectToAction("Favorite", "Favorite");
           
        }
    }
}
