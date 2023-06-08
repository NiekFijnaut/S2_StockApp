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

        public IActionResult Index()
        {
            return View();
        }

        AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new AlphaVantageDAL());
        

        public APIResponseCallViewModel ToModel(List<APIResponseCall> APIResponseList, SearchViewModel searchViewModel)
        {
            APIResponseCallViewModel aPIResponseCallViewModel = new APIResponseCallViewModel(
                APIResponseList,
                searchViewModel
                );
            return aPIResponseCallViewModel;
        }

        public SearchViewModel ToModel(Search search) 
        {
            SearchViewModel searchModel = new SearchViewModel(
                search.Symbol,
                search.Interval
                );
            return searchModel;
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
            Search search = new Search()
            {
                Symbol = searchViewModel.Symbol,
                Interval = searchViewModel.Interval
            };

            APIResponseList = await alphaVantageContainer.SearchStock(search);

            APIResponseCallViewModel responseViewModel = new APIResponseCallViewModel(APIResponseList, searchViewModel);

            return PartialView("_StockIntelTable", responseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddStockToAccount(SearchViewModel searchViewModel, AccountViewModel accountViewModel)
        {
            //TODO fix accountID value
            Search search = new Search()
            {
                Symbol = searchViewModel.Symbol,
                Interval = searchViewModel.Interval
            };

            int AccountID = accountViewModel.AccountID;

            APIResponseList = await alphaVantageContainer.SearchStock(search);

            if (APIResponseList.Count > 0)
            {
                APIResponseCall aPIResponseCall = new APIResponseCall()
                {
                    
                    Date = APIResponseList[APIResponseList.Count - 1].Date,
                    Symbol = APIResponseList[APIResponseList.Count - 1].Symbol,
                    Open = APIResponseList[APIResponseList.Count - 1].Open,
                    High = APIResponseList[APIResponseList.Count - 1].High,
                    Low = APIResponseList[APIResponseList.Count - 1].Low,
                    Close = APIResponseList[APIResponseList.Count - 1].Close,
                    Volume = APIResponseList[APIResponseList.Count - 1].Volume
                };
                alphaVantageContainer.AddStock(aPIResponseCall, AccountID);
                ViewBag.Message = "Stock has been added to account";
                return View("StockIntel");
            }
            else
            {
                ViewBag.Message = "Something went wrong";
                return View("StockIntel");
            }
        }      
    }
}
