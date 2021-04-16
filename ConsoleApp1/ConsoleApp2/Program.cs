using System;
using Moneys = Money.Money;

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
            Engineer<Money.Dollar> engineer = new Engineer<Money.Dollar>();
            Developer<Money.Euro> developer = new Developer<Money.Euro>();
            Manager<Money.Ruble> manager = new Manager<Money.Ruble>();
            Console.WriteLine("Salary:");
            if (i == 1) ShowSalary<Money.Dollar>(engineer, days, daysInMonth);
            if (i == 2) ShowSalary<Money.Euro>(developer, days, daysInMonth);
            if (i == 3) ShowSalary<Money.Ruble>(manager, days, daysInMonth);
            Console.Read();
        }

        static void ShowSalary<T>(IEmployee<T> employee, int days, int daysInMonth) where T : Moneys
        {
            Calculator<T> calculator = new Calculator<T>();
            Console.WriteLine(calculator.CalcSalary(employee, days, daysInMonth));
        }
    }

    interface IEmployee<T> where T: Moneys
    {
        static double _salary;
        public T GetSalary();
    }

    class Calculator<T> where T : Moneys
    {
        public double CalcSalary(IEmployee<T> employee, int days, int daysInMonth)
        {
            return (employee.GetSalary().Convert() * days / daysInMonth) * 0.87;
        }
    }
    class Engineer<T>: IEmployee<T> where T : Moneys, new()
    {
        private double _salary = 25000;
        public T GetSalary()
        {
            return new T(){ money = _salary};
        }
    }

    class Manager<T>: IEmployee<T> where T : Moneys, new()
    {
        private double _salary = 26000;
        public T GetSalary()
        {
            return new T() { money = _salary };
        }
    }

    class Developer<T> : IEmployee<T> where T : Moneys, new()
    {
        private double _salary = 27000;
        public T GetSalary()
        {
            return new T() { money = _salary };
        }
    }
}
