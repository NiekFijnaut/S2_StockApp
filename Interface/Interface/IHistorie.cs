using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{ 
    public interface IHistorie
    {
        void AddHistorie(HistorieDTO historieDTO);
        List<HistorieDTO> ViewHistorie(HistorieDTO historieDTO);
    }
}
