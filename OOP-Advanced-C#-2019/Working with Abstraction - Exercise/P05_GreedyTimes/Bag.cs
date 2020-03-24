using Microsoft.Win32.SafeHandles;

namespace P05_GreedyTimes
{
    using System.Collections.Generic;

    public class Bag
    {
        private List<Gold> golds;

        private List<Gem> gems;

        private List<Cash> cash;

        public Bag()
        {
            this.golds = new List<Gold>();
            this.gems = new List<Gem>();
            this.cash = new List<Cash>();
        }

        public long TotalGoldAmount { get; private set; }
        
        public long TotalGemAmount { get; private set; }

        public long TotalCashAmount { get; private set; }

        public long TotalQuantity { get; private set; }

        public List<Gold> GetGold => this.golds;

        public List<Gem> GetGems => this.gems;

        public List<Cash> GetCash => this.cash;

        public void AddGold(string name, long quantity)
        {
            this.golds.Add(new Gold(name, quantity));
            this.AddToTotalGoldAmount(quantity);
            this.TotalQuantity += quantity;
        }

        public void AddGems(string name, long quantity)
        {
            this.gems.Add(new Gem(name, quantity));
            this.AddToTotalGemAmount(quantity);
            this.TotalQuantity += quantity;
        }

        public void AddCash(string name, long quantity)
        {
            this.cash.Add(new Cash(name, quantity));
            this.AddToTotalCashAmount(quantity);
            this.TotalQuantity += quantity;
        }

        private void AddToTotalGoldAmount(long quantity)
        {
            TotalGoldAmount += quantity;
        }

        private void AddToTotalCashAmount(long quantity)
        {
            TotalGemAmount += quantity;
        }


        private void AddToTotalGemAmount(long quantity)
        {
            TotalCashAmount += quantity;
        }
    }
}
