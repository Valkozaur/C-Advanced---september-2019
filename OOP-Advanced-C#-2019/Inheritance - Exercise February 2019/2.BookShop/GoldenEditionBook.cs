namespace _2.BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string authorsNames, decimal price) 
            : base(title, authorsNames, price)
        {
        }

        public override decimal Price => base.Price * 1.3M;
    }
}
