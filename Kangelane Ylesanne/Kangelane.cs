using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp.Kangelane
{
    class Kangelane
    {
        private string nimi;
        private string asukoht;

        public string Nimi { get; set; }
        public string Asukoht { get; set; }

        public Kangelane(string nimi, string asukoht)
        {
            Nimi = nimi;
            Asukoht = asukoht;
        }

        public virtual int Paasta(int ohus)
        {
            int protsent_ohus = (int)Math.Round(ohus * 0.95);

            return protsent_ohus;
        }

        public virtual string Vormiriietus()
        {
            string riietus = "Tavaline kangelase kostüüm – mask ja mantel";

            return riietus;
        }

        public virtual string Tervitus()
        {
            string tervitus = "Tere! Mina olen " + Nimi + "ja ma olen kangelane!";

            return tervitus;
        }

        public virtual string MissiooniStaatus()
        {
            string staatus = $"{Nimi} on saadaval missiooniks!";

            return staatus;
        }

        public override string ToString()
        {
            string kirjeldus = $"{Nimi} on kangelane, kes asub {Asukoht} ja on valmis päästma inimesi hädast!";

            return kirjeldus;
        }


    }
}