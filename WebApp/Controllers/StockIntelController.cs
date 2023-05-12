using Business;
using Data;
using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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

        StockContainer stockContainer = new StockContainer();
        //new StockDAL(), new AlphaVantageDAL()
        public StockModel ToModel(Stock stock)
        {
            StockModel stockModel = new StockModel(
                stock.Date,
                stock.Symbol,
                stock.Open,
                stock.High,
                stock.Low,
                stock.Close,
                stock.Volume
                );
            return stockModel;
        }

        public APIResponseCallModel ToModel(APIResponseCall aPIResponseCall)
        {
            APIResponseCallModel aPIResponseCallModel = new APIResponseCallModel(
                aPIResponseCall.Date,
                aPIResponseCall.Symbol,
                aPIResponseCall.Open,
                aPIResponseCall.High,
                aPIResponseCall.Low,
                aPIResponseCall.Close,
                aPIResponseCall.Volume
                );
            return aPIResponseCallModel;
        }

        public SearchModel ToModel(Search search) 
        {
            SearchModel searchModel = new SearchModel(
                search.Symbol,
                search.Interval
                );
            return searchModel;
        }

        public Search ToCLass(SearchModel searchModel)
        {
            Search search = new Search(
                searchModel.Symbol,
                searchModel.Interval);
            return search;
        }
        [HttpGet]
        public IActionResult StockIntel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetStockData(string symbol, string interval)
        {
            SearchModel searchModel = new SearchModel(symbol, interval )
            {
                Symbol = symbol,
                Interval = interval
            };

            List<APIResponseCallDTO> data = await stockContainer.SearchStock(searchModel);

            return Ok(data);
        }
    }
}
