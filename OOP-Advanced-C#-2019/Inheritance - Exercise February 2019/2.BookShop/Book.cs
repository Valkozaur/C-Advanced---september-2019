using System;
using System.Linq;
using System.Text;

namespace _2.BookShop
{
    public class Book
    {
        private string title;
        private string authorsNames;
        private decimal price;

        public Book(string authorsNames, string title, decimal price)
        {
            this.AuthorsNames = authorsNames;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string AuthorsNames
        {
            get => this.authorsNames;
            protected set
            {
                var indexOfWhiteSpace = value.IndexOf(" ");
                if (indexOfWhiteSpace != -1)
                {
                    var secondName = value.Substring(indexOfWhiteSpace + 1);
                    if (char.IsDigit(secondName[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.authorsNames = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }

        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}") 
                .AppendLine($"Author: {this.AuthorsNames}")
                .AppendLine($"Price: {this.Price:F2}");

            var result = resultBuilder.ToString().TrimEnd();
            return result;

        }
    }
}
