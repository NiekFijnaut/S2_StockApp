using Data.DAL;
using Interface;
using Interface.DTO;
using Interface.Interface;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Container
{
    public class RecommendationContainer
    {
        private IRecommendation _recommendation;

        public RecommendationContainer(IRecommendation recommendation)
        {
            _recommendation = recommendation;
        }

        public RecommendationDAL recommendationDAL = new RecommendationDAL();

        public List<Recommendation> GetRecommandation(string interest)
        {
            List<Recommendation> recommendations = new List<Recommendation>();
            List<RecommendationDTO> recommendationDTOs = recommendationDAL.GetRecommendations(interest);
            foreach (RecommendationDTO recommendationDTO in recommendationDTOs)
            {
                recommendations.Add(
                    new Recommendation(
                        null,
                        recommendationDTO.Interest,
                        recommendationDTO.Name
                        ));
            }
            return recommendations;
        }
    }
}
