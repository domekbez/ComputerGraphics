using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Renderer
    {
        public float fov,dalszaSciana,blizszaSciana,aspekt;
        public int width, height;

        private bool czyPrawoskretnie(int w1x,int w1y, int w2x, int w2y, int w3x, int w3y)
        {
            return (w2x - w1x) * (w3y - w1y) - (w2y - w1y) * (w3x - w1x) > 0;
        }
        public Renderer(int width, int height,float fov, float dalszaSciana, float blizszaSciana)
        {
            
            this.width = width;
            this.height =height;
            this.fov = fov;
            this.dalszaSciana = dalszaSciana;
            this.blizszaSciana = blizszaSciana;
            aspekt = (float)width / height;
        }
        
        private Macierz macierzProjekcji()
        {
            float a = 1f / (float)Math.Tan(fov/2); //ctg(fov)
            float[,] wynik = new float[4, 4];
            wynik[0, 0] = a/aspekt;
            wynik[1, 1] = a;
            wynik[2, 2] = -(dalszaSciana + blizszaSciana) / (dalszaSciana - blizszaSciana);
            wynik[2, 3] = (-2f * dalszaSciana * blizszaSciana) / (dalszaSciana - blizszaSciana);
            wynik[3, 2] = -1f;
            //wynik[2, 2] = (dalszaSciana+blizszaSciana) / (dalszaSciana - blizszaSciana);
            //wynik[2, 3] = (-2f * dalszaSciana * blizszaSciana) / (dalszaSciana - blizszaSciana);
            //wynik[3, 2] = 1f;


            return new Macierz(wynik);
        }
        public void renderuj(Wektor pozycjaKamery, Material material,DirectBitmap bitmapa,Wektor swiatlo, Wektor kolorSwiatla,Scena scena, DirectBitmap tekstura, bool backfaceCulling, bool zbuffer, bool scanlinia,bool czySiatka)
        {
            Macierz projekcja = macierzProjekcji(); //??????
            
            Macierz widok = scena.kamera.macierzWidoku();
   
            foreach (var el in scena.obiekty)
            {
                Macierz obiekt = el.zwrocMacierzModelu();
                
                foreach (var el2 in el.siatka.wierzcholki)
                {
                    if(el.name.StartsWith("P"))
                        el2.przeksztalc(width, height, projekcja, widok, obiekt,true);
                    else
                        el2.przeksztalc(width, height, projekcja, widok, obiekt, false);

                }
                foreach (var el3 in el.siatka.trojkanty)
                {

                    
                    
                    Trojkant t = new Trojkant();
                    t.wierzcholki = new List<Wierzcholek>();
                    Wierzcholek w = new Wierzcholek(el3.wierzcholki[0].pozycjaEkran.wek[0], el3.wierzcholki[0].pozycjaEkran.wek[1], el3.wierzcholki[0].pozycjaPrzekszt.wek[2],el3.wierzcholki[0].wekNormalny2,el3.wierzcholki[0].u, el3.wierzcholki[0].v);
                    Wierzcholek w2 = new Wierzcholek(el3.wierzcholki[1].pozycjaEkran.wek[0], el3.wierzcholki[1].pozycjaEkran.wek[1], el3.wierzcholki[1].pozycjaPrzekszt.wek[2], el3.wierzcholki[1].wekNormalny2, el3.wierzcholki[1].u, el3.wierzcholki[1].v);
                    Wierzcholek w3 = new Wierzcholek(el3.wierzcholki[2].pozycjaEkran.wek[0], el3.wierzcholki[2].pozycjaEkran.wek[1], el3.wierzcholki[2].pozycjaPrzekszt.wek[2], el3.wierzcholki[2].wekNormalny2, el3.wierzcholki[2].u, el3.wierzcholki[2].v );

                    t.wierzcholki.Add(w);
                    t.wierzcholki.Add(w2);
                    t.wierzcholki.Add(w3);
                    if (backfaceCulling)
                    {
                        if (!czyPrawoskretnie((int)el3.wierzcholki[0].pozycjaEkran.wek[0], (int)el3.wierzcholki[0].pozycjaEkran.wek[1],
                          (int)el3.wierzcholki[1].pozycjaEkran.wek[0], (int)el3.wierzcholki[1].pozycjaEkran.wek[1],
                          (int)el3.wierzcholki[2].pozycjaEkran.wek[0], (int)el3.wierzcholki[2].pozycjaEkran.wek[1]))
                        {
                            continue;
                        }
                    }
                    if (czySiatka)
                    {
                        Bresenham.bresenhamLinia(bitmapa, (int)el3.wierzcholki[0].pozycjaEkran.wek[0], (int)el3.wierzcholki[0].pozycjaEkran.wek[1],
                           (int)el3.wierzcholki[1].pozycjaEkran.wek[0], (int)el3.wierzcholki[1].pozycjaEkran.wek[1], Color.Black);
                        Bresenham.bresenhamLinia(bitmapa, (int)el3.wierzcholki[1].pozycjaEkran.wek[0], (int)el3.wierzcholki[1].pozycjaEkran.wek[1],
                            (int)el3.wierzcholki[2].pozycjaEkran.wek[0], (int)el3.wierzcholki[2].pozycjaEkran.wek[1], Color.Black);
                        Bresenham.bresenhamLinia(bitmapa, (int)el3.wierzcholki[2].pozycjaEkran.wek[0], (int)el3.wierzcholki[2].pozycjaEkran.wek[1],
                            (int)el3.wierzcholki[0].pozycjaEkran.wek[0], (int)el3.wierzcholki[0].pozycjaEkran.wek[1], Color.Black);
                    }
                    if (scanlinia)
                    {
                        if (Math.Abs(el3.wierzcholki[0].pozycjaEkran.wek[1] - el3.wierzcholki[1].pozycjaEkran.wek[1]) <= 1
                        && Math.Abs(el3.wierzcholki[1].pozycjaEkran.wek[1] - el3.wierzcholki[2].pozycjaEkran.wek[1]) <= 1)
                            continue;
                        // if (el3.wierzcholki[0].pozycjaEkran.wek[1] == el3.wierzcholki[1].pozycjaEkran.wek[1] && el3.wierzcholki[0].pozycjaEkran.wek[1] == el3.wierzcholki[2].pozycjaEkran.wek[1])
                        //    continue;

                        if (tekstura == null || !el.name.StartsWith("P"))
                            ScanLinia.wypelnijWielokat(pozycjaKamery,material,swiatlo,kolorSwiatla,t, bitmapa, false, el.kolor, zbuffer,tekstura);
                        else
                        {
                            w.kolor = tekstura.GetPixel((int)(el3.wierzcholki[0].u * width), (int)(el3.wierzcholki[0].v * height));
                            w2.kolor = tekstura.GetPixel((int)(el3.wierzcholki[1].u * width), (int)(el3.wierzcholki[1].v * height));
                            w3.kolor = tekstura.GetPixel((int)(el3.wierzcholki[2].u * width), (int)(el3.wierzcholki[2].v * height));

                            ScanLinia.wypelnijWielokat(pozycjaKamery,material,swiatlo, kolorSwiatla, t, bitmapa, true, el.kolor,zbuffer,tekstura);

                        }
                    }

                }

            }
            

        }


    }
}
