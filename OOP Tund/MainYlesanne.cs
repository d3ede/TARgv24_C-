using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_.OOP.Ülesanne
{
    internal class MainÜlesanne
    {
        static void Main(string[] args)
        {
            Õpilane õpilane = new Õpilane { Nimi = "Jaan", Sünniaasta = 2005, Kool = "Tallinna Ülikool" };
            Õpetaja õpetaja = new Õpetaja { Nimi = "Mari", Sünniaasta = 1980, Õppeaine = "Matemaatika" };

            õpilane.Kirjelda();
            õpetaja.Kirjelda();
        }
    }
}