namespace _11_Files
{
    internal interface IFileRepository
    {
        string StockFileName(int v);
        string StockFileName(Stock s);
        void SaveStock(Stock yhoo);
    }
}