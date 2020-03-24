namespace P05_GreedyTimes
{
    public class Gold : IBaggable
    {
        public Gold(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public long Quantity { get; set; }
    }
}
