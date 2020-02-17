using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Wielokant
    {
        public Color kolor;   
        public List<Wierzcholek> wierzcholki;
        public List<Krawendz> rownoleglekraw;
        public List<Krawendz> prostopadlekraw;
        

        public Wielokant()
        {
            wierzcholki = new List<Wierzcholek>();
            rownoleglekraw = new List<Krawendz>();
            prostopadlekraw = new List<Krawendz>();
        }
        public void Rysuj(Bitmap bitmapa)
        {
            int n = wierzcholki.Count;
            
            if (n == 1)
            {
                bitmapa.SetPixel(wierzcholki[0].x, wierzcholki[0].y, kolor);
                return;
            }
           
            for (int i=0;i<n;i++)
            {
                if(wierzcholki[i].n!=null)
                    Bresenham.bresenhamLinia(bitmapa, wierzcholki[i].x, wierzcholki[i].y, wierzcholki[(i + 1) %n ].x, wierzcholki[(i + 1) % n].y,wierzcholki[i].n.kolor);
                else
                    Bresenham.bresenhamLinia(bitmapa, wierzcholki[i].x, wierzcholki[i].y, wierzcholki[(i + 1) % n].x, wierzcholki[(i + 1) % n].y, kolor);

            }
            foreach (var el in rownoleglekraw)
            {
                Bresenham.bresenhamLinia(bitmapa, el.a.x, el.a.y , el.b.x, el.b.y,el.kolor);

            }
            foreach (var el in prostopadlekraw)
            {
                Bresenham.bresenhamLinia(bitmapa, el.a.x, el.a.y, el.b.x, el.b.y, el.kolor);

            }
        }

        public void tablicaWierzcholkow(Wierzcholek[,] tabwierzch,Bitmap bitmapa)
        {
            foreach (var el in wierzcholki)
            {
                if (el.x >= 0 && el.y >= 0 && el.x < bitmapa.Width && el.y < bitmapa.Height)
                    tabwierzch[el.x, el.y] = el;
            }
        }
        public void wyczyscTabWierzch(Wierzcholek[,] tabwierzch,Bitmap bitmapa)
        {
            foreach (var el in wierzcholki)
            {
                if(el.x>=0&&el.y>=0&&el.x<bitmapa.Width&&el.y<bitmapa.Height)
                tabwierzch[el.x, el.y] = null;
            }
        }
        public void tablicaKrawedzi(Krawendz[,] tabkraw, Bitmap bitmapa)
        {
            int n = wierzcholki.Count;
            for(int i=0;i<wierzcholki.Count;i++)
            {
                int x0 = wierzcholki[i].x;
                int y0 = wierzcholki[i].y;
                int x1 = wierzcholki[(i+1)%n].x;
                int y1 = wierzcholki[(i+1)%n].y;

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
        public void wyczyscTabKraw(Krawendz[,] tabkraw,Bitmap bitmapa)
        {
            int n= wierzcholki.Count;
            for(int i=0;i<n;i++)
            {
                int x0 = wierzcholki[i].x;
                int y0 = wierzcholki[i].y;
                int x1 = wierzcholki[(i + 1) % n].x;
                int y1 = wierzcholki[(i + 1) % n].y;

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
        public static bool rownoleglosc(int ww, int hh, Krawendz e1, Krawendz e2)
        {
            if (e1.a.wielok.wierzcholki.Count < 4) return false;

            Wierzcholek w = e1.a;
            Wierzcholek w1 = e1.b;
            Wierzcholek w2 = e2.a;
            Wierzcholek w3 = e2.b;
            Wierzcholek p1;
            (Wierzcholek, Wierzcholek) pom;

            pom = e1.a.wielok.zwrocWierzcholki(w3);
            if (pom.Item1 == w2)
                p1 = pom.Item2;
            else
                p1 = pom.Item1;


            double aa = 0;
            if (w3.x == p1.x) aa = 0;
            else
            {
                aa = (double)(w3.y - p1.y) / (w3.x - p1.x);
            }
            double bb = w3.y - aa * w3.x;
            double aaa = 0;
            if (w.x == w1.x) aaa = 0;
            else
            {
                aaa = (double)(w1.y - w.y) / (w1.x - w.x);
            }
            double bbb = w2.y - aaa * w2.x;
            if (aaa == aa) return true;
            double xx = (double)(bb - bbb) / (aaa - aa);
            double yy = xx * aa + bb;
            w3.x = (int)xx;
            w3.y = (int)yy;
            return true;
        }
        public static bool prostopadlosc(int ww, int hh, Krawendz e1, Krawendz e2)
        {
           

            Wierzcholek w = e1.a;
            Wierzcholek w1 = e1.b;
            Wierzcholek w2 = e2.a;
            Wierzcholek w3 = e2.b;
            Wierzcholek p1;
            (Wierzcholek, Wierzcholek) pom;

            pom = e1.a.wielok.zwrocWierzcholki(w3);
            if (pom.Item1 == w2)
                p1 = pom.Item2;
            else
                p1 = pom.Item1;

            double aa = 0;
            if (w3.x == p1.x) aa = 0;
            else
            {
                aa = (double)(w3.y - p1.y) / (w3.x - p1.x);
            }
            double bb = w3.y - aa * w3.x;
            double aaa = 0;
            if (w.x == w1.x) aaa = 0;
            else
            {
                double pom2 = (double)(w1.y - w.y) / (w1.x - w.x);
                if(pom2<0.00001&&pom2>-0.00001)
                {
                    double x2 = w2.x;
                    double y2 = x2 * aa + bb;
                    w3.x = (int)x2;
                    w3.y = (int)y2;
                    return true;
                }
                aaa = (double)(-1)/pom2;
            }
            double bbb = w2.y - aaa * w2.x;
            if (aaa == aa) return true;
            double xx = (double)(bb - bbb) / (aaa - aa);
            double yy = xx * aa + bb;
            w3.x = (int)xx;
            w3.y = (int)yy;
            return true;
        }
    }
}
