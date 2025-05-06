using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_.OOP
{
    internal class MainClassOOP
    {
        static void Main(string[] args)
        {   //1.1
            Inimene inimene = new Inimene("Matviei",20);
            inimene.Tervita();
            
            //2.2
            Töötaja töötaja = new Töötaja("Matviei", 20, "Developer");
            töötaja.Töötan();
            
            //3.3
            Koer koer = new Koer();
            koer.Nimi = "Rex";  

            Console.WriteLine("Koera nimi on: " + koer.Nimi);
            koer.TeeHääl();
            
            //4.4
            Pank pank = new Pank();

            pank.Saldo = 100.0; 
            Console.WriteLine("Saldo: " + pank.Saldo); 

            pank.Saldo = -50.0;  
            Console.WriteLine("Saldo: " + pank.Saldo);

            //5.5
            IHeliline kass = new Kass();
            kass.TeeHääl();
        }
    }
}