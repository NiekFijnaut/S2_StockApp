using Business;
using Business.Container;
using Data.DAL;
using Interface;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RecommendationController : Controller
    {
        private RecommendationContainer _recommendationContainer;

        public RecommendationController()
        {
            _recommendationContainer = new RecommendationContainer(new RecommendationDAL());
        }

        public List<RecommendationModel> ToModel(List<Recommendation> recommendations)
        {
            List<RecommendationModel> recommendationModels = new List<RecommendationModel>();

            foreach (var recommendation in recommendations)
            {
                RecommendationModel recommendationModel = new RecommendationModel(
                recommendation.RecommendationID,
                recommendation.Interest,
                recommendation.Name);

                recommendationModels.Add(recommendationModel);
            }
            return recommendationModels;
        }

        [HttpGet]
        public IActionResult GetRecommendation()
        {
            AccountViewModel accountViewModel = new AccountViewModel();
            string interest = HttpContext.Session.GetString("Interest");
            accountViewModel.Interest = interest;
            List<Recommendation> recommendations = _recommendationContainer.GetRecommandation(interest);

            List<RecommendationModel> recommendationModels = ToModel(recommendations);

            RecommendationViewModel recommendationViewModel = new RecommendationViewModel(null, recommendationModels);

            return PartialView("_Recommendation", recommendationViewModel);
            
        }
    }
}
