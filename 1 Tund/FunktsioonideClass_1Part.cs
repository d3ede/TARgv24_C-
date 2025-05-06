using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TARgv24_C_
{
    internal class FunktsioonideClass_1Part
    {
        public static float Calculator(int num1, int num2)
        {
            float calculator = 0;
            calculator = num1 * num2;
            return calculator;
        }
        public static string switchKasuta(int a)
        {
            string text = "";
            switch (a)
            {
                case 1: text = "E"; break;
                case 2: text = "T"; break;
                case 3: text = "K"; break;
                case 4: text = "N"; break;
                case 5: text = "R"; break;
                case 6: text = "L"; break;
                case 7: text = "P"; break;

                default:
                    {
                        text = "Tundmatu";
                        break;
                    }
            }
            return text;
        }
        public static string neighbor(string hum1, string hum2)
        {
            string text = "Сегодня " + hum1 + " и " + hum2 + " будут соседями по скамейке";
            return text;
        }
        public static void temp(int t)
        {
            try
            {
                if (t < 18)
                {
                    Console.WriteLine("В комнате слишком холодно, всего лишь" + t + " градусов");
                }
                else
                {
                    Console.WriteLine("В комнате приемлемая температура - " + t + " градусов");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static float value(float v)
        {
            float value = v / 70 * 100;
            return value;
        }
        public static void height(int h)
        {
            try
            {
                if (h <= 160)
                {
                    Console.WriteLine("Вы низкий");
                }
                else if (h < 180)
                {
                    Console.WriteLine("Вы среднего роста");
                }
                else if (h >= 180)
                {
                    Console.WriteLine("Вы высокий");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static double floor(double len, double wid, double price)
        {
            double area = len * wid;
            return area * price;
        }
        public static double shop(bool m, bool b, bool w)
        {
            double mp = 80;
            double bp = 50;
            double wp = 120;
            double total = 0;
            if (m) total += mp;
            if (b) total += bp;
            if (w) total += wp;
            return total;
        } 
    }
}
