using Business;

namespace WebApp.Models
{
    public class RecommendationViewModel
    {
        public long? RecommendationID { get; set; }
        public List<Recommendation> Recommendations { get; set; }

        public RecommendationViewModel(long? recommendationID, List<Recommendation> recommendations)
        {
            RecommendationID = recommendationID;
            Recommendations = recommendations;
        }
    }
}
