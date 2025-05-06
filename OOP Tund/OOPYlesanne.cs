using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TARgv24_C_.OOP.Ülesanne.Ülesanne_OOP;

namespace TARgv24_C_.OOP.Ülesanne
{
    public abstract class Isik
    {
        private int sünniaasta;

        public string Nimi { get; set; }

        public int Sünniaasta
        {
            get { return sünniaasta; }
            set
            {
                if (value > 1900 && value <= DateTime.Now.Year)
                    sünniaasta = value;
            }
        }
        public int Vanus => DateTime.Now.Year - sünniaasta;

        public abstract void Kirjelda();
    }

    public class Õpilane : Isik
    {
        public string Kool { get; set; }

        public override void Kirjelda()
        {
            Console.WriteLine($"Õpilane {Nimi} on {Vanus} aastat vana ja õpib koolis {Kool}.");
        }
    }

    public class Õpetaja : Isik
    {
        public string Õppeaine { get; set; }

        public override void Kirjelda()
        {
            Console.WriteLine($"Õpetaja {Nimi} on {Vanus} aastat vana ja õpetab ainet {Õppeaine}.");
        }
    }
}