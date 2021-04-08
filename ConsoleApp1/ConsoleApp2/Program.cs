using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Enter days:");
            int days = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter days in month:");
            int daysInMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("1. engineer \n2. developer \n3. manager ");
            Console.WriteLine("Enter the employee number:");
            int i = int.Parse(Console.ReadLine());
            Engineer engineer = new Engineer();
            Developer developer = new Developer();
            Manager manager = new Manager();
            Console.WriteLine("Salary:");
            if (i == 1) ShowSalary(engineer, days, daysInMonth);
            if (i == 2) ShowSalary(developer, days, daysInMonth);
            if (i == 3) ShowSalary(manager, days, daysInMonth);
            Console.Read();
        }

        static void ShowSalary(IEmployee employee, int days, int daysInMonth)
        {
            Console.WriteLine(employee.GetSalary(days, daysInMonth));
        }
    }

    interface IEmployee
    {
        static double _salary;
        public double GetSalary(int days, int daysInMonth);
    }

    class Engineer : IEmployee
    {
        private double _salary = 25000;
        public double GetSalary(int days, int daysInMonth)
        {
            return (_salary * days / daysInMonth)*0.87;
        }
    }

    class Manager : IEmployee
    {
        private double _salary = 26000;
        public double GetSalary(int days, int daysInMonth)
        {
            return (_salary * days / daysInMonth) * 0.87;
        }
    }

    class Developer : IEmployee
    {
        private double _salary = 27000;
        public double GetSalary(int days, int daysInMonth)
        {
            return (_salary * days / daysInMonth) * 0.87;
        }
    }
}
