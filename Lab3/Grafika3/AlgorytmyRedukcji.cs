using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika3
{
    class AlgorytmyRedukcji
    {
        public static void rozpraszanieSrednie(int kR, int kG, int kB, Bitmap bitmapa, Bitmap bitmapa2)
        {
            if (kR < 2 || kG < 2 || kB < 2) return;
            for (int i = 0; i < bitmapa.Width; i++)
            {
                for (int j = 0; j < bitmapa.Height; j++)
                {
                    Color c = bitmapa.GetPixel(i, j);
                    int kolorR = najblizszyZPalety(c.R, kR);
                    int kolorG = najblizszyZPalety(c.G, kG);
                    int kolorB = najblizszyZPalety(c.B, kB);
                    bitmapa2.SetPixel(i, j, Color.FromArgb(kolorR, kolorG, kolorB));
                }
            }
        }
        public static int najblizszyZPalety(int kol,int paleta)
        {
            float przedzialRf = ((kol - (255f / (2 * paleta - 2))) * ((2 * paleta - 2) / 510f));
            int przedzialR;
            if (przedzialRf < 0) przedzialR = -1;
            else przedzialR = (int)przedzialRf;
            przedzialR++;
            if (przedzialR >= paleta) przedzialR = paleta - 1;
            
            int kolorR = (int)(przedzialR * (255f / (paleta - 1)));
            if (kolorR < 0) kolorR = 0;
            return kolorR;
        }
        public static void uporzadkowaneDrzenie(int kR, int kG, int kB, Bitmap bitmapa, Bitmap bitmapa2, bool losowe)
        {
            int nR = wyliczOptymalneN(kR);
            int nG = wyliczOptymalneN(kG);
            int nB = wyliczOptymalneN(kB);

            //losowanie macierzy dla R, G i B
            int[,] macierzR = new int[nR, nR];
            List<int> lista = new List<int>();
            for(int i=0;i<nR*nR;i++)
            {
                lista.Add(i);
            }
            Random rand = new Random();
            for(int i=0;i<nR;i++)
                for(int j=0;j<nR;j++)
                {
                    macierzR[i, j] = lista[rand.Next(lista.Count)];
                }


            int[,] macierzG = new int[nG, nG];
            lista = new List<int>();
            for (int i = 0; i < nG * nG; i++)
            {
                lista.Add(i);
            }
            for (int i = 0; i < nG; i++)
                for (int j = 0; j < nG; j++)
                {
                    macierzG[i, j] = lista[rand.Next(lista.Count)];
                }

            int[,] macierzB = new int[nB, nB];
            lista = new List<int>();
            for (int i = 0; i < nB * nB; i++)
            {
                lista.Add(i);
            }
            for (int i = 0; i < nB; i++)
                for (int j = 0; j < nB; j++)
                {
                    macierzB[i, j] = lista[rand.Next(lista.Count)];
                }


            for (int i = 0; i < bitmapa.Width; i++)
            {
                for (int j = 0; j < bitmapa.Height; j++)
                {
                    Color c = bitmapa.GetPixel(i, j);
                    int kolR = c.R;
                    int kolG = c.G;
                    int kolB = c.B;
                    

                    int colR = kolR / (nR * nR);
                    int reR = kolR % (nR * nR);
                    
                    int iR = i % nR;
                    int jR = j % nR;
                    if(losowe)
                    {
                        iR = rand.Next(nR);
                        jR = rand.Next(nR);
                    }
                    if (reR > macierzR[iR,jR]) colR++;
                    int R = colR * nR * nR;

                    int colG = kolG / (nG * nG);
                    int reG = kolG % (nG * nG);
                    int iG = i % nG;
                    int jG = j % nG;
                    if (losowe)
                    {
                        iG = rand.Next(nG);
                        jG = rand.Next(nG);
                    }
                    if (reG > macierzG[iG, jG]) colG++;
                    int G = colG * nG * nG;

                    int colB = kolB / (nB * nB);
                    int reB = kolB % (nB * nB);
                    int iB = i % nB;
                    int jB = j % nB;
                    if (losowe)
                    {
                        iB = rand.Next(nB);
                        jB = rand.Next(nB);
                    }
                    if (reB > macierzB[iB, jB]) colB++;
                    int B = colB * nB * nB;
                    if (R > 255) R=255;
                    if (G > 255) G=255;
                    if (B > 255) B=255;

                    bitmapa2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

        }
        public static int wyliczOptymalneN(int k)
        {
            int nR = (int)Math.Sqrt((double)256 / (k - 1));
            if (nR <= 2) nR = 2;
            else if (nR <= 3) nR = 3;
            else if (nR <= 4) nR = 4;
            else if (nR <= 6) nR = 6;
            else if (nR <= 8) nR = 8;
            else if (nR <= 12) nR = 12;
            else nR = 16;
            return nR;
        }
        public static void propagacjaBledu(int kR, int kG, int kB, Bitmap bitmapa, Bitmap bitmapa2)
        {
            //uzywam filtru Floyda-Steinberga (7/16,3/16,5/16,1/16)
            float[,] pikseleR= new float[bitmapa.Width, bitmapa.Height];
            float[,] pikseleG= new float[bitmapa.Width, bitmapa.Height];
            float[,] pikseleB = new float[bitmapa.Width, bitmapa.Height];

            for (int i = 0; i < bitmapa.Width; i++)
            {
                for (int j = 0; j < bitmapa.Height; j++)
                {

                    Color c = bitmapa.GetPixel(i, j);
                    pikseleR[i, j] = (float)c.R /255;
                    pikseleG[i, j] = (float)c.G/255;
                    pikseleB[i, j] = (float)c.B/255;

                }
            }

            for (int j = 0; j <bitmapa.Height; j++)
            {
            for (int i=0; i<bitmapa.Width; i++)
                {
                    float stareR = pikseleR[i, j];

                    int pomR = najblizszyZPalety((int)(stareR*255), kR);
                    float kolorR = pomR / 255f;
                    pikseleR[i, j] = kolorR;
                    float errR = stareR - kolorR;
                    if (i + 1 < bitmapa.Width)
                        pikseleR[i + 1, j] +=  errR * (7f / 16);
                    if (i - 1 >= 0 && j + 1 < bitmapa.Height)
                        pikseleR[i - 1, j + 1] += errR * (3f / 16);
                    if (j + 1 < bitmapa.Height)
                        pikseleR[i, j + 1] +=  errR * (5f / 16);
                    if (i + 1 < bitmapa.Width && j + 1 < bitmapa.Height)
                        pikseleR[i + 1, j + 1] += errR * (1f / 16);

                    float stareG = pikseleG[i, j];

                    int pomG = najblizszyZPalety((int)(stareG * 255), kG);
                    float kolorG = pomG / 255f;

                    pikseleG[i, j] = kolorG;
                    float errG = stareG - kolorG;
                    if (i + 1 < bitmapa.Width)
                        pikseleG[i + 1, j] += errG * (7f / 16);
                    if (i - 1 >= 0 && j + 1 < bitmapa.Height)
                        pikseleG[i - 1, j + 1] +=  errG * (3f / 16);
                    if (j + 1 < bitmapa.Height)
                        pikseleG[i, j + 1] +=  errG * (5f / 16);
                    if (i + 1 < bitmapa.Width && j + 1 < bitmapa.Height)
                        pikseleG[i + 1, j + 1] += errG * (1f / 16);

                    float stareB = pikseleB[i, j];

                    int pomB = najblizszyZPalety((int)(stareB * 255), kB);
                    float kolorB = pomB / 255f;
                    pikseleB[i, j] = kolorB;
                    float errB = stareB - kolorB;
                    if (i + 1 < bitmapa.Width)
                        pikseleB[i + 1, j] += errB * (7f / 16);
                    if (i - 1 >= 0 && j + 1 < bitmapa.Height)
                        pikseleB[i - 1, j + 1] += errB * (3f / 16);
                    if (j + 1 < bitmapa.Height)
                        pikseleB[i, j + 1] +=  errB * (5f / 16);
                    if (i + 1 < bitmapa.Width && j + 1 < bitmapa.Height)
                        pikseleB[i + 1, j + 1] += errB * (1f / 16);

                    bitmapa2.SetPixel(i, j, Color.FromArgb(pomR,pomG,pomB));
                }
            }

        }

        public static void algPopularnosciowy(int kol, Bitmap bitmapa, Bitmap bitmapa2)
        {
            int[,,] liczniki = new int[256, 256, 256];
            for(int i=0;i<bitmapa.Width;i++)
            {
                for(int j=0;j<bitmapa.Height;j++)
                {
                    Color c = bitmapa.GetPixel(i, j);
                    liczniki[c.R, c.G, c.B]++;
                }
            }
            LinkedList<(int, int, int,int)> paleta = new LinkedList<(int,int, int, int)>();
            for(int i=0;i<256;i++)
            {
                for(int j=0;j<256;j++)
                {
                    for(int k=0;k<256;k++)
                    {
                        int pom = liczniki[i, j, k];
                        if (paleta.Count < kol && pom!=0)
                        {
                            if(paleta.Count==0)
                                paleta.AddFirst((i, j, k,pom));
                            else
                            {
                                var el = paleta.First;
                                while (el != null && pom < el.Value.Item4)
                                    el = el.Next;
                                if (el != null)
                                    paleta.AddBefore(el, (i, j, k, pom));
                                else
                                    paleta.AddLast((i, j, k, pom));

                            }
                            
                        }
                        if (paleta.Count == kol)
                        {
                            if (paleta.Last.Value.Item4 < pom)
                            {
                                paleta.RemoveLast();
                                var el = paleta.First;
                                while (el != null && pom < el.Value.Item4 )
                                    el = el.Next;
                                if (el != null)
                                    paleta.AddBefore(el, (i, j, k, pom));
                                else
                                    paleta.AddLast((i, j, k, pom));
                            }
                        }



                    }
                }
            }
         

            for (int i = 0; i < bitmapa.Width; i++)
            {
                for (int j = 0; j < bitmapa.Height; j++)
                {
                    Color c = bitmapa.GetPixel(i, j);
                    (int, int, int) wyn = (0, 0, 0);
                    double odl = Double.MaxValue;
                    foreach (var el in paleta)
                    {
                        double pom = Math.Sqrt((c.R - el.Item1) * (c.R - el.Item1) + (c.G - el.Item2) * (c.G - el.Item2) + (c.B - el.Item3) * (c.B - el.Item3));
                        if (pom < odl)
                        {
                            odl = pom;
                            wyn = (el.Item1, el.Item2, el.Item3);

                        }
                    }
                    Color wynikKol = Color.FromArgb(wyn.Item1, wyn.Item2, wyn.Item3);
                    bitmapa2.SetPixel(i, j, wynikKol);
                }
            }
        }
    }
}
