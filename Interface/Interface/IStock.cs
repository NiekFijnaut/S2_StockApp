﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IStock
    {
        void AddStock(APIResponseCallDTO aPIResponseCallDTO, AccountStockDTO accountStockDTO);
        void GetAccountStockList();
        void UpdateStockTable(APIResponseCallDTO stockDTO);
        void DeleteStock(APIResponseCallDTO stockDTO);
        void DeleteStock(ulong stockId);
    }
}
