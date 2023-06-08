﻿using Business;
using Business.Container;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RecommendationController : Controller
    {
        RecommendationContainer recommendationContainer = new RecommendationContainer(new RecommendationDAL());

        [HttpGet]
        public IActionResult GetRecommendation(AccountViewModel accountViewModel)
        {
            string interest = accountViewModel.Interest;
            List<Recommendation> recommendations = recommendationContainer.GetRecommandation(interest);

            RecommendationViewModel recommendationViewModel = new RecommendationViewModel(null, recommendations);

            return PartialView("_Recommendation", recommendationViewModel);
        }
    }
}
