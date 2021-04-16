using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event and generic example");
            BankAccount<Employee, int> bankAccount = new BankAccount<Employee, int>();
            bankAccount.owner = new Employee() { Name = "Tom", Salary = 10000 };
            bankAccount.limit = 10000000;

            bankAccount.Notify += DisplayNotification;
            bankAccount.TakeMoney(100);
            bankAccount.AddMoney(5000);
            bankAccount.TakeMoney(2500);
            bankAccount.NotifyCount();
 
            Console.Read();

            Console.WriteLine();

            //List<T> example
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

            //Разница между:
            var res1 = employes.Find(x => x.Name == "Ann");//Возвращает первый найденный в List элемент удовлетворяющий условию 
            Console.WriteLine($"Name = {res1.Name}, Salary = {res1.Salary}"); //или дефолтное значение для типа (здесь null)

            var res2 = employes.First(x => x.Name == "Ann");//Возвращает первый найденный элемент удовлетворяющий условию
            Console.WriteLine($"Name = {res2.Name}, Salary = {res2.Salary}");//или вызывает exception

            var res3 = employes.FirstOrDefault(x => x.Name == "Ann");////Возвращает первый найденный элемент удовлетворяющий условию 
            Console.WriteLine($"Name = {res3.Name}, Salary = {res3.Salary}");//или дефолтное значение для типа (здесь null)
            Console.Read();

            //Dictionary<T> example
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


    class BankAccount<T, T2> where T: class
                             where T2: struct
    {
        public T owner;
        public T2 limit;
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

        public void NotifyCount()
        {
            Notify?.Invoke($"Count = {Notify.GetInvocationList().Length}");
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public float Salary { get; set; }
    }
}
