using Business.Class;
using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

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
        public List<FavoriteViewModel> ToModel(List<Favorite> favorites)
        {
            List<FavoriteViewModel> favoriteModels = new List<FavoriteViewModel>();

            foreach (var favorite in favorites)
            {
                FavoriteViewModel favoriteModel = new FavoriteViewModel(
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

            List<FavoriteViewModel> favoriteModels = ToModel(favorites);

            FavoriteViewModelList favoriteViewModel = new FavoriteViewModelList(favoriteModels);

            return PartialView("FavoriteTable", favoriteViewModel);
            
        }

        [HttpPost]
        public IActionResult AddToFavorite(FavoriteViewModel favoriteModel)
        {
            try
            {
                int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

                Favorite favorite = new Favorite(
                    favoriteModel.StockID,
                    favoriteModel.Symbol,
                    AccountID);

                _alphaVantageContainer.AddToFavorite(favorite);
            }
            catch (Exception ex)
            {
                TempData["AddToFavoriteError"] = ex.Message;
            }
            return RedirectToAction("AccountStock", "AccountStock");
        }

        [HttpPost]
        public IActionResult DeleteFavorite(FavoriteViewModel favoriteModel)
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
