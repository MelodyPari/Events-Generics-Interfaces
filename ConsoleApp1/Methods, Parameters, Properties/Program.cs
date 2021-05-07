using System;
using System.Collections.Generic;

namespace Methods__Parameters__Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Есть класс с двумя конструкторами: статическим и обычным. Какой порядок вызова конструктуров при создании объекта?
            //Для первого экземпляра вызовутся: 1. статический и 2. нестатический конструкторы
            //Для остальных вызовется только нестатический конструктор
            //Наличие статического поля не влияет на порядок вызова конструкторов
            User user = new User();
            User user2 = new User();
            User user3 = new User();
            
            DoSomething(4, new[] { 5, 5, 5, 5 });
            DoSomething(4, 5, 5, 5, 5, 5); //Обнаружив такой вызов, компилятор C# проверяет все методы с заданным именем, у которых ни один из 
                                           //параметров не помечен атрибутом ParamArray. Найдя метод, способный принять вызов, компилятор генерирует
                                           //вызывающий его код.
                                           //В противном случае ищутся методы с атрибутом ParamArray и проверяется, могут ли они принять вызов. 
                                           //Если компилятор находит подходящий метод, то прежде чем сгенерировать код его вызова, 
                                           //он генерирует код, создающий и заполняющий массив.

            //Пример индексатора (2 индексатора)
            var city = new City();
            Console.WriteLine(city["Cardiff"] +" "+ city[2]);

            //пример метода-расширения: вход - строка, выход строка + ! (Hello -> Hello!)
            string h = "Hello";
            Console.WriteLine(h.AddExclamationMark());

            //пример ref/out
            int a = 5;
            int b = 10;
            int c;
            int d;
            Add1(a, b, out c);
            Console.WriteLine(c);
            a = 10;
            Add2(a, b, ref d);//Вызовет ошибку компиляции
            Add2(a, b, ref c);//c - инициализирована при вызове метода add1 => ошибки не будет
            Console.WriteLine(c);
            a = 20;
            var sum = Add3(a, b, ref c);
            Console.WriteLine(c); // метод Add3 не меняет значение c, поэтому выводится то значение, что было до его вызова 



        }
        public static void Add1(int a, int b, out int c)
        {
            //при использования ключевого слова out обязательно нужно в соответствующую переменную записать какое-нибудь значение
            //так как out обозначает выходной параметр => ему может быть передана неинициализированная переменная
           
            c = a + b;
        }
        public static void Add2(int a, int b, ref int c)
        {
            //при использования ключевого слова ref, не обязательно изменять значение переменной
            //так как c ref нельзя передать неинициализированную переменную
            c = a + b;
        }
        public static int Add3(int a, int b, ref int c)
        {
            //при использования ключевого слова ref, не обязательно изменять значение переменной
            //так как c ref нельзя передать неинициализированную переменную
            return c > a + b ? a+b : c;
        }
        public static void DoSomething(int firstvalue, params int[] secondvalue)
        { }
    }
    public static class StringExtension
    {
        public static string AddExclamationMark(this string str)
        {
            return str + "!";
        }
    }
    class User
    {
        static int a = 1;
        static User()
        { 
        }
        public User()
        { 
        }

    }
    class City
    {
        
        List<string> list = new List<string>() { "Bristol", "Cardiff", "Liverpool" };

        public string this[string param]
        {
            set 
            {
                list.Add(param);
            }
            get 
            {
                return list.IndexOf(param).ToString();
            }
            
        }
        public string this[int param]
        {
            get
            {
                return list[param];
            }

        }

    }
}
