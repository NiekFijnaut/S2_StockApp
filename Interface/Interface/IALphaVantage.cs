using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAlphaVantage
    {
        Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO);
        Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO);
        
    }
}
