/* using System;
using System.Collections.Generic;
using System.Linq;

namespace RegionsAndCapitals
{
    class Program
    {
        static Dictionary<string, string> regionToCapital = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        static Dictionary<string, string> capitalToRegion = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            InitData();

            while (true)
            {
                Console.WriteLine("\nВыберите режим:");
                Console.WriteLine("1 - Найти графство по столице");
                Console.WriteLine("2 - Найти столицу по графству");
                Console.WriteLine("3 - Добавить новую пару");
                Console.WriteLine("4 - Режим игры");
                Console.WriteLine("0 - Выход");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": FindRegionByCapital(); break;
                    case "2": FindCapitalByRegion(); break;
                    case "3": AddNewPair(); break;
                    case "4": QuizMode(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        }

        static void InitData()
        {
            AddPair("Harjumaa", "Tallinn");
            AddPair("Tartumaa", "Tartu");
            AddPair("Ida-Virumaa", "Jõhvi");
        }

        static void AddPair(string region, string capital)
        {
            regionToCapital[region] = capital;
            capitalToRegion[capital] = region;
        }

        static void FindRegionByCapital()
        {
            Console.Write("Введите название столицы: ");
            string capital = Console.ReadLine();
            if (capitalToRegion.TryGetValue(capital, out string region))
                Console.WriteLine($"Графство: {region}");
            else
                AskToAdd(capital, false);
        }

        static void FindCapitalByRegion()
        {
            Console.Write("Введите название графства: ");
            string region = Console.ReadLine();
            if (regionToCapital.TryGetValue(region, out string capital))
                Console.WriteLine($"Столица: {capital}");
            else
                AskToAdd(region, true);
        }

        static void AskToAdd(string name, bool isRegion)
        {
            Console.WriteLine("Данные не найдены. Хотите добавить? (да/нет)");
            string response = Console.ReadLine();
            if (response.ToLower().StartsWith("д"))
            {
                if (isRegion)
                {
                    Console.Write("Введите столицу для графства: ");
                    string capital = Console.ReadLine();
                    AddPair(name, capital);
                }
                else
                {
                    Console.Write("Введите графство для столицы: ");
                    string region = Console.ReadLine();
                    AddPair(region, name);
                }
                Console.WriteLine("Пара добавлена.");
            }
        }

        static void QuizMode()
        {
            Random rnd = new Random();
            var keys = regionToCapital.Keys.ToList();
            int total = 0, correct = 0;

            while (true)
            {
                bool askRegion = rnd.Next(2) == 0;

                if (askRegion)
                {
                    string region = keys[rnd.Next(keys.Count)];
                    Console.Write($"Какая столица у графства {region}?: ");
                    string answer = Console.ReadLine();
                    if (string.Equals(answer, regionToCapital[region], StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Верно!");
                        correct++;
                    }
                    else
                        Console.WriteLine($"Неверно. Правильный ответ: {regionToCapital[region]}");
                }
                else
                {
                    string capital = capitalToRegion.Keys.ToList()[rnd.Next(capitalToRegion.Count)];
                    Console.Write($"Какое графство у столицы {capital}?: ");
                    string answer = Console.ReadLine();
                    if (string.Equals(answer, capitalToRegion[capital], StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Верно!");
                        correct++;
                    }
                    else
                        Console.WriteLine($"Неверно. Правильный ответ: {capitalToRegion[capital]}");
                }

                total++;

                Console.Write("Продолжить? (да/нет): ");
                if (!Console.ReadLine().ToLower().StartsWith("д"))
                    break;
            }

            Console.WriteLine($"\nРезультат: {correct}/{total} правильных ({(correct * 100 / total)}%)");
        }
    }
}