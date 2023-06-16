using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HistorieController : Controller
    {
        private HistorieContainer _historieContainer;

        public HistorieController()
        {
            _historieContainer = new HistorieContainer(new AlphaVantageDAL());
        }

        public IActionResult Historie()
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
        public List<HistorieViewModel> ToModel(List<Historie> histories)
        {
            List<HistorieViewModel> historieModels = new List<HistorieViewModel>();

            foreach (var historie in histories)
            {
                HistorieViewModel historieModel = new HistorieViewModel(
                    historie.Date,
                    historie.Symbol,
                    historie.Open,
                    historie.High,
                    historie.Low,
                    historie.Close,
                    historie.Volume);
                historieModels.Add(historieModel);
            }
            return historieModels;
        }

        List<Historie> historieList = new List<Historie>();

        [HttpPost]
        public async Task<IActionResult> GetStockHistorie(HistorieSearchViewModel historieSearchViewModel)
        {
            if(ModelState.IsValid)
            {
                Search search = new Search(historieSearchViewModel.Symbol, historieSearchViewModel.Interval, historieSearchViewModel.Slice);

                List<Historie> historieList = await _historieContainer.SearchHistorieStock(search);

                List<HistorieViewModel> historieModels = ToModel(historieList);

                HistorieViewModelList historieViewModel = new HistorieViewModelList(historieModels, historieSearchViewModel);

                return PartialView("_historiestockTable", historieViewModel);
            }
            
            return View("Historie");
            
        }
    }
}
