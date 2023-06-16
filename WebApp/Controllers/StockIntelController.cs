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
using WebApp.ViewModels;

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
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public List<APIResponseCallViewModel> ToModel(List<APIResponseCall> aPIResponseCalls)
        {
            List<APIResponseCallViewModel> aPIResponseCallModels= new List<APIResponseCallViewModel>();

            foreach(var aPIResponsecall in aPIResponseCalls)
            {
                APIResponseCallViewModel aPIResponseCallModel = new APIResponseCallViewModel(
                    aPIResponsecall.StockID,
                    aPIResponsecall.Date,
                    aPIResponsecall.Symbol,
                    aPIResponsecall.Open,
                    aPIResponsecall.High,
                    aPIResponsecall.Low,
                    aPIResponsecall.Close,
                    aPIResponsecall.Volume);
                aPIResponseCallModels.Add(aPIResponseCallModel);
            }
            return aPIResponseCallModels;
        }

        List<APIResponseCall> APIResponseList = new List<APIResponseCall>();

        [HttpPost]
        public async Task<IActionResult> GetSearchResults(SearchViewModel searchViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Search search = new Search(searchViewModel.Symbol, searchViewModel.Interval, "");

                    List<APIResponseCall> APIResponseList = await _alphaVantageContainer.SearchStock(search);

                    List<APIResponseCallViewModel> aPIResponseCallModels = ToModel(APIResponseList);

                    APIResponseCallViewModelList responseViewModel = new APIResponseCallViewModelList(aPIResponseCallModels, searchViewModel);

                    return PartialView("_StockIntelTable", responseViewModel);
                }
                catch (Exception ex)
                {
                    TempData["SearchStockError"] = ex.Message;
                }
            }
            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> AddStockToAccount(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                try
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
                }
                catch(Exception ex)
                {
                    TempData["AddToAccountError"] = ex.Message;
                }
            }
            return View("StockIntel");
        }      
    }
}
