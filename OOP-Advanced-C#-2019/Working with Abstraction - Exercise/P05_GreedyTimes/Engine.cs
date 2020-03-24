namespace P05_GreedyTimes
{
    using System;

    public class Engine
    {
        public void EngineStart(long bagCapacity, string[] safe)
        {
            var bag = new Bag();

            for (var i = 0; i < safe.Length; i += 2)
            {
                var name = safe[i];
                var quantity = long.Parse(safe[i + 1]);

                var typeOfTreasure = string.Empty;

                if (name.Length == 3)
                {
                    typeOfTreasure = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    typeOfTreasure = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    typeOfTreasure = "Gold";
                }

                if (typeOfTreasure == "")
                {
                    continue;
                }

                if (bagCapacity < bag.TotalQuantity + quantity)
                {
                    continue;
                }

                switch (typeOfTreasure)
                {
                    case "Gem":
                        if (bag.TotalGoldAmount >= bag.TotalGemAmount + quantity)
                        {
                            bag.AddGems(name, quantity);
                        }
                        break;
                    case "Cash":
                        if (bag.TotalGemAmount >= bag.TotalCashAmount + quantity)
                        {
                            bag.AddCash(name, quantity);
                        }
                        break;
                    case "Gold":
                        bag.AddGold(name, quantity);
                        break;
                }
            }

            Console.WriteLine(bag);
        }
    }
}
