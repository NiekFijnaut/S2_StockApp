using Business.Class;
using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Model;

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
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login"); 
            }
        }
        public List<FavoriteModel> ToModel(List<Favorite> favorites)
        {
            List<FavoriteModel> favoriteModels = new List<FavoriteModel>();

            foreach (var favorite in favorites)
            {
                FavoriteModel favoriteModel = new FavoriteModel(
                    favorite.StockID,
                    favorite.Symbol,
                    favorite.AccountID);

                favoriteModels.Add(favoriteModel);
            }

            return favoriteModels;
        }

        [HttpGet]
        public IActionResult GetFavorite()
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            List<Favorite> favorites = _alphaVantageContainer.GetFavoriteList(AccountID);

            List<FavoriteModel> favoriteModels = ToModel(favorites);

            FavoriteViewModel favoriteViewModel = new FavoriteViewModel(favoriteModels);

            return PartialView("FavoriteTable", favoriteViewModel);
            
        }

        [HttpPost]
        public IActionResult AddToFavorite(FavoriteModel favoriteModel)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            Favorite favorite = new Favorite(
                favoriteModel.StockID,
                favoriteModel.Symbol,
                AccountID);

            _alphaVantageContainer.AddToFavorite(favorite);

            return RedirectToAction("AccountStock", "AccountStock");
           
        }

        [HttpPost]
        public IActionResult DeleteFavorite(FavoriteModel favoriteModel)
        {
            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            Favorite favorite = new Favorite(
                favoriteModel.StockID,
                favoriteModel.Symbol,
                AccountID);

            _alphaVantageContainer.DeleteFavorite(favorite);

            return RedirectToAction("Favorite", "Favorite");
           
        }
    }
}
