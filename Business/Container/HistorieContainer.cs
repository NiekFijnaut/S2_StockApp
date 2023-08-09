using Data;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HistorieContainer
    {
        private IAlphaVantage _alphaVantage;

        public HistorieContainer(IAlphaVantage alphaVantage) 
        {
            _alphaVantage = alphaVantage;
        }

        public async Task<List<Historie>> SearchHistorieStock(Search search)
        {
            SearchDTO searchDTO = new SearchDTO(
            search.Symbol,
            search.Interval,
            search.Slice);

            List<Historie> historielist = new List<Historie>();
            List<HistorieDTO> historieDTOs = await _alphaVantage.SearchHistorieStock(searchDTO);
            foreach (HistorieDTO historieDTO in historieDTOs)
            {
                historielist.Add(
                    new Historie(
                        historieDTO.Date,
                        historieDTO.Symbol,
                        historieDTO.Open,
                        historieDTO.High,
                        historieDTO.Low,
                        historieDTO.Close,
                        historieDTO.Volume
                        ));
            }
            return historielist;
            
        }
    }
}
