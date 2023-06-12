using Business;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HistorieController : Controller
    {
        private HistorieContainer _historieContainer;

        public HistorieController()
        {
            _historieContainer = new HistorieContainer();
        }

        public IActionResult Historie()
        {
            return View();
        }

        List<Historie> historieList = new List<Historie>();

        [HttpPost]
        public async Task<IActionResult> GetStockHistorie(HistorieSearchViewModel historieSearchViewModel)
        {
            
            Search search = new Search(historieSearchViewModel.Symbol, historieSearchViewModel.Interval, historieSearchViewModel.Slice);

            historieList = await _historieContainer.SearchHistorieStock(search);

            HistorieViewModel historieViewModel = new HistorieViewModel(historieList, historieSearchViewModel);

            return PartialView("_historiestockTable", historieViewModel);
        }
    }
}
