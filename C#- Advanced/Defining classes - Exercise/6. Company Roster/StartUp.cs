namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inputLines = int.Parse(Console.ReadLine());
            var departmentEmployees = new Dictionary<string, List<Employee>>();

            for (int i = 0; i < inputLines; i++)
            {
                Employee employee = null;

                var employeeInfo = Console.ReadLine()
                    .Split(" ");

                var name = employeeInfo[0];
                var salary = double.Parse(employeeInfo[1]);
                var position = employeeInfo[2];
                var department = employeeInfo[3];

                if (employeeInfo.Length == 4)
                {
                    employee = new Employee(name, salary, position, department);
                }
                else if (employeeInfo.Length == 6)
                {
                    var email = employeeInfo[4];
                    var age = int.Parse(employeeInfo[5]);
                    employee = new Employee(name, salary, position, department, email, age);
                }
                else
                {
                    var isAge = int.TryParse(employeeInfo[4], out int age);
                        
                    if (isAge)
                    {
                        employee = new Employee(name, salary, position, department, age);
                    }
                    else
                    {
                        var email = employeeInfo[4];
                        employee = new Employee(name, salary, position, department, email);
                    }
                }

                if (!departmentEmployees.ContainsKey(department))
                {
                    departmentEmployees.Add(department, new List<Employee>());
                }

                departmentEmployees[department].Add(employee);
            }

            departmentEmployees = departmentEmployees
                .OrderByDescending(x => x.Value.Sum(e => e.Salary))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var (department, employees) in departmentEmployees)
            {
                Console.WriteLine($"Highest Average Salary: {department}");

                foreach (var employee in employees.OrderBy(x => x.Age))
                {
                    Console.WriteLine(employee);
                }

                break;
            }
        }
    }
}
