namespace P05_GreedyTimes
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Engine(long bagCapacity, string[] safe)
        {
            var bag = new Bag();

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long quantity = long.Parse(safe[i + 1]);

                string typeOfTreasure = string.Empty;

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
                else if (bagCapacity < bag.TotalQuantity)
                {
                    continue;
                }

                switch (typeOfTreasure)
                {
                    case "Gem":
                        if (!bag.GetGems.Any())
                        {
                            if (bag.GetGold.Any())
                            {
                                if (quantity > bag.TotalGoldAmount)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.TotalGemAmount + quantity > bag.TotalGoldAmount)
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.GetCash.Any())
                        {
                            if (bag.GetGems.Any())
                            {
                                if (quantity > bag.TotalGemAmount)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.TotalCashAmount + quantity > bag.TotalGemAmount)
                        {
                            continue;
                        }
                        break;
                }

                if (typeOfTreasure == "Gold")
                {
                    bag.AddGold(name, quantity);
                }
                else if (typeOfTreasure == "Gem")
                {
                    bag.AddGems(name, quantity);
                }
                else if (typeOfTreasure == "Cash")
                {
                    bag.AddCash(name,quantity);
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}
