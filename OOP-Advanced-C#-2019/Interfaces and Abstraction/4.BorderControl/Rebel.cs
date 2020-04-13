namespace _4.BorderControl
{
    public class Rebel : IBuyer
    {
        private const int DefaultAmountOfFood = 5;

        public Rebel(this)
        {

        }

        string Name { get; set; }
        
        int Age { get; set; }

        string Group { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += DefaultAmountOfFood;
        }
    }
}
