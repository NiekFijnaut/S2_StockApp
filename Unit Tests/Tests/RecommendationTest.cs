using Business;
using Business.Container;
using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.STUB;

namespace Unit_Tests.Tests
{
    [TestClass]
    public class RecommendationTest
    {
        [TestMethod]
        public void GetRecommendation()
        {
            // Arrange
            string Interest = "Financials";
            RecommendationSTUB recommendationSTUB = new RecommendationSTUB();
            RecommendationContainer recommendationContainer = new RecommendationContainer(new RecommendationSTUB());
            List<RecommendationDTO> expected = recommendationSTUB.FakeRecommendations;

            // Act
            List<Recommendation> list = recommendationContainer.GetRecommandation(Interest);

            // Assert
            Assert.AreEqual(expected.Count, list.Count);
            
        }
    }
}
