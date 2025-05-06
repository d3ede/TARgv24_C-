using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_.Madu
{
    class HorisontalLine
    {
        List<Point> plist;
        public HorisontalLine(int xLeft, int xRight, int y, char sym)
        {
            plist = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            { 
                Point p = new Point(x,y,sym);
                plist.Add(p); 
            }
           
        }
        public void Drow()
        {
            foreach (Point p in plist)
            {
                p.Draw();
            }
        }
    }
}