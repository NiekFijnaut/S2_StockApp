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
    public class HistoryTest
    {
        [TestMethod]
        public async Task SearcHistorie()
        {
            // Arrange
            SearchDTO searchDTO = new SearchDTO("AAPL", "15min", "year1month5");
            HistorySTUB historySTUB = new HistorySTUB();
            HistorieContainer historieContainer = new HistorieContainer(new HistorySTUB());
            List<HistorieDTO> expected = await historySTUB.SearchHistorieStock(searchDTO);
            Search search = new Search(searchDTO.Symbol, searchDTO.Interval, searchDTO.Slice);

            // Act
            List<Historie> result = await historieContainer.SearchHistorieStock(search);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
        }
    }
}
