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
        private IHistorie _historie;

        public HistorieContainer(IHistorie historie) 
        {
            _historie = historie;
        }
        
        public HistorieDAL historieDAL = new HistorieDAL();
        public void AddHistorie(Historie historie)
        {
            HistorieDTO historieDTO = new HistorieDTO(
                historie.HistorieID,
                historie.Date,
                historie.Symbol,
                historie.Open,
                historie.High,
                historie.Low,
                historie.Close,
                historie.Volume);
            historieDAL.AddHistorie(historieDTO);
        }

        public async Task<List<Historie>> SearchHistorieStock(Search search)
        {
            SearchDTO searchDTO = new SearchDTO(
                search.Symbol,
                search.Interval,
                search.Slice);

            List<Historie> historielist = new List<Historie>();
            List<HistorieDTO> historieDTOs = await historieDAL.SearchHistorieStock(searchDTO);
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
