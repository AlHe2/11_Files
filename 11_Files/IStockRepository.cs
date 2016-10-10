using System.Collections;
using System.Collections.Generic;

namespace _11_Files
{
    internal interface IStockRepository
    {
        void SaveStock(Stock yhoo);
        Stock LoadStock(long id);
        long NextId();
        ICollection FindAllStocks();
        void Clear();
    }
}