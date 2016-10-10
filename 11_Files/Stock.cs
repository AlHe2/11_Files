using System;

namespace _11_Files
{
    internal class Stock : IAsset
    {
        public Stock(String symbol, double price, int howMany) {
            this.Symbol = symbol;
            this.PricePerShare = price;
            this.NumShares = howMany;
        }

        public Stock() : this("", 0.0, 0) {
        }
        public int NumShares { get; internal set; }
        public double PricePerShare { get; internal set; }
        public string Symbol { get; internal set; }
        public long Id { get; internal set; }

        public double GetValue() {
            return PricePerShare * NumShares;
        }

        internal static double TotalValue(IAsset[] assets) {
            double result = 0.0;
            foreach(IAsset asset in assets) {
                result = result + asset.GetValue();
            }
            return result;
        }

        public override string ToString() {
            return "Stock[symbol=" + Symbol + 
                   ",pricePerShare=" + PricePerShare + 
                   ",numShares=" + NumShares + "]";
        }

        public override bool Equals(object obj) {
            Stock other = obj as Stock;
            return (this.Symbol.Equals(other.Symbol)) &&
                   (this.PricePerShare == other.PricePerShare) &&
                   (this.NumShares == other.NumShares);
        }

        public string GetName() {
            return Symbol;
        }
    }
}