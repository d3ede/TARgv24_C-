using System;
using System.Collections.Generic;

namespace TARgv24_C_._3.Tund
{
    internal class MainClass3osa
    {
        public static void Main(string[] args)
        {
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
            {
                isik.PrindiInfo();
            }

            Console.WriteLine("----- for-- List -------");
            List<Isik> isikud2 = FunktsioonideClass3.Isikud2(nimed.Length, nimed, aadressid);

            foreach (Isik isik in isikud2)
            {
                isik.PrindiInfo();
            }

            Console.WriteLine("--------- while ----------");
            int i = 10;
            while (i >= 0)
            {
                Console.WriteLine(i);
                i--;
            }

            Console.WriteLine("--------- do ----------");
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.WriteLine("Press Backspace to exit");
                key = Console.ReadKey();
            }
            while (key.Key != ConsoleKey.Backspace);

            Console.ReadKey();
        }
    }
}
