namespace P05_GreedyTimes
{
    public class Cash : IBaggable
    {
        public Cash(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public long Quantity { get; set; }
    }
}
