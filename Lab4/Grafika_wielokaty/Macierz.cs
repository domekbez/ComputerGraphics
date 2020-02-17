using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grafika_wielokaty
{
    class Macierz
    {
        int n;
        public float[,] tab { get; set; }
        public Macierz(float[,] tab)
        {
            this.tab = tab;
            n = tab.GetLength(0);
        }
        public Macierz mnozenieMacierzy(Macierz macierz2)
        {
            int n = tab.GetLength(0);
            float[,] wynik = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    wynik[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        wynik[i, j] += tab[i, k] * macierz2.tab[k, j];
                    }
                }
            }
            return new Macierz(wynik);
        }
        public Wektor macierzRazyWektor(Wektor wektor)
        {
            int n = 4;
            float[] wynik = new float[n];
            for (int i = 0; i < n; i++)
            {
                wynik[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    wynik[i] += tab[i, j] * wektor.wek[j];
                }
            }
            return new Wektor(wynik);
        }
        public static Macierz macierzT(float x, float y, float z)
        {
            int n = 4;
            float[,] wynik = new float[n, n];
            wynik[0, 0] = 1f;
            wynik[1, 1] = 1f;
            wynik[2, 2] = 1f;
            wynik[3, 3] = 1f;
            wynik[0, 3] = x;
            wynik[1, 3] = y;
            wynik[2, 3] = z;
            return new Macierz(wynik);


        }
        public static Macierz macierzSkalowania(float x, float y, float z)
        {
            int n = 4;
            float[,] wynik = new float[n, n];
            wynik[0, 0] = x;
            wynik[1, 1] = y;
            wynik[2, 2] = z;
            wynik[3, 3] = 1f;
            return new Macierz(wynik);
        }
        public static Macierz macierzObrotowX(double alfa)
        {
            int n = 4;
            float[,] wynik = new float[n, n];
            wynik[0, 0] = 1f;
            wynik[3, 3] = 1f;
            wynik[1, 1] = (float)Math.Cos(alfa);
            wynik[2, 2] = (float)Math.Cos(alfa);
            wynik[1, 2] = (float)(-1 * Math.Sin(alfa));
            wynik[2, 1] = (float)Math.Sin(alfa);


            return new Macierz(wynik);
        }
        public static Macierz macierzObrotowY(double alfa)
        {
            int n = 4;
            float[,] wynik = new float[n, n];
            wynik[1, 1] = 1f;
            wynik[3, 3] = 1f;
            wynik[0, 0] = (float)Math.Cos(alfa);
            wynik[2, 2] = (float)Math.Cos(alfa);
            wynik[0, 2] = (float)(-1 * Math.Sin(alfa));
            wynik[2, 0] = (float)Math.Sin(alfa);


            return new Macierz(wynik);
        }
        public static Macierz macierzObrotowZ(double alfa)
        {
            int n = 4;
            float[,] wynik = new float[n, n];
            wynik[2, 2] = 1f;
            wynik[3, 3] = 1f;
            wynik[0, 0] = (float)Math.Cos(alfa);
            wynik[1, 1] = (float)Math.Cos(alfa);
            wynik[0, 1] = (float)(-1 * Math.Sin(alfa));
            wynik[1, 0] = (float)Math.Sin(alfa);


            return new Macierz(wynik);
        }
        public Macierz odwrotnoscMacierzy(float[,] a)
        {
            var s0 = a[0, 0] * a[1, 1] - a[1, 0] * a[0, 1];
            var s1 = a[0, 0] * a[1, 2] - a[1, 0] * a[0, 2];
            var s2 = a[0, 0] * a[1, 3] - a[1, 0] * a[0, 3];
            var s3 = a[0, 1] * a[1, 2] - a[1, 1] * a[0, 2];
            var s4 = a[0, 1] * a[1, 3] - a[1, 1] * a[0, 3];
            var s5 = a[0, 2] * a[1, 3] - a[1, 2] * a[0, 3];

            var c5 = a[2, 2] * a[3, 3] - a[3, 2] * a[2, 3];
            var c4 = a[2, 1] * a[3, 3] - a[3, 1] * a[2, 3];
            var c3 = a[2, 1] * a[3, 2] - a[3, 1] * a[2, 2];
            var c2 = a[2, 0] * a[3, 3] - a[3, 0] * a[2, 3];
            var c1 = a[2, 0] * a[3, 2] - a[3, 0] * a[2, 2];
            var c0 = a[2, 0] * a[3, 1] - a[3, 0] * a[2, 1];

            // Should check for 0 determinant
            float pom = (s0 * c5 - s1 * c4 + s2 * c3 + s3 * c2 - s4 * c1 + s5 * c0);
            if (pom == 0)
                return null;
            float invdet = 1f / pom;

            float[,] b = new float[4, 4];

            b[0, 0] = (a[1, 1] * c5 - a[1, 2] * c4 + a[1, 3] * c3) * invdet;
            b[0, 1] = (-a[0, 1] * c5 + a[0, 2] * c4 - a[0, 3] * c3) * invdet;
            b[0, 2] = (a[3, 1] * s5 - a[3, 2] * s4 + a[3, 3] * s3) * invdet;
            b[0, 3] = (-a[2, 1] * s5 + a[2, 2] * s4 - a[2, 3] * s3) * invdet;

            b[1, 0] = (-a[1, 0] * c5 + a[1, 2] * c2 - a[1, 3] * c1) * invdet;
            b[1, 1] = (a[0, 0] * c5 - a[0, 2] * c2 + a[0, 3] * c1) * invdet;
            b[1, 2] = (-a[3, 0] * s5 + a[3, 2] * s2 - a[3, 3] * s1) * invdet;
            b[1, 3] = (a[2, 0] * s5 - a[2, 2] * s2 + a[2, 3] * s1) * invdet;

            b[2, 0] = (a[1, 0] * c4 - a[1, 1] * c2 + a[1, 3] * c0) * invdet;
            b[2, 1] = (-a[0, 0] * c4 + a[0, 1] * c2 - a[0, 3] * c0) * invdet;
            b[2, 2] = (a[3, 0] * s4 - a[3, 1] * s2 + a[3, 3] * s0) * invdet;
            b[2, 3] = (-a[2, 0] * s4 + a[2, 1] * s2 - a[2, 3] * s0) * invdet;

            b[3, 0] = (-a[1, 0] * c3 + a[1, 1] * c1 - a[1, 2] * c0) * invdet;
            b[3, 1] = (a[0, 0] * c3 - a[0, 1] * c1 + a[0, 2] * c0) * invdet;
            b[3, 2] = (-a[3, 0] * s3 + a[3, 1] * s1 - a[3, 2] * s0) * invdet;
            b[3, 3] = (a[2, 0] * s3 - a[2, 1] * s1 + a[2, 2] * s0) * invdet;

            return new Macierz(b);
        }


        public Macierz transpozycja(Macierz m)
        {
            int w = m.tab.GetLength(0);
            int h = m.tab.GetLength(1);

            float[,] wynik = new float[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    wynik[j, i] = m.tab[i, j];
                }
            }

            return new Macierz(wynik);
        }



    }
}