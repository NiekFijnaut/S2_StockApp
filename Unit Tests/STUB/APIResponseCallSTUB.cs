using Business;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.STUB
{
    public class APIResponseCallSTUB : IAlphaVantage
    {
        public List<APIResponseCall> FakeAPIResponseCall = new List<APIResponseCall>();

        public APIResponseCallDTO CreateFakeAPIResponseCall;

        public bool Create(APIResponseCallDTO aPIResponseCallDTO)
        {
            CreateFakeAPIResponseCall = aPIResponseCallDTO;

            if(aPIResponseCallDTO == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        List<APIResponseCallDTO> FakeAPIResponseCalls = new List<APIResponseCallDTO>()
        {
            new APIResponseCallDTO(
                1,
                new DateTime(2023, 06, 12, 11, 30, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
            new APIResponseCallDTO(
                1,
                new DateTime(2023, 06, 12, 11, 15, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
            new APIResponseCallDTO(
                1,
                new DateTime(2023, 06, 12, 10, 00, 30),
                "AAPL",
                182.56,
                186.56,
                180.56,
                182.65,
                12000),
        };    

        public Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO)
        {
            return Task.FromResult(FakeAPIResponseCalls);
        }

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

        public Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO)
        {
            return Task.FromResult(fakehistoryresponse);
        }
    }
}
