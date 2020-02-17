using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class ET
    {
        public Color kol1 = Color.Black;
        public Color kol2 = Color.Black;

        public int ymax;
        public int xmax;
        public int xmin;

        public float xcur;
        public int ymin;
        public float nachylenie;
        public ET nast;

        public ET(Color kol1, Color kol2, int ymax, float xcur, int ymin, float nachylenie, ET nast,int xmax,int xmin)
        {
            this.kol1 = kol1;
            this.kol2 = kol2;

            this.ymax = ymax;
            this.xcur = xcur;
            this.ymin = ymin;
            this.nachylenie = nachylenie;
            this.nast = nast;
            this.xmax = xmax;
            this.xmin = xmin;
        }
    }
    class ScanLinia
    {
        public static (int, int) zwrocMinMax(Wielokant w)
        {
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            foreach (var el in w.wierzcholki)
            {
                if (el.y < min)
                    min = el.y;
                if (el.y > max)
                    max = el.y;
            }
            return (min, max);
        }
        public static ET[] sortowanieKubelkowe(Wielokant w)
        {
            var para = zwrocMinMax(w);
            int n = w.wierzcholki.Count;
            int ile = para.Item2 - para.Item1 + 1;
            if (ile > 10000)
                return null;
            ET[] tablica = new ET[ile];
            for (int i = 0; i < n; i++)
            {

                if (w.wierzcholki[i].y > w.wierzcholki[(i + 1) % n].y)
                {
                    float m = (float)(w.wierzcholki[(i + 1) % n].y - w.wierzcholki[i].y) / (w.wierzcholki[(i + 1) % n].x - w.wierzcholki[i].x);

                    int kubelek = Math.Abs(w.wierzcholki[i].y - para.Item2);
                    if (tablica[kubelek] == null)
                    {
                        //CO TO m????
                        tablica[kubelek] = new ET(w.wierzcholki[(i + 1) % n].kolor, w.wierzcholki[i].kolor,w.wierzcholki[(i + 1) % n].y, w.wierzcholki[i].x, w.wierzcholki[i].y, m, null, w.wierzcholki[(i + 1) % n].x, w.wierzcholki[i].x);

                    }
                    else
                    {
                        ET pom = tablica[kubelek];
                        while (pom.nast != null)
                        {
                            pom = pom.nast;
                        }
                        ET nowy = new ET(w.wierzcholki[(i + 1) % n].kolor, w.wierzcholki[i].kolor,w.wierzcholki[(i + 1) % n].y, w.wierzcholki[i].x, w.wierzcholki[i].y, m, null, w.wierzcholki[(i + 1) % n].x, w.wierzcholki[i].x);
                        pom.nast = nowy;
                    }
                }
                else
                {
                    float m = (float)(w.wierzcholki[i].y - w.wierzcholki[(i + 1) % n].y) / (w.wierzcholki[i].x - w.wierzcholki[(i + 1) % n].x);

                    int kubelek = Math.Abs(w.wierzcholki[(i + 1) % n].y - para.Item2);

                    if (tablica[kubelek] == null)
                    {
                        tablica[kubelek] = new ET(w.wierzcholki[i].kolor, w.wierzcholki[(i+1)%n].kolor,w.wierzcholki[i].y, w.wierzcholki[(i + 1) % n].x, w.wierzcholki[(i + 1) % n].y, m, null, w.wierzcholki[i].x, w.wierzcholki[(i + 1) % n].x);

                    }
                    else
                    {
                        ET pom = tablica[kubelek];
                        while (pom.nast != null)
                        {
                            pom = pom.nast;
                        }
                        ET nowy = new ET(w.wierzcholki[i].kolor, w.wierzcholki[(i + 1) % n].kolor,w.wierzcholki[i].y, w.wierzcholki[(i + 1) % n].x, w.wierzcholki[(i + 1) % n].y, m, null,w.wierzcholki[i].x, w.wierzcholki[(i + 1) % n].x);
                        pom.nast = nowy;
                    }
                }
            }
            return tablica;
        }
        public static void wypelnijPikselami(int y, float x1, float x2, DirectBitmap bitmapa,DirectBitmap tekstura,(double,double,double) swiatlo,(int,int,int) wektorSwiatla,DirectBitmap mapa)
        {
            int p1 = (int)x1;
            int p2 = (int)x2;

            for (int i = p2; i >= p1; i--)
            {
                if (i >= 0 && y >= 0 && y < bitmapa.Height && i < bitmapa.Width)
                {
                    // bitmapa.SetPixel(i, y, Color.Black);

                    if (tekstura != null)
                    {
                        Color kol = Lambert.LambertKolor(i, y, wektorSwiatla, tekstura.GetPixel(i, y), swiatlo, mapa);
                        //Color kol = tekstura.GetPixel(i, y);
                        bitmapa.SetPixel(i, y, kol);
                    }
                    else
                    {
                        Color kol = Lambert.LambertKolor(i, y, wektorSwiatla, Form1.kolorWypelniania, swiatlo, mapa);
                        //Color kol = tekstura.GetPixel(i, y);
                        bitmapa.SetPixel(i, y, kol);
                    }

                }

            }
        }
        public static void wypelnijInterpolacja(int y, ET x1, ET x2, DirectBitmap bitmapa, DirectBitmap tekstura, (double,double,double) swiatlo, (int, int, int) wektorSwiatla, DirectBitmap mapa)
        {
            int p1 = (int)x1.xcur;
            int p2 = (int)x2.xcur;
            Color kol1, kol2, kol3, kol4;
            kol1 = x1.kol1;
            kol2 = x1.kol2;
            kol3 = x2.kol1;
            kol4 = x2.kol2;


            double dlKrawA = DodatkoweAlg.odlegloscWierzch(x1.xmin, x1.ymin, x1.xmax, x1.ymax);
            double dlKrawB = DodatkoweAlg.odlegloscWierzch(x2.xmin, x2.ymin, x2.xmax, x2.ymax);
            double dlOdcA = DodatkoweAlg.odlegloscWierzch(p1, y, x1.xmax, x1.ymax);
            double dlOdcB = DodatkoweAlg.odlegloscWierzch(p2, y, x2.xmax, x2.ymax);
            double tA = dlOdcA / dlKrawA;
            double tB = dlOdcB / dlKrawB;

            Color kolE = Color.FromArgb((int)(tA * kol2.R + ((1 - tA) * kol1.R)), (int)(tA * kol2.G + ((1 - tA) * kol1.G)), (int)(tA * kol2.B + ((1 - tA) * kol1.B)));
            Color kolF = Color.FromArgb((int)(tB * kol4.R + ((1 - tB) * kol3.R)), (int)(tB * kol4.G + ((1 - tB) * kol3.G)), (int)(tB * kol4.B + ((1 - tB) * kol3.B)));



            int dlugosc = p2 - p1;
            if (dlugosc == 0) return;

            for (int i = p2; i >= p1; i--)
            {
                if (i >= 0 && y >= 0 && y < bitmapa.Height && i < bitmapa.Width)
                {
                    float t = (p2 - i) / (float)dlugosc;
                    Color kol = Color.FromArgb((int)(t * kolE.R + (1 - t) * kolF.R), (int)(t * kolE.G + (1 - t) * kolF.G), (int)(t * kolE.B + (1 - t) * kolF.B));
                    bitmapa.SetPixel(i, y, kol);
                }

            }
        }
        public static void wypelnijWielokat(Wielokant w, DirectBitmap bitmapa, DirectBitmap tekstura,(double,double,double) swiatlo,(int,int,int)wektorSwiatla,bool interpolacja, DirectBitmap mapa)
        {
            ET[] tabET = sortowanieKubelkowe(w);
            if (tabET == null)
                return;
            List<ET> AETlista = new List<ET>();
            var para = zwrocMinMax(w);
            int ilekubelkow = para.Item2 - para.Item1 + 1;

            for (int i = 0; i < ilekubelkow; i++) //dla kazdej scanlini
            {
                for (int j = 0; j < AETlista.Count; j++)
                {
                    float pomm = -1 * (1 / AETlista[j].nachylenie);

                    if (pomm > 500)
                        AETlista[j].xcur += 500;
                    else if (pomm < -500)
                        AETlista[j].xcur += -500;
                    else
                        AETlista[j].xcur += pomm;

                }
                ET kraw = tabET[i];
                AETlista.Sort((e1, e2) => (int)(e1.xcur - e2.xcur)); //sortowanie AET
                for (int j = 0; j < AETlista.Count; j += 2)
                {
                    if (j + 1 < AETlista.Count)
                    {
                        if(!interpolacja)
                            wypelnijPikselami(para.Item2 - i, AETlista[j].xcur, AETlista[j + 1].xcur, bitmapa, tekstura, swiatlo, wektorSwiatla,mapa);
                        else
                        {
                            wypelnijInterpolacja(para.Item2 - i, AETlista[j], AETlista[j + 1], bitmapa, tekstura, swiatlo, wektorSwiatla,mapa);

                        }

                    }
                }
                while (kraw != null) //ET do AET
                {
                    AETlista.Add(kraw);
                    kraw = kraw.nast;
                }
                List<ET> dousun = new List<ET>();
                dousun.Clear();

                for (int j = 0; j < AETlista.Count; j++)
                {
                    if (para.Item2 - i == AETlista[j].ymax)
                        dousun.Add(AETlista[j]);
                }
                foreach (var el in dousun)
                {
                    AETlista.Remove(el);
                }

            }

        }
    }
}
