using System;

namespace _3.Mankind
{
    public class Program
    {
        public static void Main()
        {
            var studentInput = Console.ReadLine()
                .Split();

            var workerInput = Console.ReadLine()
                .Split();

            Student student;
            Worker worker;

            try
            {
                var studentFirstName = studentInput[0];
                    var studentLastName = studentInput[1];
                    var facultyNumber = studentInput[2];

                    student = new Student(studentFirstName, studentLastName, facultyNumber);


                    var workerFirstName = workerInput[0];
                    var workerLastName = workerInput[1];
                    var weekSalary = double.Parse(workerInput[2]);
                    var hoursPerDay = double.Parse(workerInput[3]);

                    worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);
                    

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
