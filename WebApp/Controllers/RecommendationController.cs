using Business;
using Business.Container;
using Data.DAL;
using Interface;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetRecommendation()
        {
            AccountViewModel accountViewModel = new AccountViewModel();
            string interest = HttpContext.Session.GetString("Interest");
            accountViewModel.Interest = interest;
            List<Recommendation> recommendations = _recommendationContainer.GetRecommandation(interest);

            RecommendationViewModel recommendationViewModel = new RecommendationViewModel(null, recommendations);

            return PartialView("_Recommendation", recommendationViewModel);
            
        }
    }
}
