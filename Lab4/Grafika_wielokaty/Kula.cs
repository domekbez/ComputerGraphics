using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grafika_wielokaty
{
    class Kula
    {
        float R;
        public Kula(float R)
        {
            this.R = R;
        }
        public Siatka generujKule(int slices, int stacks)
        {
            
            Siatka s = new Siatka();
            s.trojkanty = new List<Trojkant>();
            Trojkant troj = new Trojkant();
            for (int t = 0; t < stacks; t++) // stacks are ELEVATION so they count theta
            {
                float theta1 = ((float)(t) / stacks) * (float)Math.PI;
                float theta2 = ((float)(t + 1) / stacks) *(float)Math.PI;

                for (int p = 0; p < slices; p++) // slices are ORANGE SLICES so the count azimuth
                {
                    float phi1 = ((float)(p) / slices) * 2 * (float)Math.PI; // azimuth goes around 0 .. 2*PI
                    float phi2 = ((float)(p + 1) / slices) * 2 * (float)Math.PI;

                    Wierzcholek w1 = new Wierzcholek((float)(R * Math.Sin(theta1) * Math.Cos(phi1)), (float)(R * Math.Cos(theta1)),(float)( R * Math.Sin(theta1) *Math.Sin(phi1)));
                    Wierzcholek w2 = new Wierzcholek((float)(R * Math.Sin(theta1) * Math.Cos(phi2)), (float)(R * Math.Cos(theta1)), (float)(R * Math.Sin(theta1) * Math.Sin(phi2)));
                    Wierzcholek w3 = new Wierzcholek((float)(R * Math.Sin(theta2) * Math.Cos(phi2)), (float)(R * Math.Cos(theta2)), (float)(R * Math.Sin(theta2) * Math.Sin(phi2)));
                    Wierzcholek w4 = new Wierzcholek((float)(R * Math.Sin(theta2) * Math.Cos(phi1)), (float)(R * Math.Cos(theta2)), (float)(R * Math.Sin(theta2) * Math.Sin(phi1)));
                    w1.u = 0.5f + (float)(Math.Atan2(w1.z, w1.x) / 2*Math.PI);
                    w2.u = 0.5f + (float)(Math.Atan2(w2.z, w2.x) / 2 * Math.PI);
                    w3.u = 0.5f + (float)(Math.Atan2(w3.z, w3.x) / 2 * Math.PI);
                    w4.u = 0.5f + (float)(Math.Atan2(w4.z, w4.x) / 2 * Math.PI);

                    w1.v=0.5f - (float)(Math.Asin(w1.y)/Math.PI);
                    w2.v = 0.5f - (float)(Math.Asin(w2.y) / Math.PI);
                    w3.v = 0.5f - (float)(Math.Asin(w3.y) / Math.PI);
                    w4.v = 0.5f - (float)(Math.Asin(w4.y) / Math.PI);

                    // facing out
                    if (t == 0) // pierwszy trojkat
                    {
                        troj.wierzcholki.Add(w1);
                        troj.wierzcholki.Add(w3);

                        troj.wierzcholki.Add(w4);

                        s.trojkanty.Add(troj);
                    }//t1p1, t2p2, t2p1
                    else if (t + 1 == stacks) //ostatni trojkat
                    {
                        troj = new Trojkant();
                        troj.wierzcholki.Add(w3);
                        troj.wierzcholki.Add(w1);

                        troj.wierzcholki.Add(w2);
                        s.trojkanty.Add(troj);
                    }
                    else //prostokat podzielony na 2 trojkaty
                    {
                        troj = new Trojkant();
                        troj.wierzcholki.Add(w1);
                        troj.wierzcholki.Add(w2);

                        troj.wierzcholki.Add(w4);
                        s.trojkanty.Add(troj);

                        troj = new Trojkant();
                        troj.wierzcholki.Add(w2);
                        troj.wierzcholki.Add(w3);

                        troj.wierzcholki.Add(w4);
                        s.trojkanty.Add(troj);
                    }
                }
            }
            s.generujWierzcholki();
            return s;
        }
            
    }
}