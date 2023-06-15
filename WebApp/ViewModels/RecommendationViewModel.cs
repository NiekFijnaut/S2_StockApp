using WebApp.Model;

namespace WebApp.Models
{
    public class RecommendationViewModel
    {
        public long? RecommendationID { get; set; }
        public List<RecommendationModel> Recommendations { get; set; }

        public RecommendationViewModel()
        {

        }

        public RecommendationViewModel(long? recommendationID, List<RecommendationModel> recommendations)
        {
            RecommendationID = recommendationID;
            Recommendations = recommendations;
        }
    }
}
