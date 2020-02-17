using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Wierzcholek
    {
        public int x, y;
        public Wielokant wielok;
        public Krawendz p = null;
        public Krawendz n = null;
        public Wierzcholek wrown1 = null;
        public Wierzcholek wrown2 = null;
        public Wierzcholek wprost1 = null;
        public Wierzcholek wprost2 = null;


        public Wierzcholek(int x, int y,Wielokant wiel)
        {
            this.x = x;
            this.y = y;
            wielok = wiel;
        }
        public void Rysuj(Bitmap bitmapa)
        {
            if (x >= 0 && y >= 0 && x <= bitmapa.Width - 1 && y <= bitmapa.Height - 1)
                bitmapa.SetPixel(x, y, Color.DarkViolet);
            if (x > 1 && y > 1 && x < bitmapa.Width - 1 && y < bitmapa.Height - 1)
            {
                bitmapa.SetPixel(x+1, y+1, Color.DarkViolet);
                bitmapa.SetPixel(x+1, y, Color.DarkViolet);
                bitmapa.SetPixel(x+1, y-1, Color.DarkViolet);
                bitmapa.SetPixel(x, y+1, Color.DarkViolet);
                bitmapa.SetPixel(x, y-1, Color.DarkViolet);
                bitmapa.SetPixel(x-1, y+1, Color.DarkViolet);
                bitmapa.SetPixel(x-1, y, Color.DarkViolet);
                bitmapa.SetPixel(x-1, y-1, Color.DarkViolet);

            }
        }

    }
}
