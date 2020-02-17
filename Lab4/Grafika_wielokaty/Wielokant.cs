using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Wielokant
    {
        public Color kolor;   
        public List<Wierzcholek> wierzcholki;
        

        public Wielokant()
        {
            wierzcholki = new List<Wierzcholek>();
        }
        public void Rysuj(DirectBitmap bitmapa)
        {
            int n = wierzcholki.Count;
            
            if (n == 1)
            {
                bitmapa.SetPixel((int)wierzcholki[0].x, (int)wierzcholki[0].y, kolor);
                return;
            }
           
            for (int i=0;i<n;i++)
            {
                if(wierzcholki[i].n!=null)
                    Bresenham.bresenhamLinia(bitmapa, (int)wierzcholki[i].x, (int)wierzcholki[i].y, (int)wierzcholki[(i + 1) %n ].x, (int)wierzcholki[(i + 1) % n].y,wierzcholki[i].n.kolor);
                else
                    Bresenham.bresenhamLinia(bitmapa, (int)wierzcholki[i].x, (int)wierzcholki[i].y, (int)wierzcholki[(i + 1) % n].x, (int)wierzcholki[(i + 1) % n].y, kolor);

            }
        }

        public void tablicaWierzcholkow(Wierzcholek[,] tabwierzch,DirectBitmap bitmapa)
        {
            foreach (var el in wierzcholki)
            {
                if (el.x >= 0 && el.y >= 0 && el.x < bitmapa.Width && el.y < bitmapa.Height)
                    tabwierzch[(int)el.x, (int)el.y] = el;
            }
        }
        public void wyczyscTabWierzch(Wierzcholek[,] tabwierzch,DirectBitmap bitmapa)
        {
            foreach (var el in wierzcholki)
            {
                if(el.x>=0&&el.y>=0&&el.x<bitmapa.Width&&el.y<bitmapa.Height)
                tabwierzch[(int)el.x, (int)el.y] = null;
            }
        }
        public void tablicaKrawedzi(Krawendz[,] tabkraw, DirectBitmap bitmapa)
        {
            int n = wierzcholki.Count;
            for(int i=0;i<wierzcholki.Count;i++)
            {
                int x0 = (int)wierzcholki[i].x;
                int y0 = (int)wierzcholki[i].y;
                int x1 = (int)wierzcholki[(i+1)%n].x;
                int y1 = (int)wierzcholki[(i+1)%n].y;

                int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
                int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
                int err = (dx > dy ? dx : -dy) / 2, e2;
                for (; ; )
                {
                    if (x0 >= 0 && y0 >= 0 && x0 < bitmapa.Width && y0 < bitmapa.Height)
                        tabkraw[x0, y0] = new Krawendz(wierzcholki[i], wierzcholki[(i + 1) % n]);
                    if (x0 == x1 && y0 == y1) break;
                    e2 = err;
                    if (e2 > -dx) { err -= dy; x0 += sx; }
                    if (e2 < dy) { err += dx; y0 += sy; }
                }
            }
        }
        public void wyczyscTabKraw(Krawendz[,] tabkraw,DirectBitmap bitmapa)
        {
            int n= wierzcholki.Count;
            for(int i=0;i<n;i++)
            {
                int x0 = (int)wierzcholki[i].x;
                int y0 = (int)wierzcholki[i].y;
                int x1 = (int)wierzcholki[(i + 1) % n].x;
                int y1 = (int)wierzcholki[(i + 1) % n].y;

                int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
                int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
                int err = (dx > dy ? dx : -dy) / 2, e2;
                for (; ; )
                {
                    if (x0 >= 0 && y0 >= 0 && x0 < bitmapa.Width && y0 < bitmapa.Height)
                        tabkraw[x0, y0] = null;
                    if (x0 == x1 && y0 == y1) break;
                    e2 = err;
                    if (e2 > -dx) { err -= dy; x0 += sx; }
                    if (e2 < dy) { err += dx; y0 += sy; }
                }
            }
        }
        public static Wierzcholek zwrocWierzcholek(int a, int b, Wierzcholek[,] tab)
        {
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if (tab[a + i, b + j] != null) return tab[a + i, b + j];
                    if (tab[a - i, b + j] != null) return tab[a - i, b + j];
                    if (tab[a + i, b - j] != null) return tab[a + i, b - j];
                    if (tab[a - i, b - j] != null) return tab[a - i, b - j];

                }
            }
           
            return null;
        }
        public (Wierzcholek,Wierzcholek) zwrocWierzcholki(Wierzcholek w)
        {
            int n = wierzcholki.Count;
            int a = wierzcholki.IndexOf(w);
            Wierzcholek b = wierzcholki[(a - 1 + n) % n];
            Wierzcholek c = wierzcholki[(a + 1) % n];
            return (b, c);
        }
        public static Krawendz zwrocKrawendz(int a, int b, Krawendz[,] tab, ref int m, ref int n)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tab[a + i, b + j] != null)
                    {
                        m = a + i;
                        n = b + j;
                        return tab[a + i, b + j];
                    }
                    if (tab[a - i, b + j] != null)
                    {
                        m = a - i;
                        n = b + j;
                        return tab[a - i, b + j];
                    }
                    if (tab[a + i, b - j] != null)
                    {
                        m = a + i;
                        n = b - j;
                        return tab[a + i, b - j];
                    }
                    if (tab[a - i, b - j] != null)
                    {
                        m = a - i;
                        n = b - j;
                        return tab[a - i, b - j];
                    }

                }
            }

            return null;
           
        }
    }
}
