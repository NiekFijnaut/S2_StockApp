using Business;
using Business.Class;
using Data;
using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StockIntelController : Controller
    {
        private AlphaVantageContainer _alphaVantageContainer;

        public StockIntelController()
        {
            _alphaVantageContainer = new AlphaVantageContainer(new AlphaVantageDAL(), new StockDAL());
        }

        [HttpGet]
        public IActionResult StockIntel()
        {
            return View();
        }

        List<APIResponseCall> APIResponseList = new List<APIResponseCall>();

        [HttpPost]
        public async Task<IActionResult> GetSearchResults(SearchViewModel searchViewModel)
        {
            Search search = new Search(searchViewModel.Symbol, searchViewModel.Interval, "");

            APIResponseList = await _alphaVantageContainer.SearchStock(search);

            APIResponseCallViewModel responseViewModel = new APIResponseCallViewModel(APIResponseList, searchViewModel);

            return PartialView("_StockIntelTable", responseViewModel);
           
        }

        [HttpPost]
        public async Task<IActionResult> AddStockToAccount(SearchViewModel searchViewModel, AccountViewModel accountViewModel)
        {
            Search search = new Search(searchViewModel.Symbol, searchViewModel.Interval, "");

            int AccountID = HttpContext.Session.GetInt32("AccountID") ?? 0;

            APIResponseList = await _alphaVantageContainer.SearchStock(search);

            if (APIResponseList.Count > 0)
            {

                APIResponseCall aPIResponseCall = new APIResponseCall(
                    null,
                    APIResponseList[APIResponseList.Count - 1].Date,
                    APIResponseList[APIResponseList.Count - 1].Symbol,
                    APIResponseList[APIResponseList.Count - 1].Open,
                    APIResponseList[APIResponseList.Count - 1].High,
                    APIResponseList[APIResponseList.Count - 1].Low,
                    APIResponseList[APIResponseList.Count - 1].Close,
                    APIResponseList[APIResponseList.Count - 1].Volume
                );

                _alphaVantageContainer.AddStock(aPIResponseCall, AccountID);
                ViewBag.Message = "Stock has been added to account";
            }
            return View("StockIntel");
            
        }      
    }
}
