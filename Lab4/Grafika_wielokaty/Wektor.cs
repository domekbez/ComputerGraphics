using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Wektor
    {
        int n;
        public float[] wek;
        public Wektor(float[] wek)
        {
            this.wek = wek;
            n = wek.Length;
        }
        public Wektor(float a, float b, float c)
        {
            wek = new float[3];
            wek[0] = a;
            wek[1] = b;
            wek[2] = c;
            n = 3;
        }
        public Wektor(float a, float b, float c,float d)
        {
            wek = new float[4];
            wek[0] = a;
            wek[1] = b;
            wek[2] = c;
            wek[3] = d;
            n = 4;
        }
        public Wektor normalizacja()
        {
            int dl = n;
            double suma = 0;
            foreach (var el in wek)
            {
                suma += el * el;
            }
            float dlugoscWek = (float)Math.Sqrt(suma);
            float[] wynik = new float[n];
            int i = 0;
            foreach (var el in wek)
            {
                wynik[i++] = el / dlugoscWek;
            }
            return new Wektor(wynik);
        }
        public static Wektor iloczynWektorowy(Wektor v1, Wektor v2)
        {
            float[] wynik = new float[3];
            wynik[0] = v1.wek[1] * v2.wek[2] - v2.wek[1] * v1.wek[2];
            wynik[1] = (v1.wek[0] * v2.wek[2] - v2.wek[0] * v1.wek[2]) * -1;
            wynik[2] = v1.wek[0] * v2.wek[1] - v2.wek[0] * v1.wek[1];
            return new Wektor(wynik);
        }
        public static float iloczynSkalarny(Wektor w1, Wektor w2)
        {
            float suma = 0f;
            for(int i=0;i<w1.wek.Length;i++)
            {
                suma += w1.wek[i] * w2.wek[i];
            }
            return suma;
        }
        public Wektor wektorRazyMacierz(Macierz M)
        {
            int n = 4;
            float[] wynik = new float[n];
            for (int i = 0; i < n; i++)
            {
                wynik[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    wynik[i] += M.tab[j, i] * wek[j];
                }
            }
            return new Wektor(wynik);
        }
    }
}
