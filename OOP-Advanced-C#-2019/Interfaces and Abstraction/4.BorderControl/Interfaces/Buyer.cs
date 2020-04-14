namespace _4.BorderControl
{
   using Interfaces;

    public abstract class Buyer : IPerson
    {
        protected abstract int DefaultFood { get; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += this.DefaultFood;
        }

    }
}
