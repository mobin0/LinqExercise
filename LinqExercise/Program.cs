using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        private static void printArray<T> (IEnumerable<T> modifiedList, string Name) {
            Console.WriteLine(Name);
            foreach (var i in modifiedList) {
                Console.WriteLine(i);
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum");
            int sum = numbers.Sum();
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            Console.WriteLine("Average");
            double average = numbers.Average();
            Console.WriteLine(average);
            //TODO: Order numbers in ascending order and print to the console
            IEnumerable<int> Ascending = numbers.OrderBy(x=>x);
            printArray(Ascending, "Ascending");
            //TODO: Order numbers in decsending order adn print to the console
            IEnumerable<int> Descending = numbers.OrderByDescending(x => x);
            printArray(Descending, "Descending");
            //TODO: Print to the console only the numbers greater than 6
            IEnumerable<int> GreaterThanSix = numbers.Where(x => x > 6);
            printArray(GreaterThanSix, "Greater Than Six");
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            IEnumerable <int> Print4 = numbers.OrderBy(x => x).Take(4);
            printArray(Print4, "Take 4");
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            int[] numbersWithAge = new int[numbers.Length];
            Array.Copy(numbers,numbersWithAge,numbers.Length);

            numbersWithAge[4] = 29;
            numbersWithAge.OrderByDescending(x => x);
            printArray(numbersWithAge, "Numbers with Age");
            
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            IEnumerable<string> firstNameAscending = employees.Where(x => (x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S"))).OrderBy(x => x.FirstName).Select(x => x.FullName);
            printArray(firstNameAscending, "First Name with C or S start, ascending");










            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            IEnumerable<string> Over26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName).Select(x => $"Full Name: {x.FullName}, Age: {x.Age}");
            printArray(Over26, "Over 26, Ordered by Age then First Name");










            //TODO: Print the Average and Sum of employees if experience if their YOE is less than or equal to 10 AND Age is greater than 35
            IEnumerable<Employee> YOEAverageSum = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine("YOE Average of age > 35: ");
            Console.WriteLine("Sum: ");
            Console.WriteLine(YOEAverageSum.Select(x => x.YearsOfExperience).Sum());
            Console.WriteLine("Average: ");
            Console.WriteLine(YOEAverageSum.Average(x=> x.YearsOfExperience));
            Console.WriteLine("");
            //TODO: Add an employee to the end of the list without using emp
            //TODO: Print the Sum and then the Average of the employees' YearsOfExployees.Add()
            Employee newEmployee = new Employee("Mobin", "Skaria", 29, 10);
            IEnumerable<Employee> newEmployees = employees.GetRange(0,employees.Count);

            IEnumerable<Employee> newEmployeesAppended = newEmployees.Append(newEmployee);
            IEnumerable<string> newEmployeeList = newEmployeesAppended.Select(x => $"Name: {x.FullName}, Age: {x.Age}");
            printArray(newEmployeeList, "New Employees"); 


            Console.WriteLine("Done!");

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
