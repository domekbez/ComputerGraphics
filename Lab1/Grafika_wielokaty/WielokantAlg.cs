using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_wielokaty
{
    class WielokantAlg
    {
        public static void usuwanieWierzch(int a, int b, Wierzcholek[,] tabwierzcholkow)
        {
            Wierzcholek ostatniwierzcholek = Wielokant.zwrocWierzcholek(a, b, tabwierzcholkow);
            if (ostatniwierzcholek == null || ostatniwierzcholek.wielok.wierzcholki.Count < 4) return;
            Krawendz k1=null;
            Krawendz k2=null;
            Krawendz k3 = null;
            Krawendz k4 = null;
            foreach (var el in ostatniwierzcholek.wielok.rownoleglekraw)
            {
                if(el.a==ostatniwierzcholek||el.b==ostatniwierzcholek)
                {
                    if (k1 == null) k1 = el;
                    else k2 = el;
                }
            }
            if (k1 != null)
            {
                ostatniwierzcholek.wielok.rownoleglekraw.Remove(k1);
                ostatniwierzcholek.wielok.rownoleglekraw.Remove(k1.odpowkrawendz);

            }
            if (k2 != null)
            {

                ostatniwierzcholek.wielok.rownoleglekraw.Remove(k2);
                ostatniwierzcholek.wielok.rownoleglekraw.Remove(k2.odpowkrawendz);

            }
            foreach (var el in ostatniwierzcholek.wielok.prostopadlekraw)
            {
                if (el.a == ostatniwierzcholek || el.b == ostatniwierzcholek)
                {
                    if (k3 == null) k3 = el;
                    else k4 = el;
                }
            }
            if (k3 != null)
            {
                ostatniwierzcholek.wielok.prostopadlekraw.Remove(k3);
                ostatniwierzcholek.wielok.prostopadlekraw.Remove(k3.odpowkrawendz);

            }
            if (k4 != null)
            {

                ostatniwierzcholek.wielok.prostopadlekraw.Remove(k4);
                ostatniwierzcholek.wielok.prostopadlekraw.Remove(k4.odpowkrawendz);

            }

            ostatniwierzcholek.wielok.wierzcholki.Remove(ostatniwierzcholek);
        }
        public static void przesuwanieWirzchRow(Wierzcholek prawdz,Wierzcholek w,Wierzcholek nowy,Wielokant wielokant)
        {
            

            int ile = 0;
            Krawendz rown1=null;
            Krawendz rown2=null;
            foreach (var el in wielokant.rownoleglekraw)
            {
                if (el.a == prawdz || el.b == prawdz)
                {

                    ile++;
                    if (rown1 == null) rown1 = el;
                    else rown2 = el;
                }
            }
            foreach (var el in wielokant.prostopadlekraw)
            {
                if (el.a == prawdz || el.b == prawdz)
                {

                    ile++;
                    if (rown1 == null) rown1 = el;
                    else rown2 = el;
                }
            }
            if (ile==0)
            {
                return;
            }
            if(ile==1)
            {
                
                Wierzcholek w2;
                Wierzcholek dowyznprostej;
                (Wierzcholek, Wierzcholek) pom;
                if(rown1.a==prawdz)
                {
                    w2 = rown1.b;
                    pom = wielokant.zwrocWierzcholki(rown1.b);
                    if (pom.Item1 == prawdz) dowyznprostej = pom.Item2;
                    else dowyznprostej = pom.Item1;
                }
                else
                {
                    w2 = rown1.a;
                    pom = wielokant.zwrocWierzcholki(rown1.a);
                    if (pom.Item1 == prawdz) dowyznprostej = pom.Item2;
                    else dowyznprostej = pom.Item1;
                }
                double aa = 0;
                if (w2.x == dowyznprostej.x) aa = 0;
                else
                {
                    aa = (double)(w2.y - dowyznprostej.y) / (w2.x - dowyznprostej.x);
                }
                double bb = w2.y - aa * w2.x;
                double aaa = 0;
                if (w.x == w2.x) aaa = 0;
                else
                {
                    aaa = (double)(w2.y - w.y) / (w2.x - w.x);
                }
                double bbb = nowy.y-aaa*nowy.x;
                if (aaa == aa) return;
                double xx = (bb - bbb) / (aaa - aa);
                double yy = xx * aa + bb;
                w2.x = (int)xx;
                w2.y = (int)yy;

            }
            if(ile>=2)
            {
                Wierzcholek w2;
                Wierzcholek w3;
                Wierzcholek dowyznprostej;
                Wierzcholek dowyznprostej2;

                (Wierzcholek, Wierzcholek) pom;
                if (rown1.a == prawdz)
                {
                    w2 = rown1.b;
                    pom = wielokant.zwrocWierzcholki(rown1.b);
                    if (pom.Item1 == prawdz) dowyznprostej = pom.Item2;
                    else dowyznprostej = pom.Item1;
                }
                else
                {
                    w2 = rown1.a;
                    pom = wielokant.zwrocWierzcholki(rown1.a);
                    if (pom.Item1 == prawdz) dowyznprostej = pom.Item2;
                    else dowyznprostej = pom.Item1;
                }
                if (rown2.a == prawdz)
                {
                    w3 = rown2.b;
                    pom = wielokant.zwrocWierzcholki(rown2.b);
                    if (pom.Item1 == prawdz) dowyznprostej2 = pom.Item2;
                    else dowyznprostej2 = pom.Item1;
                }
                else
                {
                    w3 = rown2.a;
                    pom = wielokant.zwrocWierzcholki(rown2.a);
                    if (pom.Item1 == prawdz) dowyznprostej2 = pom.Item2;
                    else dowyznprostej2 = pom.Item1;
                }
                double aa = 0;
                if (w2.x == dowyznprostej.x) aa = 0;
                else
                {
                    aa = (double)(w2.y - dowyznprostej.y) / (w2.x - dowyznprostej.x);
                }
                double bb = w2.y - aa * w2.x;
                double aaa = 0;
                if (w.x == w2.x) aaa = 0;
                else
                {
                    aaa = (double)(w2.y - w.y) / (w2.x - w.x);
                }
                double bbb = nowy.y - aaa * nowy.x;
                if (aaa == aa) return;
                double xx = (bb - bbb) / (aaa - aa);
                double yy = xx * aa + bb;
                w2.x = (int)xx;
                w2.y = (int)yy;
                // drugi wierzcholek
                aa = 0;
                if (w3.x == dowyznprostej2.x) aa = 0;
                else
                {
                    aa = (double)(w3.y - dowyznprostej2.y) / (w3.x - dowyznprostej2.x);
                }
                bb = w3.y - aa * w3.x;
                aaa = 0;
                if (w.x == w3.x) aaa = 0;
                else
                {
                    aaa = (double)(w3.y - w.y) / (w3.x - w.x);
                }
                bbb = nowy.y - aaa * nowy.x;
                if (aaa == aa) return;
                xx = (bb - bbb) / (aaa - aa);
                yy = xx * aa + bb;
                w3.x = (int)xx;
                w3.y = (int)yy;
            }
            
        }

        public static void przesuwanieKrawRow(Wierzcholek n1,Wierzcholek n2, Wierzcholek w1st, Wierzcholek w2st, Krawendz kraw, Wielokant wielokant)
        {
            int ile = 0;
            (Wierzcholek, Wierzcholek) para;
            Wierzcholek w3 = null, w4 = null, w5 = null, w6 = null;
            foreach (var el in wielokant.rownoleglekraw)
            {
                if ((el.a == kraw.a && el.b != kraw.b) || (el.a != kraw.a && el.b == kraw.b)||(el.a==kraw.b&&el.b!=kraw.a)||(el.b==kraw.a&&el.a!=kraw.b))
                {

                    ile++;

                }
            }
            foreach (var el in wielokant.prostopadlekraw)
            {
                if ((el.a == kraw.a && el.b != kraw.b) || (el.a != kraw.a && el.b == kraw.b) || (el.a == kraw.b && el.b != kraw.a) || (el.b == kraw.a && el.a != kraw.b))
                {

                    ile++;

                }
            }
            if (ile == 0)
            {
                return;
            }
            else
            {
                
                para=wielokant.zwrocWierzcholki(kraw.a);
                if (para.Item1 == kraw.b)
                    w3 = para.Item2;
                else
                    w3 = para.Item1;
                para = wielokant.zwrocWierzcholki(w3);
                if (para.Item1 == n1)
                    w4 = para.Item2;
                else
                    w4 = para.Item1;

                para = wielokant.zwrocWierzcholki(kraw.b);
                if (para.Item1 == kraw.a)
                    w5 = para.Item2;
                else
                    w5 = para.Item1;
                para = wielokant.zwrocWierzcholki(w5);
                if (para.Item1 == n2)
                    w6 = para.Item2;
                else
                    w6 = para.Item1;
                //wyznaczanie punktow
                double aa = 0;
                if (w5.x == w6.x) aa = 0;
                else
                {
                    aa = (double)(w5.y - w6.y) / (w5.x - w6.x);
                }
                double bb = w5.y - aa * w5.x;
                double aaa = 0;
                if (w2st.x == w5.x) aaa = 0;
                else
                {
                    aaa = (double)(w5.y - w2st.y) / (w5.x - w2st.x);
                }
                double bbb = n2.y - aaa * n2.x;
                if (aaa == aa) return;
                double xx = (bb - bbb) / (aaa - aa);
                double yy = xx * aa + bb;
                w5.x = (int)xx;
                w5.y = (int)yy;
                //druga krawedz
                aa = 0;
                if (w3.x == w4.x) aa = 0;
                else
                {
                    aa = (double)(w3.y - w4.y) / (w3.x - w4.x);
                }
                bb = w3.y - aa * w3.x;
                aaa = 0;
                if (w1st.x == w3.x) aaa = 0;
                else
                {
                    aaa = (double)(w3.y - w1st.y) / (w3.x - w1st.x);
                }
                bbb = n1.y - aaa * n1.x;
                if (aaa == aa) return;
                xx = (bb - bbb) / (aaa - aa);
                yy = xx * aa + bb;
                w3.x = (int)xx;
                w3.y = (int)yy;

            }
        }
    }
}
