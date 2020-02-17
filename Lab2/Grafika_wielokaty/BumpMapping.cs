using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class BumpMapping
    {
        public static (float, float, float) wektorNormalny(int x,int y, DirectBitmap mapa)
        {
            (float, float, float) wektorStyczny = (1, 0, 0);
            (float, float, float) wektorBinormalny = (0, 1, 0);
            float dx, dy;

            if (x > 1)
            {
                dx = mapa.GetPixel(x - 1, y).B - mapa.GetPixel(x, y).B;
            }
            else
                dx = mapa.GetPixel(x, y).B - mapa.GetPixel(x, y).B;
            if(y<mapa.Height-1)
                dy = mapa.GetPixel(x, y + 1).B - mapa.GetPixel(x, y).B;
            else
                dy = mapa.GetPixel(x, y).B - mapa.GetPixel(x, y).B;

            dx /= 255;
            dy /= 255;

            wektorStyczny.Item1 *= dx;
            wektorBinormalny.Item2 *= dy;
            (float, float, float) wektorZab = (wektorStyczny.Item1 + wektorBinormalny.Item1, wektorStyczny.Item2 + wektorBinormalny.Item2, wektorStyczny.Item3 + wektorBinormalny.Item3);
            return wektorZab;

        }
    }
}
