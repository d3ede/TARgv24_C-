using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_.OOP
{    
    //1.1
    public class Inimene
    {
        public string Nimi;
        public int Vanus;

        public Inimene(string nimi, int vanus)
        {
            Nimi = nimi;
            Vanus = vanus;
        }

        public void Tervita()
        {
            Console.WriteLine("Tere! Mina olen " + Nimi + " ja ma olen " + Vanus + " aastat vana.");
        }
    }
    //2.2
    public class Töötaja : Inimene
    {
        public string Ametikoht;

        public Töötaja(string nimi, int vanus, string ametikoht)
            : base(nimi, vanus)
        {
            Ametikoht = ametikoht;
        }

        public void Töötan()
        {
            Console.WriteLine($"{Nimi} töötab ametikohal {Ametikoht}.");
        }
    }
    //3.3
    public abstract class Loom
    {
        public string Nimi;

        public abstract void TeeHääl();
    }

    public class Koer : Loom
    {
        public override void TeeHääl()
        {
            Console.WriteLine("Auh-auh!");
        }
    }
    //4.4
    public class Pank
    {
        private double saldo;

        public double Saldo
        {
            get { return saldo; }
            set
            {
                if (value >= 0)
                    saldo = value;
            }
        }
    }
    //5.5
    public interface IHeliline
    {
        void TeeHääl();
    }

    public class Kass : IHeliline
    {
        public void TeeHääl()
        {
            Console.WriteLine("Mjäu!");
        }
    }

}