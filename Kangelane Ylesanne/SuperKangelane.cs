using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp.Kangelane
{
    class SuperKangelane : Kangelane
    {
        public double Osavus { get; set; }

        public SuperKangelane(string nimi, string asukoht) : base(nimi, asukoht) 
        {
            Random rnd = new Random();
            Osavus = Math.Round(rnd.NextDouble() * (5.0 - 1.0) + 1.0, 2);
        }

        public override int Paasta(int ohus)
        {
            double protsent = 95 + Osavus;
            int protsent_ohus = (int)Math.Round(ohus * protsent / 100);

            return protsent_ohus;
        }

        public override string Vormiriietus()
        {
            string riietus = "Hõljuv neoonkostüüm tuleleegiga";

            return riietus;
        }

        public override string Tervitus()
        {
            string tervitus = "Tere! Mina olen " + Nimi + "ja ma olen superkangelane!";

            return tervitus;
        }

        public override string MissiooniStaatus()
        {
            string staatus = $"{Nimi} on juba missioonil!";

            return staatus;
        }

        public override string ToString()
        {
            string kirjeldus_osavus = $"{Nimi} on superkangelane, kes asub {Asukoht} ja on valmis päästma inimesi hädast! Tema osavus on {Osavus}";

            return kirjeldus_osavus;
        }
    }
}