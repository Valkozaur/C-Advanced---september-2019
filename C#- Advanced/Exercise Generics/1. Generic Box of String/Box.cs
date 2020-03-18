namespace _1._Generic_Box_of_String
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.Value = value;
        }
        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }
}
