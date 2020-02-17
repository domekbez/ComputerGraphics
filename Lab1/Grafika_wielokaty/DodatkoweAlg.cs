using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class DodatkoweAlg
    {
        public static int obliczPromien(int x0, int y0, int x1, int y1)
        {
            return (int)Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
        }
        public static bool czyBlisko(int x, int y, int a, int b)
        {
            return Math.Sqrt((x - a) * (x - a) + (y - b) * (y - b)) < 17;
        }
        public static double odlegloscWierzch(int x,int y,int a, int b)
        {
            return Math.Sqrt((x - a) * (x - a) + (y - b) * (y - b));
        }
    }
}
