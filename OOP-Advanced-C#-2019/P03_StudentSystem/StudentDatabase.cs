namespace P03_StudentSystem
{
    using System.Collections.Generic;

    public class StudentDatabase
    {
        private readonly Dictionary<string, Student> repository;

        public StudentDatabase()
        {
            this.repository = new Dictionary<string, Student>();
        }

        public void Add(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            if (!repository.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                repository[name] = student;
            }
        }

        public Student ReturnStudent(string[] args)
        {
            var name = args[1];
            if (repository.ContainsKey(name))
            {
                var student = repository[name];
                return student;
            }

            return null;
        }
    }
}
