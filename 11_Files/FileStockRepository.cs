using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo _repositoryDir;
        private long _id = 1;
        
        public FileStockRepository(DirectoryInfo repositoryDir) {
            this._repositoryDir = repositoryDir;
        }

        public void Clear() {
            string[] fileEntries = Directory.GetFiles(_repositoryDir.Name);
            foreach (string fileName in fileEntries) {
                FileInfo fi = new FileInfo(_repositoryDir + System.IO.Path.GetFileName(fileName));
                fi.Delete();
            }
        }

        public ICollection FindAllStocks() {
            List<Stock> stocks = new List<Stock>();
            StockIO sio = new StockIO();

            string[] fileEntries = Directory.GetFiles(_repositoryDir.Name);
            foreach (string fileName in fileEntries) {
                FileInfo fi = new FileInfo(_repositoryDir + Path.GetFileName(fileName));
                stocks.Add(sio.ReadStock(fi));
            }
            return stocks;
        }

        public Stock LoadStock(long id) {           
            FileInfo fi = new FileInfo(_repositoryDir + StockFileName((int)id));
            StockIO sio = new StockIO();
            return sio.ReadStock(fi);

        }

        public long NextId() {
            return _id++;
        }

        public void SaveStock(Stock stock) {
            stock.Id = this.NextId();
            FileInfo fi = new FileInfo(_repositoryDir + StockFileName(stock));
            StockIO sio = new StockIO(); 
            sio.WriteStock(fi, stock);
        }

        public string StockFileName(Stock stock) {
            return "stock" + stock.Id + ".txt";
        }

        public string StockFileName(int v) {
            return "stock" + v + ".txt";
        }

    }
}