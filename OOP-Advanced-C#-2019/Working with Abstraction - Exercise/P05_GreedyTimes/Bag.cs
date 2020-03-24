using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    using System.Collections.Generic;

    public class Bag
    {
        private List<Item> golds;

        private List<Item> gems;

        private List<Item> cash;

        public Bag()
        {
            this.golds = new List<Item>();
            this.gems = new List<Item>();
            this.cash = new List<Item>();
        }

        public long TotalGoldAmount { get; private set; }
        
        public long TotalGemAmount { get; private set; }

        public long TotalCashAmount { get; private set; }

        public long TotalQuantity { get; private set; }

        public List<Item> GetGold => this.golds;

        public List<Item> GetGems => this.gems;

        public List<Item> GetCash => this.cash;

        public void AddGold(string name, long quantity)
        {
            var gold = golds.FirstOrDefault(g => g.Name == name);
            if (gold != default)
            {
                gold.Quantity += quantity;
                this.AddToTotalGoldAmount(quantity);
                return;
            }

            this.golds.Add(new Item(name, quantity));
            this.AddToTotalGoldAmount(quantity);
            this.TotalQuantity += quantity;
        }

        public void AddGems(string name, long quantity)
        {
            var gem = gems.FirstOrDefault(g => g.Name == name);
            if (gem != default)
            {
                gem.Quantity += quantity;
                this.AddToTotalGemAmount(quantity);
                return;
            }

            this.gems.Add(new Item(name, quantity));
            this.AddToTotalGemAmount(quantity);
            this.TotalQuantity += quantity;
        }

        public void AddCash(string name, long quantity)
        {
            var cash = this.cash.FirstOrDefault(c => c.Name == name);
            if (cash != default)
            {
                cash.Quantity += quantity;
                this.AddToTotalCashAmount(quantity);
                return;
            }

            this.cash.Add(new Item(name, quantity));
            this.AddToTotalCashAmount(quantity);
            this.TotalQuantity += quantity;
        }

        private void AddToTotalGoldAmount(long quantity)
        {
            TotalGoldAmount += quantity;
        }

        private void AddToTotalCashAmount(long quantity)
        {
            TotalCashAmount += quantity;
        }


        private void AddToTotalGemAmount(long quantity)
        {
            TotalGemAmount += quantity;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            if (golds.Any())
            {
                stringBuilder.AppendLine($"<Gold> ${TotalGoldAmount}");
                foreach (var gold in golds.OrderByDescending(g => g.Name).ThenBy(g => g.Quantity))
                {
                    stringBuilder.AppendLine($"##{gold.Name} - {gold.Quantity}");
                }
                if (gems.Any())
                {
                    stringBuilder.AppendLine($"<Gem> ${TotalGemAmount}");
                    foreach (var gem in gems.OrderByDescending(g => g.Name).ThenBy(g => g.Quantity))
                    {
                        stringBuilder.AppendLine($"##{gem.Name} - {gem.Quantity}");
                    }
                    if (cash.Any())
                    {
                        stringBuilder.AppendLine($"<Cash> ${TotalCashAmount}");
                        foreach (var item in cash.OrderByDescending(c => c.Name).ThenBy(c => c.Quantity))
                        {
                            stringBuilder.AppendLine($"##{item.Name} - {item.Quantity}");
                        }
                    }
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
