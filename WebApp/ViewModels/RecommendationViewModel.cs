namespace WebApp.ViewModels
{
    public class RecommendationViewModel
    {
        public long? RecommendationID { get; }
        public string Interest { get; }
        public string Name { get; }


        public RecommendationViewModel(long? recommendationID, string interest, string name)
        {
            RecommendationID = recommendationID;
            Interest = interest;
            Name = name;
        }
    }
}
