using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HistorieController : Controller
    {
        public IActionResult Historie()
        {
            return View();
        }

        HistorieContainer historieContainer = new HistorieContainer(new HistorieDAL());

        List<Historie> historieList = new List<Historie>();

        [HttpPost]
        public async Task<IActionResult> GetStockHistorie(HistorieSearchViewModel historieSearchViewModel)
        {
            Search search = new Search()
            {
                Symbol= historieSearchViewModel.Symbol,
                Interval= historieSearchViewModel.Interval,
                Slice= historieSearchViewModel.Slice
            };

            historieList = await historieContainer.SearchHistorieStock(search);

            HistorieViewModel historieViewModel = new HistorieViewModel(historieList, historieSearchViewModel);

            return PartialView("_historiestockTable", historieViewModel);
        }
    }
}
