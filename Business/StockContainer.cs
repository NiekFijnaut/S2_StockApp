using Data;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StockContainer
    {
        public StockDAL stockDAL = new StockDAL();
        public void AddStock(Stock stock)
        {
            StockDTO stockDTO = new StockDTO(
                stock.StockID, 
                stock.Date,
                stock.Symbol,
                stock.Open, 
                stock.High,
                stock.Low, 
                stock.Close,
                stock.Volume);
            stockDAL.AddStock(stockDTO);
        }
    }
}
