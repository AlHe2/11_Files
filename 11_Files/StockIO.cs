using System;
using System.IO;

namespace _11_Files
{
    internal class StockIO
    {
        internal void WriteStock(StringWriter sw, Stock hp) {
            sw.Write(hp.Symbol);
            sw.WriteLine();
            sw.Write(hp.PricePerShare);
            sw.WriteLine();
            sw.Write(hp.NumShares);
            sw.WriteLine();
            sw.Close();
        }

        internal void WriteStock(FileInfo output, Stock stock) {
            FileStream fs = output.Create();
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(stock.Symbol);
            sw.WriteLine();
            sw.Write(stock.PricePerShare);
            sw.WriteLine();
            sw.Write(stock.NumShares);
            sw.WriteLine();
            sw.Close();
        }
        internal Stock ReadStock(StringReader data) {
            double price;
            int number;
            string symbol = data.ReadLine();
            string priceAsString = data.ReadLine();
            string numberAsString = data.ReadLine();
            Double.TryParse(priceAsString, out price);
            int.TryParse(numberAsString, out number);
            return new Stock(symbol, price, number);
        }


        internal Stock ReadStock(FileInfo output) {
            FileStream fs = output.OpenRead();
            StreamReader sw = new StreamReader(fs);
            double price;
            int number;

            string symbol = sw.ReadLine();
            string priceAsString = sw.ReadLine();
            string numberAsString = sw.ReadLine();
            sw.Close();
            Double.TryParse(priceAsString, out price);
            int.TryParse(numberAsString, out number);

            return new Stock(symbol, price, number);
        }
    }
}