using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event example");
            BankAccount bankAccount = new BankAccount();
            bankAccount.Notify += DisplayNotification;
            bankAccount.TakeMoney(100);
            bankAccount.AddMoney(5000);
            bankAccount.TakeMoney(2500);
            Console.Read();

            Console.WriteLine();
            Console.WriteLine("List<T> example");
            List<Employee> employes = new List<Employee>();
            employes.Add(new Employee() { Name = "Tom", Salary = 10000 });
            employes.Add(new Employee() { Name = "Ann", Salary = 15000 });
            employes.Add(new Employee() { Name = "Bob", Salary = 15050 });
            Console.WriteLine("All:");
            foreach (var e in employes)
            {
                Console.WriteLine($"Name = {e.Name}, Salary = {e.Salary}");
            }

            Console.WriteLine("Sorted by salary:");
            employes = employes.OrderByDescending(e => e.Salary).ToList();
            foreach (var e in employes)
            {
                Console.WriteLine($"Name = {e.Name}, Salary = {e.Salary}");
            }
            Console.Write("Only Ann salary:");
            var annSalary = employes.Where(e => e.Name == "Ann").Select(e => e.Salary).ToList();
            Console.WriteLine(annSalary[0]);
            Console.Read();

            Console.WriteLine();
            Console.WriteLine("Dictionary<T> example");
            Dictionary<int,Employee> list = new Dictionary<int,Employee>();
            list.Add(1, new Employee() { Name = "Tom", Salary = 10000 });
            list.Add(2, new Employee() { Name = "Ann", Salary = 15000 });
            list.Add(3, new Employee() { Name = "Bob", Salary = 15050 });
            foreach (var l in list)
            {
                Console.WriteLine($"i = {l.Key} Name = {l.Value.Name}, Salary = {l.Value.Salary}");
            }
            foreach (var l in list)
            {
                if (l.Key == 2)
                Console.WriteLine($"Second employee: Name = {l.Value.Name}, Salary = {l.Value.Salary}");
            }
            Console.Read();

        }

        //Обработчик события
        private static void DisplayNotification(string message)
        {
            Console.WriteLine(message);
        }
    }


    class BankAccount
    {
        private float _balance = 0;
        public delegate void Handler(string message);
        public event Handler Notify;
        public void AddMoney(float sum)
        {
            if (sum > 0) 
            { 
                _balance += sum;
                Notify?.Invoke($"Balance = {_balance}");
            }
        }

        public void TakeMoney(float sum)
        {
            if (_balance >= sum)
            {
                _balance -= sum;
                Notify?.Invoke($"Balance = {_balance}");
            }
            else Notify?.Invoke("Operation denied");
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public float Salary { get; set; }
    }
}
