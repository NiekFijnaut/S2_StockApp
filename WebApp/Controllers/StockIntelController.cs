﻿using Business;
using Business.Class;
using Data;
using Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection;
using WebApp.Model;
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
            if (HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public List<APIResponseCallModel> ToModel(List<APIResponseCall> aPIResponseCalls)
        {
            List<APIResponseCallModel> aPIResponseCallModels= new List<APIResponseCallModel>();

            foreach(var aPIResponsecall in aPIResponseCalls)
            {
                APIResponseCallModel aPIResponseCallModel = new APIResponseCallModel(
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
                Search search = new Search(searchViewModel.Symbol, searchViewModel.Interval, "");

                List<APIResponseCall> APIResponseList = await _alphaVantageContainer.SearchStock(search);

                List<APIResponseCallModel> aPIResponseCallModels = ToModel(APIResponseList);
                
                APIResponseCallViewModel responseViewModel = new APIResponseCallViewModel(aPIResponseCallModels, searchViewModel);
               
                return PartialView("_StockIntelTable", responseViewModel);
            }
            return View("StockIntel");
           
        }

        [HttpPost]
        public async Task<IActionResult> AddStockToAccount(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
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
            return View("StockIntel");
        }      
    }
}
