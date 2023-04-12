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
    }
}
