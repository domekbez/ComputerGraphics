using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    public static class Bresenham
    {
        public static void bresenhamLinia(DirectBitmap bitmapa,int x0, int y0, int x1, int y1,Color kolor)
        {
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            for (; ; )
            {
                if(x0>=0&&y0>=0&&x0<bitmapa.Width&&y0<bitmapa.Height)
                    bitmapa.SetPixel(x0, y0, kolor);
                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }
            }

        }
    }
}
