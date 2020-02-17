using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Walec
    {

        public Siatka generujWalec(int podzial,float wysokosc, float promien)
        {
            float h1 = wysokosc / 2;
            float h2 = -h1;
            Siatka s = new Siatka();
            s.trojkanty = new List<Trojkant>();
            Wierzcholek gora = new Wierzcholek(0, h1, 0);
            Wierzcholek dol = new Wierzcholek(0, h2, 0);
            for(float i = 0; i < 2* Math.PI; i += (float)Math.PI / podzial)
            {
                float x = promien*(float)Math.Sin(i);
                float y = (float)Math.Cos(i);
                float x2 = promien*(float)Math.Sin(i+ (float)Math.PI / podzial);
                float y2 = (float)Math.Cos(i + (float)Math.PI / podzial);
                Trojkant troj1 = new Trojkant();
                Trojkant troj2 = new Trojkant();
                Trojkant troj3 = new Trojkant();
                Trojkant troj4 = new Trojkant();

                troj1.wierzcholki.Add(dol);
                troj1.wierzcholki.Add(new Wierzcholek(x, h2 , y));
                troj1.wierzcholki.Add(new Wierzcholek(x2,h2, y2));

                troj2.wierzcholki.Add(new Wierzcholek(x, h1, y));
                troj2.wierzcholki.Add(gora);
                troj2.wierzcholki.Add(new Wierzcholek(x2, h1, y2));

                troj3.wierzcholki.Add(new Wierzcholek(x, h1, y));
                troj3.wierzcholki.Add(new Wierzcholek(x2, h1, y2));
                troj3.wierzcholki.Add(new Wierzcholek(x, h2, y));

                troj4.wierzcholki.Add(new Wierzcholek(x, h2, y));
                troj4.wierzcholki.Add(new Wierzcholek(x2, h1, y2));
                troj4.wierzcholki.Add(new Wierzcholek(x2, h2, y2));

                s.trojkanty.Add(troj1);
                s.trojkanty.Add(troj2);
                s.trojkanty.Add(troj3);
                s.trojkanty.Add(troj4);
            }
            s.generujWierzcholki();
            return s;
        }
    }
}