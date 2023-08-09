using Business;
using Business.Container;
using Data.DAL;
using Interface;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RecommendationController : Controller
    {
        private RecommendationContainer _recommendationContainer;

        public RecommendationController()
        {
            _recommendationContainer = new RecommendationContainer(new RecommendationDAL());
        }

        public List<RecommendationViewModel> ToModel(List<Recommendation> recommendations)
        {
            List<RecommendationViewModel> recommendationModels = new List<RecommendationViewModel>();

            foreach (var recommendation in recommendations)
            {
                RecommendationViewModel recommendationModel = new RecommendationViewModel(
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

            List<RecommendationViewModel> recommendationModels = ToModel(recommendations);

            RecommendationViewModelList recommendationViewModel = new RecommendationViewModelList(null, recommendationModels);

            return PartialView("_Recommendation", recommendationViewModel);
            
        }
    }
}
