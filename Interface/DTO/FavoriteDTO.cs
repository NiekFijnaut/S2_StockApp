using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTO
{
    public record FavoriteDTO(
        long? StockID,
        
        string Symbol,
        long? AccountID);
}
