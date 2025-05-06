using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_.Madu
{
    class Program
    {
        static void Main(string[] args)
        {   
            Point p1 = new Point(1,3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            HorisontalLine line = new HorisontalLine(5,10,8,'+');
            line.Drow();


            Console.SetWindowSize(80, 25);


            //Границы поля
            HorisontalLine upLine= new HorisontalLine( 0, 78, 0, '=');
            HorisontalLine downLine = new HorisontalLine(0, 78, 24, '=');
            VertikalLine leftLine = new VertikalLine(0, 24, 0, '=');
            VertikalLine rightLine = new VertikalLine(0,24, 78,'=');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p = new Point(4,5,'*');
            p.Draw();


            Console.ReadLine();
        }
      
    }
}