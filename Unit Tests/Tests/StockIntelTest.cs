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
    public class StockIntelTest
    {
        [TestMethod]
        public async Task SearchStock()
        {
            // Arrange
            SearchDTO searchDTO = new SearchDTO("AAPL", "15min", null);
            APIResponseCallSTUB aPIResponseCallSTUB = new APIResponseCallSTUB();
            AlphaVantageContainer alphaVantageContainer = new AlphaVantageContainer(new APIResponseCallSTUB(), new AccountStockSTUB());
            List<APIResponseCallDTO> expected = aPIResponseCallSTUB.SearchStock(searchDTO);
            Search search = new Search(searchDTO.Symbol, searchDTO.Interval, searchDTO.Slice);

            // Act
            List<APIResponseCall> result = await alphaVantageContainer.SearchStock(search);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
        }
    }
}
