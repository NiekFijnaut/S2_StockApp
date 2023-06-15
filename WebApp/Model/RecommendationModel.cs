namespace WebApp.Model
{
    public class RecommendationModel
    {
        public long? RecommendationID { get; }
        public string Interest { get; }
        public string Name { get; }

        
        public RecommendationModel(long? recommendationID, string interest, string name)
        {
            RecommendationID = recommendationID;
            Interest = interest;
            Name = name;
        }
    }
}
