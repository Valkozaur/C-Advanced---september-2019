namespace P03_StudentSystem
{
    using System;

    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repository = new StudentDatabase();
        }

        public StudentDatabase Repository { get; set; }

        public void ParseCommand()
        {
            var args = Console.ReadLine().Split();

            while (true)
            {
                if (args[0] == "Create")
                {
                    this.Repository.Add(args);
                }
                else if (args[0] == "Show")
                {
                    var student = this.Repository.ReturnStudent(args);
                    if (student != null)
                    {
                        Console.WriteLine(student);
                    }
                }
                else if (args[0] == "Exit")
                {
                    break;
                }
            }
        }
    }
}
