using System;

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

            //Пример индексатора
            var newUser = new AlsoUser();
            newUser["name"] = "Jack";
            newUser["lastname"] = "Daniel’s";
            Console.WriteLine(newUser["name"] +" "+ newUser["lastname"]);

        }

        public static void DoSomething(int firstvalue, params int[] secondvalue)
        { }
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
    class AlsoUser
    {
        string name;
        string lastname;

        public string this[string param]
        {
            get 
            {
                switch (param)
                {
                    case "name": return $"Name = {name}";
                    case "lastname": return $"Last Name = {lastname}";
                    default: return "";
                }
            }
            set
            {
                switch (param)
                {
                    case "name":
                        name = value;
                        break;
                    case "lastname":
                        lastname = value;
                        break;
                    default: 
                        break;
                }
            }
        }

    }
}
