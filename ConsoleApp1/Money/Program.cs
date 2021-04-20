using System;

namespace Money
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dollar d = new Dollar() { money = 5 };
            Ruble r = new Ruble() { money = 5 };
            Console.WriteLine(d > r);
            Console.WriteLine((d+r).money);
            Console.WriteLine((d-r).money);
        }
        
        
       
    }
    public class Dollar : Money
    {
        public const double dollar = 70;
        public override double Convert()
        {
            return money * dollar;
        }
    }
    public class Euro : Money
    {
        public const double euro = 100;
        public override double Convert()
        {
            return money*euro;
        }
    }
    public class Ruble : Money
    {
        
    }
    public interface IMoney
    {
        public static double money;
        public double Convert();

    }
    public class Money: IMoney
    {
        public double money;
        public virtual double Convert()
        {
            return money;
        }
        public static Money operator +(Money money1, Money money2)
        {
            return new Money() { money = money1.Convert() + money2.Convert() };
        }
        public static Money operator -(Money money1, Money money2)
        {
            return new Money() { money = money1.Convert() - money2.Convert() };
        }
        public static bool operator >(Money money1, Money money2)
        {
            return money1.Convert() > money2.Convert();
        }
        public static bool operator <(Money money1, Money money2)
        {
            return money1.Convert() < money2.Convert();
        }

    }
}
