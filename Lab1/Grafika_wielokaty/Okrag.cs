using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grafika_wielokaty
{
    class Okrag
    {
        public Color kolor;
        public int promien;
        public int x, y;
        public Okrag(Color kolor)
        {
            this.kolor = kolor;
        }
        public Okrag(int r,int x, int y)
        {
            promien = r;
            this.x = x;
            this.y = y;
        }
        public void Rysuj(Bitmap bitmapa,int w, int h)
        {
            Bresenham.bresenhamOkrag(bitmapa,w,h, x, y, promien, kolor);

        }
        public void tablicaOkregow(int w, int h,Okrag[,] tabokr)
        {
            int d = (5 - promien * 4) / 4;
            int a = 0;
            int b = promien;
            do
            {
                if (x + a >= 0 && x + a <= w - 1 && y + b >= 0 && y + b <= h - 1) tabokr[x + a, y + b] = this;
                if (x + a >= 0 && x + a <= w - 1 && y - b >= 0 && y - b <= h - 1) tabokr[x + a, y - b] = this;
                if (x - a >= 0 && x - a <= w - 1 && y + b >= 0 && y + b <= h - 1) tabokr[x - a, y + b] = this;
                if (x - a >= 0 && x - a <= w - 1 && y - b >= 0 && y - b <= h - 1) tabokr[x - a, y - b] = this;
                if (x + b >= 0 && x + b <= w - 1 && y + a >= 0 && y + a <= h - 1) tabokr[x + b, y + a] = this;
                if (x + b >= 0 && x + b <= w - 1 && y - a >= 0 && y - a <= h - 1) tabokr[x + b, y - a] = this;
                if (x - b >= 0 && x - b <= w - 1 && y + a >= 0 && y + a <= h - 1) tabokr[x - b, y + a] = this;
                if (x - b >= 0 && x - b <= w - 1 && y - a >= 0 && y - a <= h - 1) tabokr[x - b, y - a] = this;

                if (d < 0)
                {
                    d += 2 * a + 1;
                }
                else
                {
                    d += 2 * (a - b) + 1;
                    b--;
                }
                a++;
            } while (a <= b);
        }
        public void wyczyscTab(int w, int h, Okrag[,] tabokr)
        {
            int d = (5 - promien * 4) / 4;
            int a = 0;
            int b = promien;
            do
            {
                if (x + a >= 0 && x + a <= w - 1 && y + b >= 0 && y + b <= h - 1) tabokr[x + a, y + b] = null;
                if (x + a >= 0 && x + a <= w - 1 && y - b >= 0 && y - b <= h - 1) tabokr[x + a, y - b] = null;
                if (x - a >= 0 && x - a <= w - 1 && y + b >= 0 && y + b <= h - 1) tabokr[x - a, y + b] = null;
                if (x - a >= 0 && x - a <= w - 1 && y - b >= 0 && y - b <= h - 1) tabokr[x - a, y - b] = null;
                if (x + b >= 0 && x + b <= w - 1 && y + a >= 0 && y + a <= h - 1) tabokr[x + b, y + a] = null;
                if (x + b >= 0 && x + b <= w - 1 && y - a >= 0 && y - a <= h - 1) tabokr[x + b, y - a] = null;
                if (x - b >= 0 && x - b <= w - 1 && y + a >= 0 && y + a <= h - 1) tabokr[x - b, y + a] = null;
                if (x - b >= 0 && x - b <= w - 1 && y - a >= 0 && y - a <= h - 1) tabokr[x - b, y - a] = null;
                if (d < 0)
                {
                    d += 2 * a + 1;
                }
                else
                {
                    d += 2 * (a - b) + 1;
                    b--;
                }
                a++;
            } while (a <= b);
        }
        public static Okrag zwrocOkrag(int a, int b, Okrag[,] tabokr)
        {
            if (tabokr[a, b] != null) return tabokr[a, b];
            if (tabokr[a+1, b] != null) return tabokr[a+1, b];
            if (tabokr[a+1, b+1] != null) return tabokr[a+1, b+1];
            if (tabokr[a+1, b-1] != null) return tabokr[a+1, b-1];
            if (tabokr[a, b+1] != null) return tabokr[a, b+1];
            if (tabokr[a, b-1] != null) return tabokr[a, b-1];
            if (tabokr[a-1, b-1] != null) return tabokr[a-1, b-1];
            if (tabokr[a-1, b] != null) return tabokr[a-1, b];
            if (tabokr[a - 1, b + 1] != null) return tabokr[a-1, b+1];
            else return null;
        }
    }
}
