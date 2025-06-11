using System;
using System.Collections.Generic;

namespace TARgv24_C_._3.Tund
{
    internal enum Sugu
    {
        Mees,
        Naine
    }

    internal class Isik
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; }
        public string Isikukood { get; set; }
        public string Aadress { get; set; }
        public Sugu Sugu { get; set; }

        public Isik() { }

        public Isik(string nimi, int vanus, string isikukood, string aadress)
        {
            Nimi = nimi;
            Vanus = vanus;
            Isikukood = isikukood;
            Aadress = aadress;
            Sugu = Sugu.Mees;
        }

        public void PrindiInfo()
        {
            Console.WriteLine($"Nimi: {Nimi}, Vanus: {Vanus}, Isikukood: {Isikukood}, Aadress: {Aadress}, Sugu: {Sugu}");
        }
    }

    internal static class ArvuTöötlus
    {
        public static (int[] ruudud, int[] arvud) GenereeriRuudud(int min, int max, int kogus = 10)
        {
            Random rnd = new Random();
            int[] arvud = new int[kogus];
            int[] ruudud = new int[kogus];

            for (int i = 0; i < kogus; i++)
            {
                int arv = rnd.Next(min, max + 1);
                arvud[i] = arv;
                ruudud[i] = arv * arv;
            }

            return (ruudud, arvud);
        }
    }

    internal static class FunktsioonideClass3
    {
        public static Isik[] Isikud(int count, string[] nimed, string[] aadressid)
        {
            Random rnd = new Random();
            Isik[] isikud = new Isik[count];

            for (int i = 0; i < count; i++)
            {
                isikud[i] = new Isik
                {
                    Nimi = nimed[i % nimed.Length],
                    Aadress = aadressid[i % aadressid.Length],
                    Vanus = rnd.Next(10, 100),
                    Isikukood = rnd.Next(100000000, 999999999).ToString() + rnd.Next(10, 99).ToString(),
                    Sugu = (Sugu)rnd.Next(0, 2)
                };
            }

            return isikud;
        }

        public static List<Isik> Isikud2(int count, string[] nimed, string[] aadressid)
        {
            Random rnd = new Random();
            List<Isik> isikud = new List<Isik>();

            for (int i = count - 1; i >= 0; i--)
            {
                isikud.Add(new Isik
                {
                    Nimi = nimed[i % nimed.Length],
                    Aadress = aadressid[i % aadressid.Length],
                    Vanus = rnd.Next(10, 100),
                    Isikukood = rnd.Next(100000000, 999999999).ToString() + rnd.Next(10, 99).ToString(),
                    Sugu = (Sugu)rnd.Next(0, 2)
                });
            }

            return isikud;
        }
    }

    internal class MainProgram
    {
        public static void Main(string[] args)
        {
            // --- Ülesanne 1: Juhuslikud ruudud
            (int[] ruudud, int[] arvud) = ArvuTöötlus.GenereeriRuudud(-100, 100);
            for (int j = 0; j < ruudud.Length; j++)
            {
                Console.WriteLine($"{arvud[j]} -> {ruudud[j]}");
            }

            // --- Ülesanne 3: Isikud
            Isik isik1 = new Isik("Juku", 18, "12345678901", "Tallinn");
            isik1.PrindiInfo();

            Isik isik2 = new Isik
            {
                Nimi = "Mari",
                Aadress = "Tartu",
                Isikukood = "98765432101",
                Sugu = Sugu.Naine
            };
            isik2.PrindiInfo();

            string[] nimed = { "Juku", "Mari", "Kati", "Peeter", "Mati", "Liina", "Katrin", "Andres", "Marko", "Kristi" };
            string[] aadressid = { "Tallinn", "Tartu", "Pärnu", "Narva", "Kohtla-Järve", "Viljandi", "Rakvere", "Paide", "Jõhvi", "Kuressaare" };

            Console.WriteLine("----- for++ Massiv -------");
            Isik[] isikud = FunktsioonideClass3.Isikud(nimed.Length, nimed, aadressid);
            foreach (Isik isik in isikud)
                isik.PrindiInfo();

            Console.WriteLine("----- for-- List -------");
            List<Isik> isikud2 = FunktsioonideClass3.Isikud2(nimed.Length, nimed, aadressid);
            foreach (Isik isik in isikud2)
                isik.PrindiInfo();

            // --- Ülesanne 4: Märksõna
            KuniMärksõnani("elevant", "Osta elevant ära!");

            // --- Ülesanne 5: Arva arv
            ArvaArv();

            // --- Ülesanne 9: Arvude töötlus
            int[] arvud_1 = { 2, 4, 6, 8, 10, 12 };
            foreach (var arv in arvud_1)
                Console.WriteLine($"{arv} ruut on {arv * arv}");

            foreach (var arv in arvud_1)
                Console.WriteLine($"{arv} kahekordne väärtus on {arv * 2}");

            int jaguvadKolmega = 0;
            foreach (var arv in arvud_1)
            {
                if (arv % 3 == 0)
                    jaguvadKolmega++;
            }
            Console.WriteLine($"Kolmega jaguvate arvude koguarv: {jaguvadKolmega}");

            Console.WriteLine("Arvud, mis jaguvad kolmega:");
            foreach (var arv in arvud_1)
            {
                if (arv % 3 == 0)
                    Console.WriteLine(arv);
            }

            // --- Ülesanne 10: Pos/Neg/Null
            int[] arvud_2 = { 5, -3, 0, 8, -1, 4, -7, 2, 0, -5, 6, 9 };
            int positiivsed = 0, negatiivsed = 0, nullid = 0;

            foreach (var arv in arvud_2)
            {
                if (arv > 0) positiivsed++;
                else if (arv < 0) negatiivsed++;
                else nullid++;
            }

            Console.WriteLine($"Positiivseid arve: {positiivsed}");
            Console.WriteLine($"Negatiivseid arve: {negatiivsed}");
            Console.WriteLine($"Nulle: {nullid}");

            // --- Loendurid
            Console.WriteLine("--------- while ----------");
            int i = 10;
            while (i >= 0)
            {
                Console.WriteLine(i);
                i--;
            }

            Console.WriteLine("--------- do ----------");
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Press Backspace to exit");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Backspace);
        }

        static void KuniMärksõnani(string märksõna, string fraas)
        {
            List<string> vastused = new List<string>();
            string sisend;
            do
            {
                Console.Write($"\n{fraas}\nSisesta märksõna: ");
                sisend = Console.ReadLine();
                vastused.Add(sisend);

                if (sisend == märksõna)
                {
                    Console.WriteLine("Õige vastus, tubli!");
                }

            } while (sisend != märksõna);

            Console.WriteLine("\nKõik sisetatud vastused:");
            foreach (var vastus in vastused)
                Console.WriteLine(vastus);
        }

        static void ArvaArv()
        {
            Random rnd = new Random();
            int arv = rnd.Next(1, 101);
            int katsed = 5;
            int vastus;

            do
            {
                Console.Write("Arva ära arv (1-100): ");
                vastus = int.Parse(Console.ReadLine());

                if (vastus > arv)
                {
                    Console.WriteLine("Liiga suur!");
                }
                else if (vastus < arv)
                {
                    Console.WriteLine("Liiga väike!");
                }
                else
                {
                    Console.WriteLine("\nÕige arv!");
                    return;
                }
                katsed--;
            } while (katsed > 0);

            Console.WriteLine($"\nKaotasid! Õige arv oli {arv}");
        }
    }
}
