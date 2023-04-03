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
        private StockDAL stockDAL = new StockDAL();
        public void AddStock(Stock stock)
        {
            StockDTO stockDTO = new StockDTO(
                stock.StockID, 
                stock.Name, 
                stock.Ticker, 
                stock.Price, 
                stock.Volume);
            stockDAL.AddStock(stockDTO);
        }
    }
}
