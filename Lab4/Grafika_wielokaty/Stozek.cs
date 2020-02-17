using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grafika_wielokaty
{
    class Stozek
    {
        public Siatka generujStozek(int podzial,float wysokosc,float promien)
        {
            Siatka s = new Siatka();
            s.trojkanty = new List<Trojkant>();
            Wierzcholek gora = new Wierzcholek(0, 0, 0);
            Wierzcholek dol = new Wierzcholek(0, -wysokosc, 0);
            for (float i = 0; i < 2 * Math.PI; i += (float)Math.PI / podzial)
            {
                float x = promien*(float)Math.Sin(i);
                float y = (float)Math.Cos(i);
                float x2 = promien*(float)Math.Sin(i + (float)Math.PI / podzial);
                float y2 = (float)Math.Cos(i + (float)Math.PI / podzial);
                Trojkant troj1 = new Trojkant();
                Trojkant troj2 = new Trojkant();

                troj1.wierzcholki.Add(dol);
                troj1.wierzcholki.Add(new Wierzcholek(x2, 0, y2));
                troj1.wierzcholki.Add(new Wierzcholek(x, 0, y));

                troj2.wierzcholki.Add(gora);
                troj2.wierzcholki.Add(new Wierzcholek(x, 0, y));
                troj2.wierzcholki.Add(new Wierzcholek(x2, 0, y2));

                s.trojkanty.Add(troj1);
                s.trojkanty.Add(troj2);
            }
            s.generujWierzcholki();
            return s;
        }
    }
    
}
