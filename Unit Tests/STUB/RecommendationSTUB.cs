using Interface.DTO;
using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.STUB
{
    public class RecommendationSTUB : IRecommendation
    {
        string Interest = "Financials";

        public List<RecommendationDTO> FakeRecommendations = new List<RecommendationDTO>()
        {
            new RecommendationDTO(
                29,
                "Financials",
                "JPMorgan Chase & Co. (JPM) "),
            new RecommendationDTO(
                30,
                "Financials",
                "Bank of America Corporation (BAC)"),
            new RecommendationDTO(
                31,
                "Financials",
                "Citigroup Inc. (C)"),
            new RecommendationDTO(
                32,
                "Financials",
                "Wells Fargo & Company (WFC)")
        };

        public List<RecommendationDTO> GetRecommendations(string Interest)
        {
            return FakeRecommendations;
        }
    }
}
