using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Recommendation
    {
        public long? RecommendationID { get; set; }
        public string Interest { get; }
        public string Name { get; }

        public Recommendation(long? recommendationID, string interest, string name)
        {
            RecommendationID = recommendationID;
            Interest = interest;
            Name = name;
        }
    }
}
