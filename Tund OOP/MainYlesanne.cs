using System;

namespace TARgv24_C_.OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1.1 Inimene ===");
            Inimene inimene = new Inimene("Matviei", 20);
            inimene.Tervita();

            Console.WriteLine("\n=== 2.2 Töötaja ===");
            Töötaja töötaja = new Töötaja("Matviei", 20, "Developer");
            töötaja.Töötan();

            Console.WriteLine("\n=== 3.3 Koer ===");
            Koer koer = new Koer { Nimi = "Rex" };
            Console.WriteLine("Koera nimi on: " + koer.Nimi);
            koer.TeeHääl();

            Console.WriteLine("\n=== 4.4 Pank ===");
            Pank pank = new Pank();
            pank.Saldo = 100.0;
            Console.WriteLine("Saldo: " + pank.Saldo);
            pank.Saldo = -50.0;
            Console.WriteLine("Saldo: " + pank.Saldo);

            Console.WriteLine("\n=== 5.5 Kass (IHeliline) ===");
            IHeliline kass = new Kass();
            kass.TeeHääl();

            Console.WriteLine("\n=== Ülesanne: Õpilane ja Õpetaja ===");
            var õpilane = new Ülesanne.Õpilane { Nimi = "Jaan", Sünniaasta = 2005, Kool = "Tallinna Ülikool" };
            var õpetaja = new Ülesanne.Õpetaja { Nimi = "Mari", Sünniaasta = 1980, Õppeaine = "Matemaatika" };

            õpilane.Kirjelda();
            õpetaja.Kirjelda();

            Console.ReadKey();
        }
    }
}
