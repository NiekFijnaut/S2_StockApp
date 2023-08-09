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
            Assert.AreEqual(expected[0].Name.Trim(), list[0].Name.Trim());
            Assert.AreEqual(expected[1].Name.Trim(), list[1].Name.Trim());
            Assert.AreEqual(expected[2].Name.Trim(), list[2].Name.Trim());
            Assert.AreEqual(expected[3].Name.Trim(), list[3].Name.Trim());
            Assert.AreEqual(expected[0].Interest.Trim(), list[0].Interest.Trim());
            Assert.AreEqual(expected[1].Interest.Trim(), list[1].Interest.Trim());
            Assert.AreEqual(expected[2].Interest.Trim(), list[2].Interest.Trim());
            Assert.AreEqual(expected[3].Interest.Trim(), list[3].Interest.Trim());
        }
    }
}
