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
        public Color kolor = Color.Violet;


        public Wierzcholek(int x, int y,Wielokant wiel,Color kol)
        {
            this.x = x;
            this.y = y;
            wielok = wiel;
            kolor = kol;
        }
        public Wierzcholek(int x, int y, Wielokant wiel)
        {
            this.x = x;
            this.y = y;
            wielok = wiel;
          
        }
        public void Rysuj(DirectBitmap bitmapa)
        {
            if (x >= 0 && y >= 0 && x <= bitmapa.Width - 1 && y <= bitmapa.Height - 1)
                bitmapa.SetPixel(x, y, kolor);
            if (x > 1 && y > 1 && x < bitmapa.Width - 1 && y < bitmapa.Height - 1)
            {
                bitmapa.SetPixel(x+1, y+1, kolor);
                bitmapa.SetPixel(x+1, y, kolor);
                bitmapa.SetPixel(x+1, y-1, kolor);
                bitmapa.SetPixel(x, y+1, kolor);
                bitmapa.SetPixel(x, y-1, kolor);
                bitmapa.SetPixel(x-1, y+1, kolor);
                bitmapa.SetPixel(x-1, y, kolor);
                bitmapa.SetPixel(x-1, y-1, kolor);

            }
        }

    }
}
