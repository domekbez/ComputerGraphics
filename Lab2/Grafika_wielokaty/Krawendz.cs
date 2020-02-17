using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Krawendz
    {
        public Wierzcholek a, b;
        public Krawendz odpowkrawendz = null;
        public Color kolor = Color.Black;
        public Krawendz(Wierzcholek x, Wierzcholek y)
        {
            a = x;
            b = y;
        }
        public double odleglosc()
        {
            return Math.Sqrt((float)((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y)));
        }
    }
}
