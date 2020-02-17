using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Wierzcholek
    {
        public float x, y, z;
        public Wektor wekNormalny;
        public Wektor wekNormalny2;

        public Wektor wekStyczny;
        public Wektor wekBinormalny;

        public Wektor pozycjaPrzekszt;
        public Wektor pozycjaEkran;

        public float u, v;

        public Wielokant wielok;
        public Krawendz p = null;
        public Krawendz n = null;
        public Color kolor = Color.Violet;

       
        public Wierzcholek(float x, float y, float z)
        {
            float[] pom = new float[2] { 0, 0 };
            float[] pom2 = new float[4] { 0, 0, 0, 0 };


            pozycjaPrzekszt = new Wektor(pom2);
            pozycjaEkran = new Wektor(pom);
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Wierzcholek(int x, int y,Wielokant wiel,Color kol)
        {
            this.x = x;
            this.y = y;
            wielok = wiel;
            kolor = kol;
        }
        public Wierzcholek(int x, int y, Wielokant wiel)
        {
            this.x = x;
            this.y = y;
            wielok = wiel;
          
        }
        public Wierzcholek(float x, float y, float z, Wektor wekNormalny, float u, float v)
        {
            float[] pom = new float[2] { 0, 0 };
            float[] pom2 = new float[4] { 0, 0, 0, 0 };


            pozycjaPrzekszt = new Wektor(pom2);
            pozycjaEkran = new Wektor(pom);
            
            this.x = x;
            this.y = y;
            this.z = z;
            this.u = u;
            this.v = v;
            this.wekNormalny = wekNormalny;
        }
        public void Rysuj(DirectBitmap bitmapa)
        {
            if (x >= 0 && y >= 0 && x <= bitmapa.Width - 1 && y <= bitmapa.Height - 1)
                bitmapa.SetPixel((int)x, (int)y, kolor);
            if (x > 1 && y > 1 && x < bitmapa.Width - 1 && y < bitmapa.Height - 1)
            {
                bitmapa.SetPixel((int)(x+1), (int)(y+1), kolor);
                bitmapa.SetPixel((int)x+1, (int)y, kolor);
                bitmapa.SetPixel((int)x+1, (int)y-1, kolor);
                bitmapa.SetPixel((int)x, (int)y+1, kolor);
                bitmapa.SetPixel((int)x, (int)y-1, kolor);
                bitmapa.SetPixel((int)(x-1), (int)y+1, kolor);
                bitmapa.SetPixel((int)x-1, (int)y, kolor);
                bitmapa.SetPixel((int)x-1, (int)(y-1), kolor);

            }
        }
        public void przeksztalc(int width, int height, Macierz projekcja, Macierz widok, Macierz obiekt,bool szescian)
        {
            float[] wek = new float[4] { x, y, z, 1f };
            Wektor wektor = new Wektor(wek);
            pozycjaPrzekszt = obiekt.macierzRazyWektor(wektor);
            pozycjaPrzekszt = widok.macierzRazyWektor(pozycjaPrzekszt);
            pozycjaPrzekszt = projekcja.macierzRazyWektor(pozycjaPrzekszt);

            if (szescian==true)
            {
                //Macierz obiektInv = obiekt.odwrotnoscMacierzy(obiekt.tab);
                //Macierz widokInv = widok.odwrotnoscMacierzy(obiekt.tab);
                //Macierz projekcjaInv = projekcja.odwrotnoscMacierzy(obiekt.tab);

                //if (obiektInv != null && widokInv != null && projekcjaInv != null)
                //{

                //Macierz pom = widok.mnozenieMacierzy(obiekt);
                Macierz pom = obiekt.transpozycja(obiekt);
                pom = pom.odwrotnoscMacierzy(pom.tab);
                //pom = pom.transpozycja(pom);
                wekNormalny2=wekNormalny.wektorRazyMacierz(pom);
                 //   wekNormalny2 = pom.macierzRazyWektor(wekNormalny);
                wekNormalny2.wek[3] = 0;
                wekNormalny2 = wekNormalny2.normalizacja();

                //}
            }

            //Console.WriteLine(pozycjaPrzekszt.wek[0]);
            for (int i = 0; i < 3; i++)
            {
                pozycjaPrzekszt.wek[i] /= pozycjaPrzekszt.wek[3];
            }


            pozycjaEkran.wek[0] = ((pozycjaPrzekszt.wek[0] + 1) / 2);
            pozycjaEkran.wek[1] = ((pozycjaPrzekszt.wek[1] + 1) / 2);
            pozycjaEkran.wek[0] *= width;
            pozycjaEkran.wek[1] *= height;
        }

    }
}
