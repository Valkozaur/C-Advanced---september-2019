namespace P03_StudentSystem
{
    using System.Text;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;  
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Name} is {this.Age} years old. ");

            if (this.Grade >= 5.00)
            {
                stringBuilder.AppendLine("Excellent student.");
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                stringBuilder.AppendLine("Average student.");
            }
            else
            {
                stringBuilder.AppendLine("Very nice person.");
            }

            return stringBuilder.ToString();
        }
    }
}
