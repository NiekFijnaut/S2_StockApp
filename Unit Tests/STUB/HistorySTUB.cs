using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.STUB
{
    public class HistorySTUB : IAlphaVantage
    {
        SearchDTO searchDTO = new SearchDTO(
            "AAPL",
            "15min",
            "year1month5");

        List<HistorieDTO> fakehistoryresponse = new List<HistorieDTO>()
        {
            new HistorieDTO(
                1,
                new DateTime(2023, 01, 12, 11, 30, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
            new HistorieDTO(
                1,
                new DateTime(2023, 01, 12, 11, 15, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
            new HistorieDTO(
                1,
                new DateTime(2023, 01, 12, 10, 00, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
        };

        public List<HistorieDTO> SearchHistorieStock(SearchDTO searchDTO)
        {
            return fakehistoryresponse;
        }

            public Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO)
        {
            throw new NotImplementedException();
        }
    }
}
