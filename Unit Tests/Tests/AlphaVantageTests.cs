using Business;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.STUB;

namespace Unit_Tests.Tests
{
    [TestClass]
    public class AlphaVantageTests
    {
        [TestMethod]
        public async Task SearchStock()
        {
            // Arrange
            SearchDTO searchDTO = new SearchDTO("AAPL", "15min", null);
            APIResponseCallSTUB aPIResponseCallSTUB = new APIResponseCallSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), new StockSTUB());
            Search search = new Search(searchDTO.Symbol, searchDTO.Interval, searchDTO.Slice);

            // Act
            List<APIResponseCall> result = await alphaVantageContainer.SearchStock(search);
            var actualValues = result.Select(x => new { x.Symbol, x.Date, x.StockID }).ToList();

            // Assert
            CollectionAssert.AreEqual((await aPIResponseCallSTUB.SearchStock(searchDTO)).Select(x => new { x.Symbol, x.Date, x.StockID }).ToList(), actualValues);

        }

        [TestMethod]
        public async Task SearchHistorieStock()
        {
            // Arrange
            SearchDTO searchDTO = new SearchDTO("AAPL", "15min", "year1month5");
            APIResponseCallSTUB historySTUB = new APIResponseCallSTUB();
            HistorieContainer historieContainer = new HistorieContainer(new APIResponseCallSTUB());
            Search search = new Search(searchDTO.Symbol, searchDTO.Interval, searchDTO.Slice);

            // Act
            List<Historie> result = await historieContainer.SearchHistorieStock(search);
            var actualValues = result.Select(x => new { x.Symbol, x.Date, x.HistorieID }).ToList();

            // Assert
            var expectedValues = (await historySTUB.SearchHistorieStock(searchDTO)).Select(x => new { x.Symbol, x.Date, x.HistorieID }).ToList();
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}
