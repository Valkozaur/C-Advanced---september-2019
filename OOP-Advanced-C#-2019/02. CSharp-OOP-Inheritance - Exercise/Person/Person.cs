using System;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
		private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string  Name 
        {
            get
            {
                return this.name;

            }
            set
            {
                this.name = value;
            }
        }

		public virtual int Age
		{
			get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age is Invalid!");
                }

                this.age = value;
            }
		}

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                this.Name,
                this.Age));

            return stringBuilder.ToString();
        }
    }
}

