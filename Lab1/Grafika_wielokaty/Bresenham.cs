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
        public static void bresenhamLinia(Bitmap bitmapa,int x0, int y0, int x1, int y1,Color kolor)
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
        public static void bresenhamOkrag(Bitmap bitmapa,int w, int h,int centerX, int centerY, int radius, Color color)
        {
            int d = (5 - radius * 4) / 4;
            int x = 0;
            int y = radius;


            do
            {
                // ensure index is in range before setting (depends on your image implementation)
                // in this case we check if the pixel location is within the bounds of the image before setting the pixel
                if (centerX + x >= 0 && centerX + x <= w - 1 && centerY + y >= 0 && centerY + y <= h - 1) bitmapa.SetPixel(centerX + x, centerY + y, color);
                if (centerX + x >= 0 && centerX + x <= w - 1 && centerY - y >= 0 && centerY - y <= h - 1) bitmapa.SetPixel(centerX + x, centerY - y, color);
                if (centerX - x >= 0 && centerX - x <= w - 1 && centerY + y >= 0 && centerY + y <= h - 1) bitmapa.SetPixel(centerX - x, centerY + y, color);
                if (centerX - x >= 0 && centerX - x <= w - 1 && centerY - y >= 0 && centerY - y <= h - 1) bitmapa.SetPixel(centerX - x, centerY - y, color);
                if (centerX + y >= 0 && centerX + y <= w - 1 && centerY + x >= 0 && centerY + x <= h - 1) bitmapa.SetPixel(centerX + y, centerY + x, color);
                if (centerX + y >= 0 && centerX + y <= w - 1 && centerY - x >= 0 && centerY - x <= h - 1) bitmapa.SetPixel(centerX + y, centerY - x, color);
                if (centerX - y >= 0 && centerX - y <= w - 1 && centerY + x >= 0 && centerY + x <= h - 1) bitmapa.SetPixel(centerX - y, centerY + x, color);
                if (centerX - y >= 0 && centerX - y <= w - 1 && centerY - x >= 0 && centerY - x <= h - 1) bitmapa.SetPixel(centerX - y, centerY - x, color);
                if (d < 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    d += 2 * (x - y) + 1;
                    y--;
                }
                x++;
            } while (x <= y);
        }
    }
}
