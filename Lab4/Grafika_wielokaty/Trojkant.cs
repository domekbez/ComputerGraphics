using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Trojkant:Wielokant
    {
        public bool jestWSrodku(int x, int y)
        {
            double x1 = wierzcholki[0].pozycjaEkran.wek[0];
            double x2 = wierzcholki[1].pozycjaEkran.wek[0];
            double x3 = wierzcholki[2].pozycjaEkran.wek[0];
            double y1 = wierzcholki[0].pozycjaEkran.wek[1];
            double y2 = wierzcholki[1].pozycjaEkran.wek[1];
            double y3 = wierzcholki[2].pozycjaEkran.wek[1];
            
            double a = ((y2 - y3) * (x - x3) + (x3 - x2) * (y - y3)) / ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
            double b = ((y3 - y1) * (x - x3) + (x1 - x3) * (y - y3)) / ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
            double c = 1 - a - b;

            if (a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1) return true;
            else return false;
        }
        
    }
}
