using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_
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
        public Sugu Sugu { get; set; } = Sugu.Mees;
        public Isik() { }
        public Isik(string nimi, int vanus, string isikukood, string aadress)
        {
            Nimi = nimi;
            Vanus = vanus;
            Isikukood = isikukood;
            Aadress = aadress;
        }
        public void PrindiInfo()
        {
            Console.WriteLine($"Nimi: {Nimi}, Vanus: {Vanus}, Isikukood: {Isikukood}, Aadress: {Aadress}, Sugu: {Sugu}.");
        }
    }
}
