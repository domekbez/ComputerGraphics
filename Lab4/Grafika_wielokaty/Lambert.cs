using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Lambert
    {
        public static Color LambertKolor(int x, int y,Wektor wektorN,Wektor swiatlo, Color kol, Wektor kolorSwiatla)

        {
            Wektor wektorL = new Wektor(swiatlo.wek[0] - x, y - swiatlo.wek[1], swiatlo.wek[2]);
            //Wektor wektorN = new Wektor(0, 0, 1);

            wektorL = wektorL.normalizacja();
            Wektor wektorN2 = new Wektor(wektorN.wek[0], wektorN.wek[1], wektorN.wek[2]);
            wektorN2 = wektorN2.normalizacja();


            float cosinus = wektorL.wek[0] * wektorN2.wek[0] + wektorL.wek[1] * wektorN2.wek[1] + wektorL.wek[2] * wektorN2.wek[2];
            if (cosinus < 0)
            {
                return Color.Black;
            }



            float kolR = kolorSwiatla.wek[0] * ((float)kol.R / 255) * cosinus;
            float kolG = kolorSwiatla.wek[1] * ((float)kol.G / 255) * cosinus;
            float kolB = kolorSwiatla.wek[2] * ((float)kol.B / 255) * cosinus;
            if (kolR < -1.5 || kolR > 1 || kolG < -1.5 || kolG > 1 || kolB < -1.5 || kolB > 1)
            {
                kolR = 0.5f;
                kolG = 0.5f;
                kolB = 0.5f;

            }
            if (kolR < -0 || kolB < -0 || kolG < -0 || Double.IsNaN(kolR) || Double.IsNaN(kolG) || Double.IsNaN(kolB))
            {
                kolR = 0.5f;
                kolG = 0.5f;
                kolB = 0.5f;
            }
            return Color.FromArgb((int)(kolR * 255), (int)(kolG * 255), (int)(kolB * 255));
        }
    }
}
