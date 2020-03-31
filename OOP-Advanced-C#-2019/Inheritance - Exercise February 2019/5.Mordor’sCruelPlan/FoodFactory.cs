namespace _5.Mordor_sCruelPlan
{
    using _5.Mordor_sCruelPlan.Food;

    public class FoodFactory
    {
        public Food.Food GetFood(string food)
        {
            Food.Food currentFood;

            switch (food)
            {
                case "cram":
                    currentFood = new Cram();
                    break;
                case "lembas":
                    currentFood = new Lembas(); ;
                    break;
                case "apple":
                    currentFood = new Apple(); ;
                    break;
                case "melon":
                    currentFood = new Melon();
                    break;
                case "honeycake":
                    currentFood = new HoneyCake();
                    break;
                case "mushroom":
                    currentFood = new Mushrooms();
                    break;
                default:
                    currentFood = null;
                    break;
            }

            return currentFood;
        }
    }
}
