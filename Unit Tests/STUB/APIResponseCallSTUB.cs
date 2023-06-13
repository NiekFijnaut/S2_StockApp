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

        SearchDTO SearchDTO = new SearchDTO(
            "AAPL",
            "15min",
            null);

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

        public Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO)
        {
            throw new NotImplementedException();
        }
    }
}
