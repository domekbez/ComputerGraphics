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
        public float zmin;
        public float zmax;
        public double umin,umax, vmin,vmax;
        public float xcur;
        public int ymin;
        public float nachylenie;
        public Wektor wektorN;
        public ET nast;

        public ET(Wektor wektorN,double umin,double umax,double vmin,double vmax,Color kol1, Color kol2, int ymax, float xcur, int ymin, float nachylenie, ET nast,int xmax,int xmin,float zmax, float zmin)
        {
            this.wektorN = wektorN;
            this.umin = umin;
            this.umax = umax;
            this.vmin = vmin;
            this.vmax = vmax;
            this.kol1 = kol1;
            this.kol2 = kol2;
            this.zmax = zmax;
            this.zmin = zmin;
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
                    min = (int)el.y;
                if (el.y > max)
                    max = (int)el.y;
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

                    int kubelek = Math.Abs((int)w.wierzcholki[i].y - para.Item2);
                    if (tablica[kubelek] == null)
                    {
                        //CO TO m????
                        tablica[kubelek] = new ET(w.wierzcholki[i].wekNormalny,w.wierzcholki[i].u,w.wierzcholki[(i+1)%n].u,w.wierzcholki[i].v, w.wierzcholki[(i + 1) % n].v, w.wierzcholki[(i + 1) % n].kolor, w.wierzcholki[i].kolor,(int)w.wierzcholki[(i + 1) % n].y, w.wierzcholki[i].x, (int)w.wierzcholki[i].y, m, null, (int)w.wierzcholki[(i + 1) % n].x, (int)w.wierzcholki[i].x,w.wierzcholki[(i+1)%n].z,w.wierzcholki[i].z);

                    }
                    else
                    {
                        ET pom = tablica[kubelek];
                        while (pom.nast != null)
                        {
                            pom = pom.nast;
                        }
                        ET nowy = new ET(w.wierzcholki[i].wekNormalny, w.wierzcholki[i].u, w.wierzcholki[(i + 1) % n].u, w.wierzcholki[i].v, w.wierzcholki[(i + 1) % n].v, w.wierzcholki[(i + 1) % n].kolor, w.wierzcholki[i].kolor,(int)w.wierzcholki[(i + 1) % n].y, w.wierzcholki[i].x, (int)w.wierzcholki[i].y, m, null, (int)w.wierzcholki[(i + 1) % n].x, (int)w.wierzcholki[i].x, w.wierzcholki[(i + 1) % n].z, w.wierzcholki[i].z);
                        pom.nast = nowy;
                    }
                }
                else
                {
                    float m = (float)(w.wierzcholki[i].y - w.wierzcholki[(i + 1) % n].y) / (w.wierzcholki[i].x - w.wierzcholki[(i + 1) % n].x);

                    int kubelek = Math.Abs((int)w.wierzcholki[(i + 1) % n].y - para.Item2);

                    if (tablica[kubelek] == null)
                    {
                        tablica[kubelek] = new ET(w.wierzcholki[i].wekNormalny, w.wierzcholki[(i+1)%n].u,w.wierzcholki[i].u, w.wierzcholki[(i + 1) % n].v, w.wierzcholki[i].v, w.wierzcholki[i].kolor, w.wierzcholki[(i+1)%n].kolor,(int)w.wierzcholki[i].y, w.wierzcholki[(i + 1) % n].x, (int)w.wierzcholki[(i + 1) % n].y, m, null, (int)w.wierzcholki[i].x, (int)w.wierzcholki[(i + 1) % n].x,w.wierzcholki[i].z,w.wierzcholki[(i+1)%n].z);

                    }
                    else
                    {
                        ET pom = tablica[kubelek];
                        while (pom.nast != null)
                        {
                            pom = pom.nast;
                        }
                        ET nowy = new ET(w.wierzcholki[i].wekNormalny, w.wierzcholki[(i + 1) % n].u, w.wierzcholki[i].u, w.wierzcholki[(i + 1) % n].v, w.wierzcholki[i].v, w.wierzcholki[i].kolor, w.wierzcholki[(i + 1) % n].kolor,(int)w.wierzcholki[i].y, w.wierzcholki[(i + 1) % n].x, (int)w.wierzcholki[(i + 1) % n].y, m, null,(int)w.wierzcholki[i].x, (int)w.wierzcholki[(i + 1) % n].x, w.wierzcholki[i].z, w.wierzcholki[(i + 1) % n].z);
                        pom.nast = nowy;
                    }
                }
            }
            return tablica;
        }
        public static void wypelnijPikselami(int y, ET x1, ET x2, DirectBitmap bitmapa,Color kol,bool zbuffer)
        {
            int p1 = (int)x1.xcur;
            int p2 = (int)x2.xcur;


            double dlKrawA = DodatkoweAlg.odlegloscWierzch(x1.xmin, x1.ymin, x1.xmax, x1.ymax);
            double dlKrawB = DodatkoweAlg.odlegloscWierzch(x2.xmin, x2.ymin, x2.xmax, x2.ymax);
            double dlOdcA = DodatkoweAlg.odlegloscWierzch(p1, y, x1.xmax, x1.ymax);
            double dlOdcB = DodatkoweAlg.odlegloscWierzch(p2, y, x2.xmax, x2.ymax);
            double tA = dlOdcA / dlKrawA;
            double tB = dlOdcB / dlKrawB;

            double zE = tA * x1.zmin + ((1 - tA) * x1.zmax);
            double zF = tB * x2.zmin + ((1 - tB) * x2.zmax);
            


            int dlugosc = p2 - p1;
            if (dlugosc == 0) return;

            for (int i = p2; i >= p1; i--)
            {
                if (i >= 0 && y >= 0 && y < bitmapa.Height && i < bitmapa.Width)
                {
                    float t = (p2 - i) / (float)dlugosc;
                    if (zbuffer)
                    {
                        double z = t * zE + ((1 - t) * zF);

                        if (z < -1 || z > 1) continue;
                        if (z >= bitmapa.zGleb[i, y]) continue;

                        bitmapa.zGleb[i, y] = (float)z;
                    }
                    bitmapa.SetPixel(i, y, kol);
                }

            }
            
        }
        public static void wypelnijInterpolacja(Wektor pozycjaKamery,Material material,Wektor swiatlo,Wektor kolorSwiatla,int y, ET x1, ET x2, DirectBitmap bitmapa,bool zbuffer,DirectBitmap tekstura)
        {
           // Console.WriteLine("WEKTOR NORMALNY" + x1.wektorN.wek[0]+ ", " + x1.wektorN.wek[1] + ", " +x1.wektorN.wek[2]);

            int p1 = (int)x1.xcur;
            int p2 = (int)x2.xcur;
            double dlKrawA = DodatkoweAlg.odlegloscWierzch(x1.xmin, x1.ymin, x1.xmax, x1.ymax);
            double dlKrawB = DodatkoweAlg.odlegloscWierzch(x2.xmin, x2.ymin, x2.xmax, x2.ymax);
            double dlOdcA = DodatkoweAlg.odlegloscWierzch(p1, y, x1.xmax, x1.ymax);
            double dlOdcB = DodatkoweAlg.odlegloscWierzch(p2, y, x2.xmax, x2.ymax);
            double tA = dlOdcA / dlKrawA;
            double tB = dlOdcB / dlKrawB;

            double zE = tA * x1.zmin + ((1 - tA) * x1.zmax);
            double zF = tB * x2.zmin + ((1 - tB) * x2.zmax);
          
            double uE = tA * x1.umin + ((1 - tA) * x1.umax);
            double uF = tB * x2.umin + ((1 - tB) * x2.umax);
            double vE = tA * x1.vmin + ((1 - tA) * x1.vmax);
            double vF = tB * x2.vmin + ((1 - tB) * x2.vmax);
           
            int dlugosc = p2 - p1;
            if (dlugosc == 0) return;

            for (int i = p2; i >= p1; i--)
            {
                if (i >= 0 && y >= 0 && y < bitmapa.Height && i < bitmapa.Width)
                {
                    float t = (p2 - i) / (float)dlugosc;
                    if (zbuffer)
                    {
                        double z = t * zE + ((1 - t) * zF);
                        if (z < -1 || z > 1) continue;
                        if (z >= bitmapa.zGleb[i, y]) continue;
                        bitmapa.zGleb[i, y] = (float)z;
                    }
                    double u = t * uE + ((1 - t) * uF);
                    double v = t * vE + ((1 - t) * vF);
                    u *= tekstura.Width;
                    v *= tekstura.Height;
                   
                    if (u < 0 || u >= tekstura.Width || v < 0 || v >= tekstura.Height) continue;

                    Wektor Li = new Wektor(swiatlo.wek[0] - i, swiatlo.wek[1]-y, swiatlo.wek[2]*50);
                    Li = Li.normalizacja();
                    Wektor V = new Wektor(pozycjaKamery.wek[0] - i, pozycjaKamery.wek[1] - y, pozycjaKamery.wek[2]);
                    V = V.normalizacja();
                    double dist = Math.Sqrt((swiatlo.wek[0] - i) * (swiatlo.wek[0] - i) + (swiatlo.wek[1] - y) * (swiatlo.wek[1] - y) + (swiatlo.wek[2]) * (swiatlo.wek[2]));
                    double pom = 1 + 0.09 * dist + 0.032 * dist * dist;
                    float If = (float)(1 / pom);

                    Color kol = tekstura.GetPixel((int)u, (int)v);
                    

                    Color wyn = material.Phong(kol, Color.White, Color.White, Li, x1.wektorN, V, If);




                    //Color kol = tekstura.GetPixel((int)u, (int)v);
                    
                    //Color kol2 =Lambert.LambertKolor(i, y,x1.wektorN, swiatlo, kol, kolorSwiatla);
                    bitmapa.SetPixel(i, y,wyn);
                }

            }
        }
        public static void wypelnijWielokat(Wektor pozycjaKamery,Material material,Wektor swiatlo,Wektor kolorSwiatla,Wielokant w, DirectBitmap bitmapa,bool interpolacja,Color kolor,bool zbuffer,DirectBitmap tekstura)
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
                            wypelnijPikselami(para.Item2 - i, AETlista[j], AETlista[j + 1], bitmapa,kolor,zbuffer);
                        else
                        {
                            wypelnijInterpolacja(pozycjaKamery,material,swiatlo,kolorSwiatla,para.Item2 - i, AETlista[j], AETlista[j + 1], bitmapa,zbuffer,tekstura);
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
