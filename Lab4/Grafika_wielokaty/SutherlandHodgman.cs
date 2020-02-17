using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class SutherlandHodgman
    {
        public static Wielokant suthHodg(Wielokant w, Wielokant wypukly)
        {
            int nwyp = wypukly.wierzcholki.Count;
            List<Point> wyjsciowa = new List<Point>();
            foreach (var el in w.wierzcholki)
            {
                wyjsciowa.Add(new Point((int)el.x, (int)el.y));
            }

            for (int i = 0; i < wypukly.wierzcholki.Count; i++)
            {
                List<Point> wejsciowa = new List<Point>();
                foreach (var el in wyjsciowa)
                {
                    wejsciowa.Add(new Point(el.x, el.y));
                }
                wyjsciowa.Clear();

                for (int j = 0; j < wejsciowa.Count; j++)
                {
                    Point obecny = wejsciowa[j];
                    Point poprzedni = wejsciowa[(j + wejsciowa.Count - 1) % wejsciowa.Count];

                    Point punktPrzec = wyznaczPrzeciecie(poprzedni, obecny, wypukly.wierzcholki[i], wypukly.wierzcholki[(i + 1) % nwyp]);

                    if (wewnatrz(obecny, wypukly.wierzcholki[i], wypukly.wierzcholki[(i + 1) % nwyp]))
                    {
                        if (!wewnatrz(poprzedni, wypukly.wierzcholki[i], wypukly.wierzcholki[(i + 1) % nwyp]))
                            wyjsciowa.Add(punktPrzec);
                        wyjsciowa.Add(obecny);
                    }
                    else if (wewnatrz(poprzedni, wypukly.wierzcholki[i], wypukly.wierzcholki[(i + 1) % nwyp]))
                        wyjsciowa.Add(punktPrzec);

                }




            }
            Wielokant nowy = new Wielokant();
            nowy.wierzcholki = new List<Wierzcholek>();
            nowy.kolor = Color.Black;
            foreach (var el in wyjsciowa)
            {
                nowy.wierzcholki.Add(new Wierzcholek(el.x, el.y, nowy));
            }
            return nowy;
        }

        private static bool wewnatrz(Point obecny, Wierzcholek wierzcholek1, Wierzcholek wierzcholek2)
        {
            return ((wierzcholek1.x - obecny.x) * (wierzcholek2.y - obecny.y) - (wierzcholek2.x - obecny.x) * (wierzcholek1.y - obecny.y)) > 0;
        }
        private static Point wyznaczPrzeciecie(Point poprzedni, Point obecny, Wierzcholek wierzcholek1, Wierzcholek wierzcholek2)
        {
            (float, float) wektor1 = (obecny.x - poprzedni.x, obecny.y - poprzedni.y);
            (float, float) wektor2 = (wierzcholek2.x - wierzcholek1.x, wierzcholek2.y - wierzcholek1.y);
            var rownolegl = wektor1.Item1 * wektor2.Item2 - wektor1.Item2 * wektor2.Item1;

            if (Math.Abs(rownolegl) <= 0.0001) return null;

            (float, float) c = (wierzcholek1.x - poprzedni.x, wierzcholek1.y - poprzedni.y);
            var t = (c.Item1 * wektor2.Item2 - c.Item2 * wektor2.Item1) / rownolegl;
            return new Point((int)(poprzedni.x + t * wektor1.Item1), (int)(poprzedni.y + t * wektor1.Item2));
        }

     
    }
}
