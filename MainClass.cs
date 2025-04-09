using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.UTF8;
            /*
            int a = 0;
            string text = "Python";
            char taht= 'A';
            double num = 5.4536237287;
            float num1 = 2;
             Console.Write("What is your name? ");
            text = Console.ReadLine();
            Console.WriteLine("Hello!\n" + text);
            Console.WriteLine("Hello!\n{0}", text);
            if (text.ToLower()=="juku")
            {
                Console.WriteLine("Lahme kinno!");
                try
                {
                    Console.WriteLine("{0}\n Kui vana sa oled?", text);
                    int vanus=int.Parse(Console.ReadLine());
                    if (vanus<=0 || vanus>100)
                    {
                        Console.WriteLine("Viga!");
                    }
                    else if (vanus>0 && vanus <=6)
                    {
                        Console.WriteLine("Tasuta");
                    }
                    else if (vanus<= 15)
                    {
                        Console.WriteLine("Lastepilet");
                    }
                    else if (vanus <= 65)
                    {
                        Console.WriteLine("Lastepilet");
                    }
                    else if (vanus <= 100)
                    {
                        Console.WriteLine("Lastepilet");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Olen hõivatud!");
            }
            Console.WriteLine("Number 2: ");
            int num2=int.Parse(Console.ReadLine());
            // Console.WriteLine("Arvude {0} ja {1} korrutis võrdub {2}", num1, num2, num1 *  num2);
            num1=FunktsioonideClass.Calculator(a, num2);
            Console.ReadKey(); */

            // Task Random
            Random rnd = new Random();
            int a = rnd.Next(1, 7);
            Console.WriteLine(a);
            string rndfunc = FunktsioonideClass.switchKasuta(a);
            Console.WriteLine(rndfunc);

            // Task 1 - Соседи по скамейке
            Console.WriteLine("Как тебя зовут?");
            string hum1 = Console.ReadLine();
            Console.WriteLine("Назови второе имя");
            string hum2 = Console.ReadLine();
            string neighbor = FunktsioonideClass.neighbor(hum1, hum2);
            Console.WriteLine(neighbor);

            // Task 2 - Заменить пол
            Console.WriteLine("Длина комнаты?");
            double len=double.Parse(Console.ReadLine());
            Console.WriteLine("Ширина комнаты?");
            double wid = double.Parse(Console.ReadLine());
            Console.WriteLine("Цена за кв.метр?");
            double price = double.Parse(Console.ReadLine());
            double total = FunktsioonideClass.floor(len, wid, price);
            Console.WriteLine("Стоимость замены пола: "+total);

            // Task 3 - Изначальная цена
            Console.WriteLine("Введите цену товара, со скидкой в 30%");
            float v = float.Parse(Console.ReadLine());
            float value = FunktsioonideClass.value(v);
            Console.WriteLine(value);

            // Task 4 - Температура в комнате
            Console.WriteLine("Какая температура в комнате?");
            int t = int.Parse(Console.ReadLine());
            FunktsioonideClass.temp(t);

            // Task 5 - Рост человека
            Console.WriteLine("Какого вы роста?");
            int h = int.Parse(Console.ReadLine());
            FunktsioonideClass.height(h);

            // Task 7 - Магазин
            Console.WriteLine("Хотите ли вы купить молоко? (Да/Нет)");
            bool m = Console.ReadLine().ToLower() == "Да";
            Console.WriteLine("Хотите ли вы купить хлеб? (Да/Нет)");
            bool b = Console.ReadLine().ToLower() == "Да";
            Console.WriteLine("Хотите ли вы купить выпечку? (Да/Нет)");
            bool w = Console.ReadLine().ToLower() == "Да";
            double totals = FunktsioonideClass.shop(m, b, w);
            Console.WriteLine("Стоимость всех продуктов: " + totals);
        }
    }
}
