namespace WebApp.ViewModels
{
    public class RecommendationViewModelList
    {
        public long? RecommendationID { get; set; }
        public List<RecommendationViewModel> Recommendations { get; set; }

        public RecommendationViewModelList()
        {

        }

        public RecommendationViewModelList(long? recommendationID, List<RecommendationViewModel> recommendations)
        {
            RecommendationID = recommendationID;
            Recommendations = recommendations;
        }
    }
}
