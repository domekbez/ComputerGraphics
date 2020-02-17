using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_wielokaty
{
    public enum FUNKCJA
    {
        NIC,TWORZOKR,PRZESOKR,ZMIANAPROM,TWORZWIEL,DODWIERZ,USUWWIERZ,PRZESWIERZ,PRZESKRAW,PRZESWIEL,ROWNKRAW,PROSTKRAW, USUNRELACJE, PROSTOPADLOSC

    }
    public partial class Form1 : Form
    {
        FUNKCJA funkcja;
        Stopwatch czas;
        public Color kolor;
        public Bitmap bitmapa;
        List<Okrag> okregi;
        List<Wielokant> wielokaty;
        (int, int)? srodekokregu;
        (int, int)? ostatnipunkt;
        Okrag[,] tabokregow;
        (int, int) wierzcholkirown;
        Wierzcholek[,] tabwierzcholkow;
        Krawendz[,] tabkrawedzi;
        (int, int) ostatniepoloz;
        (int, int) dxdy;
        (int, int, int, int) roznicaprzes;
        bool okragrozmiar = false;
        bool startruszania = true;
        bool nowywielokat = true;
        bool zmianapromienia = false;
        bool przesuwaniewierzch = false;
        bool przesuwaniekraw = false;
        bool przesuwaniewielok = false;
        (Krawendz, Krawendz) rownolegleprzesuwanie;
        Wielokant ostatniwiel;
        Okrag ostatniokrag;
        Wierzcholek ostatniwierzcholek;
        Krawendz ostatniakrawendz;
        Krawendz rown1;
        Krawendz rown2;
        (int, int, int, int) krawendzrown;

        public Form1()
        {
            InitializeComponent();
            czas = new Stopwatch();
            czas.Start();

            funkcja = FUNKCJA.TWORZWIEL;
            tabokregow = new Okrag[3 * pictureBox1.Width + 2, 3 * pictureBox1.Height + 2];
            tabwierzcholkow = new Wierzcholek[3 * pictureBox1.Width + 2, 3 * pictureBox1.Height + 2];
            tabkrawedzi = new Krawendz[3 * pictureBox1.Width + 2, 3 * pictureBox1.Height + 2];

            
            ostatniwiel = new Wielokant();
            ostatniokrag = new Okrag(kolor);

            kolor = Color.Black;
            ostatnipunkt = null;
            srodekokregu = null;
            wielokaty = new List<Wielokant>();
            okregi = new List<Okrag>();
            bitmapa = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            

            //if(rysowanie wielokata)
            if (funkcja == FUNKCJA.TWORZWIEL)
            {
                if (nowywielokat)
                {
                    ostatniwiel.kolor = kolor;
                    ostatniwiel.wierzcholki.Clear();
                    wielokaty.Add(ostatniwiel);
                    ostatniwiel.wierzcholki.Add(new Wierzcholek(e.X, e.Y, ostatniwiel));
                    nowywielokat = false;
                    zablokujPrzyciski(tworz_wiel);
                    return;
                }
                else
                {
                    if (ostatnipunkt.HasValue)
                        if (ostatniwiel.wierzcholki.Count>3&&DodatkoweAlg.czyBlisko(e.X, e.Y, ostatnipunkt.Value.Item1, ostatnipunkt.Value.Item2))
                        {
                            nowywielokat = true;

                            ostatnipunkt = null;
                            ostatniwiel.wierzcholki[ostatniwiel.wierzcholki.Count - 1].x = ostatniwiel.wierzcholki[0].x;
                            ostatniwiel.wierzcholki[ostatniwiel.wierzcholki.Count - 1].y = ostatniwiel.wierzcholki[0].y;
                            ostatniwiel.wierzcholki.RemoveAt(0);
                            ostatniwiel.tablicaWierzcholkow(tabwierzcholkow, bitmapa);
                            ostatniwiel.tablicaKrawedzi(tabkrawedzi, bitmapa);
                            odblokujPrzyciski();
                            ostatniwiel = new Wielokant();

                        }
                        else
                        {
                            ostatniwiel.wierzcholki[ostatniwiel.wierzcholki.Count - 1].x = e.X;
                            ostatniwiel.wierzcholki[ostatniwiel.wierzcholki.Count - 1].y = e.Y;
                        }
                }
                startruszania = true;
                ostatnipunkt = (e.X, e.Y);
                pictureBox1.Image = bitmapa;
                pictureBox1.Invalidate();
            }
            else if (funkcja == FUNKCJA.PRZESWIERZ)
            {
                if (!przesuwaniewierzch)
                {

                    wierzcholkirown = (e.X, e.Y);
                    ostatniwierzcholek = Wielokant.zwrocWierzcholek(e.X, e.Y, tabwierzcholkow);
                    if (ostatniwierzcholek == null) return;
                    foreach(var el in ostatniwierzcholek.wielok.rownoleglekraw)
                    {
                        if (el.a == ostatniwierzcholek)
                            rownolegleprzesuwanie = (el, el.odpowkrawendz);
                        break;
                    }
                    foreach (var el in ostatniwierzcholek.wielok.prostopadlekraw)
                    {
                        if (el.a == ostatniwierzcholek)
                            rownolegleprzesuwanie = (el, el.odpowkrawendz);
                        break;
                    }
                    if (ostatniwierzcholek != null)
                    {
                        przesuwaniewierzch = true;
                        zablokujPrzyciski(przes_wierz);
                    }
                    else return;

                }
                else
                {
                    WielokantAlg.przesuwanieWirzchRow(ostatniwierzcholek,new Wierzcholek(wierzcholkirown.Item1,wierzcholkirown.Item2,null), new Wierzcholek(e.X, e.Y, null),ostatniwierzcholek.wielok);
                    ostatniwierzcholek.x = e.X;
                    ostatniwierzcholek.y = e.Y;
                    przesuwaniewierzch = false;
                    odblokujPrzyciski();
                    resetujPiks();
                }
            }
            else if (funkcja == FUNKCJA.USUWWIERZ)
            {
                WielokantAlg.usuwanieWierzch(e.X, e.Y, tabwierzcholkow);
                //narysujWszystko();
            }
            else if (funkcja == FUNKCJA.PRZESKRAW)
            {
                if (!przesuwaniekraw)
                {
                    int p1 = 0, p2 = 0;
                    ostatniakrawendz = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                    if (ostatniakrawendz == null) return;
                    przesuwaniekraw = true;
                    zablokujPrzyciski(Przes_kraw);
                    krawendzrown = (ostatniakrawendz.a.x, ostatniakrawendz.a.y, ostatniakrawendz.b.x, ostatniakrawendz.b.y);
                    roznicaprzes = (e.X - ostatniakrawendz.a.x, e.Y - ostatniakrawendz.a.y, e.X - ostatniakrawendz.b.x, e.Y - ostatniakrawendz.b.y);

                }
                else
                {
                    int i;
                    i = 0;
                    foreach (var el in ostatniakrawendz.a.wielok.rownoleglekraw)
                    {
                        if ((el.a == ostatniakrawendz.a && el.b != ostatniakrawendz.b) || (el.a != ostatniakrawendz.a && el.b == ostatniakrawendz.b))
                        {

                            i++;
                            if (rown1 == null) rown1 = el;
                            else rown2 = el;
                        }
                    }

                    WielokantAlg.przesuwanieKrawRow(ostatniakrawendz.a, ostatniakrawendz.b, new Wierzcholek(krawendzrown.Item1, krawendzrown.Item2, null),
                        new Wierzcholek(krawendzrown.Item3, krawendzrown.Item4, null), ostatniakrawendz, ostatniakrawendz.a.wielok);
                    przesuwaniekraw = false;
                    ostatniakrawendz.a.x = e.X - roznicaprzes.Item1;
                    ostatniakrawendz.a.y = e.Y - roznicaprzes.Item2;
                    ostatniakrawendz.b.x = e.X - roznicaprzes.Item3;
                    ostatniakrawendz.b.y = e.Y - roznicaprzes.Item4;
                    odblokujPrzyciski();
                    resetujPiks();
                    //narysujWszystko();
                }

            }
            else if (funkcja == FUNKCJA.DODWIERZ)
            {
                int p1 = 0, p2 = 0;
                ostatniakrawendz = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                if (ostatniakrawendz == null) return;
                Krawendz dousun=null;
                foreach(var el in ostatniakrawendz.a.wielok.rownoleglekraw)
                {
                    if((el.a==ostatniakrawendz.a&&el.b==ostatniakrawendz.b)||(el.a==ostatniakrawendz.b&&el.b==ostatniakrawendz.a))
                    {
                        dousun = el;
                        break;

                    }
                }
                if(dousun==null)
                    foreach (var el in ostatniakrawendz.a.wielok.prostopadlekraw)
                    {
                        if ((el.a == ostatniakrawendz.a && el.b == ostatniakrawendz.b) || (el.a == ostatniakrawendz.b && el.b == ostatniakrawendz.a))
                        {
                            dousun = el;
                            break;

                        }
                    }
                if (dousun!=null)
                {
                    dousun.a.wielok.rownoleglekraw.Remove(dousun.odpowkrawendz);
                    dousun.a.wielok.rownoleglekraw.Remove(dousun);
                    dousun.a.wielok.prostopadlekraw.Remove(dousun.odpowkrawendz);
                    dousun.a.wielok.prostopadlekraw.Remove(dousun);

                }
                
                ostatniakrawendz.a.wielok.wierzcholki.Insert(ostatniakrawendz.a.wielok.wierzcholki.IndexOf(ostatniakrawendz.a) +1 , new Wierzcholek(p1, p2, ostatniakrawendz.a.wielok));
              
                resetujPiks();
                //narysujWszystko();
            }
            else if (funkcja == FUNKCJA.PRZESWIEL)
            {
                if (!przesuwaniewielok)
                {
                    int p1 = 0, p2 = 0;
                    ostatniakrawendz = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                    if (ostatniakrawendz == null) return;
                    przesuwaniewielok = true;
                    zablokujPrzyciski(przes_wielok);
                    ostatniepoloz = (e.X, e.Y);

                }
                else
                {
                    przesuwaniewielok = false;
                    foreach (var el in ostatniakrawendz.a.wielok.wierzcholki)
                    {
                        el.x += e.X - ostatniepoloz.Item1;
                        el.y += e.Y - ostatniepoloz.Item2;

                    }
                    resetujPiks();
                    odblokujPrzyciski();
                    //narysujWszystko();
                }
            }
            else if (funkcja == FUNKCJA.TWORZOKR)
            {
                if (srodekokregu == null)
                {
                    ostatniokrag = new Okrag(kolor);
                    ostatniokrag.x = e.X;
                    ostatniokrag.y = e.Y;
                    ostatniokrag.promien = 0;
                    srodekokregu = (e.X, e.Y);
                    okregi.Add(ostatniokrag);
                    zablokujPrzyciski(tworz_okr);
                }
                else
                {

                    int a = DodatkoweAlg.obliczPromien(srodekokregu.Value.Item1, srodekokregu.Value.Item2, e.X, e.Y);

                    ostatniokrag.tablicaOkregow(pictureBox1.Width, pictureBox1.Height, tabokregow);
                    ostatniokrag.promien = a;
                    ostatniokrag = new Okrag(kolor);
                    odblokujPrzyciski();
                    srodekokregu = null;
                }
            }
            else if (funkcja == FUNKCJA.ZMIANAPROM)
            {
                if (!zmianapromienia)
                {
                    ostatniokrag = Okrag.zwrocOkrag(e.X, e.Y, tabokregow);
                    if (ostatniokrag != null)
                    {
                        zmianapromienia = true;
                        zablokujPrzyciski(zmien_prom);
                    }
                    else return;
                }
                else
                {
                    zmianapromienia = false;
                    ostatniokrag.promien = DodatkoweAlg.obliczPromien(ostatniokrag.x, ostatniokrag.y, e.X, e.Y);
                    ostatniokrag.wyczyscTab(pictureBox1.Width, pictureBox1.Height, tabokregow);
                    ostatniokrag.tablicaOkregow(pictureBox1.Width, pictureBox1.Height, tabokregow);

                    ostatniokrag = new Okrag(kolor);
                    srodekokregu = null;
                    odblokujPrzyciski();
                }
            }
            else if (funkcja == FUNKCJA.PRZESOKR)
            {
                if (!okragrozmiar)
                {
                    ostatniokrag = Okrag.zwrocOkrag(e.X, e.Y, tabokregow);
                    if (ostatniokrag == null) return;
                    dxdy = (e.X - ostatniokrag.x, e.Y - ostatniokrag.y);
                    okragrozmiar = true;
                    zablokujPrzyciski(przes_okr);
                }
                else
                {
                    okragrozmiar = false;
                    ostatniokrag.x = e.X - dxdy.Item1;
                    ostatniokrag.y = e.Y - dxdy.Item2;
                    ostatniokrag.wyczyscTab(pictureBox1.Width, pictureBox1.Height, tabokregow);
                    ostatniokrag.tablicaOkregow(pictureBox1.Width, pictureBox1.Height, tabokregow);
                    ostatniokrag = new Okrag(kolor);
                    srodekokregu = null;
                    odblokujPrzyciski();
                }
            }
            else if(funkcja==FUNKCJA.ROWNKRAW)
            {

                int p1 = 0, p2 = 0;
                if (rown1 == null)
                {
                    rown1 = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                    if (rown1 == null)
                        return;
                    //if (rown1.a.wielok.rownoleglekraw.Contains(rown1)||rown1.a.wielok.prostopadlekraw.Contains(rown1))
                    //{
                    //    rown1 = null;
                    //    return;
                    //}
                    foreach (var el in rown1.a.wielok.rownoleglekraw)
                    {
                        if(el.a==rown1.a&&el.b==rown1.b)
                        {
                            rown1 = null;
                            return;
                        }
                    }
                    foreach (var el in rown1.a.wielok.prostopadlekraw)
                    {
                        if (el.a == rown1.a && el.b == rown1.b)
                        {
                            rown1 = null;
                            return;
                        }
                    }
                }
                else
                {
                    rown2 = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                    if (rown2 == null) return;
                    if (rown1.a.wielok!=rown2.a.wielok)
                    {
                        rown2 = null;
                        return;
                    }
                    foreach (var el in rown1.a.wielok.rownoleglekraw)
                    {
                        if (el.a == rown2.a && el.b == rown2.b)
                        {
                            rown2 = null;
                            return;
                        }
                    }
                    foreach (var el in rown1.a.wielok.prostopadlekraw)
                    {
                        if (el.a == rown2.a && el.b == rown2.b)
                        {
                            rown2 = null;
                            return;
                        }
                    }
                }

                if (rown2 == null) return;
                if (rown1 == rown2) return;
                if (rown1.a == rown2.a || rown1.a == rown2.b || rown1.b == rown2.a || rown1.b == rown2.b) return;
                if (Wielokant.rownoleglosc(pictureBox1.Width, pictureBox1.Height, rown1, rown2))
                {
                    Color kol = Color.FromArgb(r.Next(20, 235), r.Next(20, 235), r.Next(20, 235));
                    rown1.kolor = kol;
                    rown2.kolor = kol;
                    rown1.odpowkrawendz = rown2;
                    rown2.odpowkrawendz = rown1;
                    rown1.a.wielok.rownoleglekraw.Add(rown1);
                    rown1.a.wielok.rownoleglekraw.Add(rown2);
                 

                }
                rown1 = null;
                rown2 = null;
                resetujPiks();
               
                
            }
            else if(funkcja==FUNKCJA.USUNRELACJE)
            {
                int p1 = 0, p2 = 0;
                ostatniakrawendz = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                if (ostatniakrawendz == null) return;
                Krawendz dousun = null;
                foreach (var el in ostatniakrawendz.a.wielok.rownoleglekraw)
                {
                    if ((el.a == ostatniakrawendz.a && el.b == ostatniakrawendz.b) || (el.a == ostatniakrawendz.b && el.b == ostatniakrawendz.a))
                    {
                        dousun = el;
                        break;

                    }
                }

                if (dousun != null)
                {
                    dousun.a.wielok.rownoleglekraw.Remove(dousun.odpowkrawendz);
                    dousun.a.wielok.rownoleglekraw.Remove(dousun);

                }
                else
                {
                    foreach (var el in ostatniakrawendz.a.wielok.prostopadlekraw)
                    {
                        if ((el.a == ostatniakrawendz.a && el.b == ostatniakrawendz.b) || (el.a == ostatniakrawendz.b && el.b == ostatniakrawendz.a))
                        {
                            dousun = el;
                            break;

                        }
                    }

                    if (dousun != null)
                    {
                        dousun.a.wielok.prostopadlekraw.Remove(dousun.odpowkrawendz);
                        dousun.a.wielok.prostopadlekraw.Remove(dousun);

                    }
                }
                resetujPiks();
            }
            else if(funkcja==FUNKCJA.PROSTOPADLOSC)
            {
                int p1 = 0, p2 = 0;
                if (rown1 == null)
                {
                    rown1 = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                    if (rown1 == null)
                        return;
                    foreach (var el in rown1.a.wielok.rownoleglekraw)
                    {
                        if (el.a == rown1.a && el.b == rown1.b)
                        {
                            rown1 = null;
                            return;
                        }
                    }
                    foreach (var el in rown1.a.wielok.prostopadlekraw)
                    {
                        if (el.a == rown1.a && el.b == rown1.b)
                        {
                            rown1 = null;
                            return;
                        }
                    }

                }
                else
                {
                    rown2 = Wielokant.zwrocKrawendz(e.X, e.Y, tabkrawedzi, ref p1, ref p2);
                    if (rown2 == null) return;
                    if (rown1.a.wielok!=rown2.a.wielok)
                    {
                        rown2 = null;
                        return;
                    }
                    foreach (var el in rown1.a.wielok.rownoleglekraw)
                    {
                        if (el.a == rown2.a && el.b == rown2.b)
                        {
                            rown2 = null;
                            return;
                        }
                    }
                    foreach (var el in rown1.a.wielok.prostopadlekraw)
                    {
                        if (el.a == rown2.a && el.b == rown2.b)
                        {
                            rown2 = null;
                            return;
                        }
                    }
                }

                if (rown2 == null) return;
                if (rown1 == rown2) return;

                Wielokant.prostopadlosc(pictureBox1.Width, pictureBox1.Height, rown1, rown2);
                
                Color kol = Color.FromArgb(r.Next(20, 235), r.Next(20, 235), r.Next(20, 235));
                rown1.kolor = kol;
                rown2.kolor = kol;
                rown1.odpowkrawendz = rown2;
                rown2.odpowkrawendz = rown1;
                rown1.a.wielok.prostopadlekraw.Add(rown1);
                rown1.a.wielok.prostopadlekraw.Add(rown2);
                rown1 = null;
                rown2 = null;
                resetujPiks();
            }


        }

        private void clear()
        {
            bitmapa = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmapa;
            pictureBox1.Invalidate();
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            startruszania = false;
            clear();
            wielokaty.Clear();
            okregi.Clear();
            tabokregow = new Okrag[3 * pictureBox1.Width + 2, 3 * pictureBox1.Height + 2];
            tabwierzcholkow = new Wierzcholek[3 * pictureBox1.Width + 2, 3 * pictureBox1.Height + 2];
            tabkrawedzi = new Krawendz[3 * pictureBox1.Width + 2, 3 * pictureBox1.Height + 2];
            nowywielokat = true;
            ostatnipunkt = null;
            srodekokregu = null;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (czas.ElapsedMilliseconds>5)
            {
                
                narysujWszystko();
                czas.Reset();
                czas.Start();
            }
            if (srodekokregu != null)
            {
                int a = DodatkoweAlg.obliczPromien(srodekokregu.Value.Item1, srodekokregu.Value.Item2, e.X, e.Y);
                ostatniokrag.promien = a;
                //narysujWszystko();
            }
            if (zmianapromienia)
            {
                int a = DodatkoweAlg.obliczPromien(ostatniokrag.x, ostatniokrag.y, e.X, e.Y);
                ostatniokrag.promien = a;
                //narysujWszystko();
            }
            if (okragrozmiar)
            {
                ostatniokrag.x = e.X - dxdy.Item1;
                ostatniokrag.y = e.Y - dxdy.Item2;
                //narysujWszystko();
            }
            if (ostatnipunkt != null)
            {
                if (startruszania)
                {
                    ostatniwiel.wierzcholki.Add(new Wierzcholek(e.X, e.Y, ostatniwiel));
                    startruszania = false;
                }
                ostatniwiel.wierzcholki[ostatniwiel.wierzcholki.Count - 1].x = e.X;
                ostatniwiel.wierzcholki[ostatniwiel.wierzcholki.Count - 1].y = e.Y;
                //narysujWszystko();
            }
            if (przesuwaniewierzch)
            {
                if (rownolegleprzesuwanie.Item1 == null)
                {
                    ostatniwierzcholek.x = e.X;
                    ostatniwierzcholek.y = e.Y;
                }
                else
                {
                    ostatniwierzcholek.x = e.X;
                    ostatniwierzcholek.y = e.Y;


                }


            }
            if (przesuwaniekraw)
            {
                ostatniakrawendz.a.x = e.X - roznicaprzes.Item1;
                ostatniakrawendz.a.y = e.Y - roznicaprzes.Item2;
                ostatniakrawendz.b.x = e.X - roznicaprzes.Item3;
                ostatniakrawendz.b.y = e.Y - roznicaprzes.Item4;
                //narysujWszystko();

            }
            if (przesuwaniewielok)
            {
                foreach (var el in ostatniakrawendz.a.wielok.wierzcholki)
                {
                    el.x += e.X - ostatniepoloz.Item1;
                    el.y += e.Y - ostatniepoloz.Item2;

                }
                ostatniepoloz = (e.X, e.Y);
                //narysujWszystko();
            }
        }
        public void narysujWszystko()
        {
            clear();
            for (int i = 0; i < wielokaty.Count; i++)
            {

                wielokaty[i].Rysuj(bitmapa);
                foreach (var el in wielokaty[i].wierzcholki)
                {
                    el.Rysuj(bitmapa);
                }


            }
            foreach (var el in okregi)
            {
                el.Rysuj(bitmapa, pictureBox1.Width, pictureBox1.Height);
            }
            pictureBox1.Image = bitmapa;
            pictureBox1.Invalidate();
        }
        private void resetujPiks()
        {
            foreach (var el in wielokaty)
            {
                el.wyczyscTabKraw(tabkrawedzi, bitmapa);
                el.wyczyscTabWierzch(tabwierzcholkow, bitmapa);
                el.tablicaKrawedzi(tabkrawedzi, bitmapa);
                el.tablicaWierzcholkow(tabwierzcholkow, bitmapa);
            }
        }
        private void button_kolor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            kolor = colorDialog1.Color;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.TWORZWIEL;
        }
        private void tworz_okr_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.TWORZOKR;
        }

        private void przes_okr_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PRZESOKR;
        }

        private void zmien_prom_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.ZMIANAPROM;
        }

        private void usun_wierz_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.USUWWIERZ;
        }

        private void dod_wierz_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.DODWIERZ;
        }

        private void przes_wierz_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PRZESWIERZ;
        }

        private void przes_wielok_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PRZESWIEL;
        }

        private void Przes_kraw_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PRZESKRAW;
        }

        private void Kraw_rown_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.ROWNKRAW;
            rown1 = null;
            rown2 = null;
        }
        private void buttonusunrel_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.USUNRELACJE;
        }
        private void button_prost_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PROSTOPADLOSC;
            rown1 = null;
            rown2 = null;
        }
        private void zablokujPrzyciski(Button b)
        {
            buttonusunrel.Enabled = false;
            button_clear.Enabled = false;
            button_kolor.Enabled = false;
            button_prost.Enabled = false;
            dod_wierz.Enabled = false;
            Kraw_rown.Enabled = false;
            if(b!=Przes_kraw)Przes_kraw.Enabled = false;
            if(b!=przes_okr)przes_okr.Enabled = false;
            if(b!=przes_wielok)przes_wielok.Enabled = false;
            if(b!=przes_wierz)przes_wierz.Enabled = false;
            if(b!=zmien_prom)zmien_prom.Enabled = false;
            usun_wierz.Enabled = false;
            if(b!=tworz_okr) tworz_okr.Enabled= false;
            if(b!=tworz_wiel)tworz_wiel.Enabled = false;
        }
        private void odblokujPrzyciski()
        {
            buttonusunrel.Enabled = true;
            button_clear.Enabled = true;
            button_kolor.Enabled = true;
            button_prost.Enabled = true;
            dod_wierz.Enabled = true;
            Kraw_rown.Enabled = true;
            Przes_kraw.Enabled = true;
            przes_okr.Enabled = true;
            przes_wielok.Enabled = true;
            przes_wierz.Enabled = true;
            zmien_prom.Enabled = true;
            usun_wierz.Enabled = true;
            tworz_okr.Enabled = true;
            tworz_wiel.Enabled = true;
        }
    }
}
