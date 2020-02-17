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
        public static Color LambertKolor(int x,int y,(int,int,int) swiatlo,Color kol, (double,double,double) kolorSwiatla,DirectBitmap mapa)

        {
            (int, int, int) wektorL = (swiatlo.Item1 - x, y-swiatlo.Item2, swiatlo.Item3);
            (float, float, float) wektorN = (0, 0, 1);
            if(mapa!=null)
            {
                var wektorZab = BumpMapping.wektorNormalny(x, y, mapa);
                wektorN.Item1 += wektorZab.Item1;
                wektorN.Item2 += wektorZab.Item2;
                wektorN.Item3 += wektorZab.Item3;
            }

            float dlugoscL = (float)Math.Sqrt((double)(wektorL.Item1 * wektorL.Item1 + wektorL.Item2 * wektorL.Item2 + wektorL.Item3 * wektorL.Item3));
            (float, float, float) wektorLNorm = ((wektorL.Item1 / dlugoscL), (wektorL.Item2 / dlugoscL), (wektorL.Item3 / dlugoscL));
            float dlugoscN = (float)Math.Sqrt((double)(wektorN.Item1 * wektorN.Item1 + wektorN.Item2 * wektorN.Item2 + wektorN.Item3 * wektorN.Item3));
            (float, float, float) wektorNNorm = ((wektorN.Item1 / dlugoscN), (wektorN.Item2 / dlugoscN), (wektorN.Item3 / dlugoscN));


            float cosinus = wektorLNorm.Item1*wektorNNorm.Item1+ wektorLNorm.Item2 * wektorNNorm.Item2+ wektorLNorm.Item3 * wektorNNorm.Item3;
            if(cosinus<0)
            {
                return Color.Black;
            }



            float kolR =(float)kolorSwiatla.Item1*((float)kol.R/255)* cosinus;
            float kolG =(float)kolorSwiatla.Item2 * ((float)kol.G/255) * cosinus;
            float kolB =(float)kolorSwiatla.Item3 * ((float)kol.B/255) * cosinus;
            if(kolR<-1.5||kolR>1.5|| kolG < -1.5 || kolG > 1.5|| kolB < -1.5 || kolB > 1.5)
            {
                int a = 7;

            }
            if(kolR<-40||kolB<-40||kolG<-40||Double.IsNaN(kolR) || Double.IsNaN(kolG) || Double.IsNaN(kolB))
            {
                kolR = 0.5f;
                kolG = 0.5f;
                kolB = 0.5f;
            }
            return Color.FromArgb((int)(kolR*255), (int)(kolG*255), (int)(kolB*255));
        }
    }
}
