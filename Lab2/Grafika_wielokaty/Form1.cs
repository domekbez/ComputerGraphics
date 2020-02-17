using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_wielokaty
{
    public enum FUNKCJA
    {
        NIC,TWORZWIEL,PRZESWIERZ,PRZESWIEL,WYPELNIENIE,ANIMACJA,WYPUKLE,TEKSTURA,WCZYTBUMP,USUNBUMP,WYCZYSC,KOLORSWIATLA,KOLORWYPELNIENIE,
        SWIATLO
    }
    public partial class Form1 : Form
    {
        (double,double,double) swiatlo = (1,1,1);
        int predkosc = 1;
        DirectBitmap mapa = null;
        FUNKCJA funkcja;
        Stopwatch czas;
        (int, int, int) wektorSwiatla = (200, 200, 30);
        Color kolor;
        DirectBitmap bitmapa;
        DirectBitmap tekstura;
        List<Wielokant> wielokaty;
        List<Wielokant> wielokatyWypukle;
        List<Wielokant> wielokatyWspolne;
        bool interpolacja = false;
        (int, int)? ostatnipunkt;
        Wierzcholek[,] tabwierzcholkow;
        Krawendz[,] tabkrawedzi;
        (int, int) ostatniepoloz;
        bool startruszania = true;
        bool nowywielokat = true;
        bool przesuwaniewierzch = false;
        bool przesuwaniewielok = false;
        Wielokant ostatniwiel;
        Wierzcholek ostatniwierzcholek;
        Krawendz ostatniakrawendz;
        static public Color kolorWypelniania=Color.Black;

        public Form1()
        {
            InitializeComponent();
            czas = new Stopwatch();
            czas.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
            funkcja = FUNKCJA.TWORZWIEL;
            tabwierzcholkow = new Wierzcholek[4*pictureBox1.Width + 2, 4*pictureBox1.Height + 2];
            tabkrawedzi = new Krawendz[4*pictureBox1.Width + 2, 4*pictureBox1.Height + 2];
            ostatniwiel = new Wielokant();
            kolor = Color.Black;
            ostatnipunkt = null;
            wielokaty = new List<Wielokant>();
            wielokatyWypukle = new List<Wielokant>();
            wielokatyWspolne = new List<Wielokant>();
            tekstura = null;
            wektorSwiatla = (20, 20, 30);
            bitmapa = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = new DirectBitmap(pictureBox1.Width, pictureBox1.Height).Bitmap;

            

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
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
                pictureBox1.Image = bitmapa.Bitmap;
                pictureBox1.Invalidate();
            }
            else if (funkcja == FUNKCJA.PRZESWIERZ)
            {
                if (!przesuwaniewierzch)
                {
                    
                    ostatniwierzcholek = Wielokant.zwrocWierzcholek(e.X, e.Y, tabwierzcholkow);
                    if (ostatniwierzcholek == null) return;
                    
                    if (ostatniwierzcholek != null)
                    {
                        przesuwaniewierzch = true;
                        zablokujPrzyciski(przes_wierz);
                    }
                    else return;

                }
                else
                {
                    ostatniwierzcholek.x = e.X;
                    ostatniwierzcholek.y = e.Y;
                    przesuwaniewierzch = false;
                    odblokujPrzyciski();
                    resetujPiks();
                }
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
            else if(funkcja==FUNKCJA.SWIATLO)
            {
                wektorSwiatla.Item1 = e.X;
                wektorSwiatla.Item2 = e.Y;
                narysujWszystko();
            }
        }
        private void narysujSwiatlo()
        {
            int x = wektorSwiatla.Item1;
            int y = wektorSwiatla.Item2;

            for(int i=-5;i<=5;i++)
            {
                for(int j=-5;j<=5;j++)
                if(x+i>0&&x+i<pictureBox1.Width-1&& y + j > 0 && y + j < pictureBox1.Height - 1)
                    {
                        if(i==-5||i==5||j==-5||j==5)
                            bitmapa.SetPixel(x + i, y + j, Color.Black);

                        else
                            bitmapa.SetPixel(x + i, y + j, Color.Yellow);
                    }
            }
            pictureBox1.Invalidate();
        }

        private DirectBitmap utworzDirectMap(Bitmap b)
        {
            DirectBitmap db = new DirectBitmap(b.Width, b.Height);
            for(int i=0;i<db.Width;i++)
            {
                for(int j=0;j<db.Height;j++)
                {
                    db.SetPixel(i, j, b.GetPixel(i, j));
                }
            }
            return db;
        }

        private void clear()
        {
          
            bitmapa.Dispose();
            bitmapa = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Invalidate();
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.WYCZYSC;
            startruszania = false;
            bitmapa = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmapa.Bitmap;
            pictureBox1.Invalidate();
            wielokaty.Clear();
            wielokatyWypukle.Clear();
            wielokatyWspolne.Clear();
            tabwierzcholkow = new Wierzcholek[4 * pictureBox1.Width + 2, 4 * pictureBox1.Height + 2];
            tabkrawedzi = new Krawendz[4 * pictureBox1.Width + 2, 4 * pictureBox1.Height + 2];
            nowywielokat = true;
            ostatnipunkt = null;
            narysujSwiatlo();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (czas.ElapsedMilliseconds > 5)
            {
                if(funkcja==FUNKCJA.TWORZWIEL||funkcja==FUNKCJA.PRZESWIEL||funkcja==FUNKCJA.PRZESWIERZ)
                    narysujWszystko();
                czas.Reset();
                czas.Start();
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
            }
            if (przesuwaniewierzch)
            {
                    ostatniwierzcholek.x = e.X;
                    ostatniwierzcholek.y = e.Y;

            }
            if (przesuwaniewielok)
            {
                foreach (var el in ostatniakrawendz.a.wielok.wierzcholki)
                {
                    el.x += e.X - ostatniepoloz.Item1;
                    el.y += e.Y - ostatniepoloz.Item2;
                }
                ostatniepoloz = (e.X, e.Y);
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
                //ScanLinia.wypelnijWielokat(wielokaty[i], bitmapa, tekstura, swiatlo, wektorSwiatla, interpolacja, mapa);


            }
            for (int i = 0; i < wielokatyWypukle.Count; i++)
            {
                wielokatyWypukle[i].Rysuj(bitmapa);
                foreach (var el in wielokatyWypukle[i].wierzcholki)
                {

                    el.Rysuj(bitmapa);
                }
                ScanLinia.wypelnijWielokat(wielokatyWypukle[i], bitmapa, tekstura, swiatlo, wektorSwiatla, true, mapa);
            }
            wielokatyWspolne.Clear();
            foreach (var el in wielokatyWypukle)
            {
                foreach (var el2 in wielokaty)
                {
                    Wielokant w2 = new Wielokant();
                    w2 = SutherlandHodgman.suthHodg(el2, el);
                    wielokatyWspolne.Add(w2);
                }
            }


            foreach (var el in wielokatyWspolne)
            {
                ScanLinia.wypelnijWielokat(el, bitmapa, tekstura, swiatlo, wektorSwiatla, interpolacja, mapa);
            }
            narysujSwiatlo();
            pictureBox1.Image = bitmapa.Bitmap;
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
        private void przes_wierz_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PRZESWIERZ;
        }
        private void przes_wielok_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.PRZESWIEL;
        }
        private void zablokujPrzyciski(Button b)
        {
            button_clear.Enabled = false;
            butt_animacja.Enabled = false;
            butt_generujwypukle.Enabled = false;
            butt_swiatlo.Enabled = false;
            butt_tkst.Enabled = false;
            butt_predkosc.Enabled = false;
            butt_usunBumpMap.Enabled = false;
            butt_WczytajBitmap.Enabled= false;
            tworz_wiel.Enabled = false;
            przes_wierz.Enabled = false;
            przes_wielok.Enabled = false;
            butt_kolorswiatla.Enabled = false;
            textBox2.Enabled = false;
            butt_kolorWypelniania.Enabled = false;
            b.Enabled = true;
            b.Select();

        }
        private void odblokujPrzyciski()
        {
            button_clear.Enabled = true;
            butt_animacja.Enabled = true;
            butt_generujwypukle.Enabled = true;
            butt_swiatlo.Enabled = true;
            butt_tkst.Enabled = true;
            butt_kolorWypelniania.Enabled = true;
            butt_predkosc.Enabled = true;
            butt_usunBumpMap.Enabled = true;
            butt_WczytajBitmap.Enabled = true;
            tworz_wiel.Enabled = true;
            przes_wierz.Enabled = true;
            przes_wielok.Enabled = true;
            butt_kolorswiatla.Enabled = true;
            textBox2.Enabled = true;
            
        }



        private void butt_generujwypukle_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.WYPUKLE;
            if (wielokatyWypukle.Count < 5)
            {
                Wielokant w = GenerowanieWiel.generujWypukly(5, pictureBox1.Width - 350, 10, pictureBox1.Width - 50, pictureBox1.Height / 2 - 10);
                Wielokant w2 = GenerowanieWiel.generujWypukly(10, pictureBox1.Width - 350, pictureBox1.Height / 2 + 10, pictureBox1.Width - 50, pictureBox1.Height - 10);


                wielokatyWypukle.Add(w);
                wielokatyWypukle.Add(w2);
                narysujWszystko();
            }

        }

        private void butt_predkosc_ValueChanged(object sender, EventArgs e)
        {
            predkosc = ((TrackBar)sender).Value+1;
        }
        private void przesunWypukle()
        {
            List<Wielokant> dousun = new List<Wielokant>();
            foreach (var el in wielokatyWypukle)
            {
                if (el.wierzcholki[0].x < 0)
                    dousun.Add(el);
                foreach (var el2 in el.wierzcholki)
                {
                    el2.x -= predkosc;
                }
            }
            foreach (var el in dousun)
            {

                wielokatyWypukle.Remove(el);
            }
            narysujWszystko();
           
            
        }
        private void butt_tkst_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.TEKSTURA;
            Stream fileStream = null;
            var selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "Image files (*.jpg, *.jpeg,*.gif,*.tga, *.png) | *.jpg; *.jpeg; *.gif,*.tga; *.png";
            if (selectFileDialog.ShowDialog() == DialogResult.OK && (fileStream = selectFileDialog.OpenFile()) != null)
            {
                string fileName = selectFileDialog.FileName;
                Bitmap pom = new Bitmap(new Bitmap(selectFileDialog.FileName), bitmapa.Bitmap.Size);
                tekstura=utworzDirectMap(pom);
                label4.BackColor = SystemColors.Control;
                
                label4.Text = "Tekstura";
            }
            if(fileStream!=null)
                fileStream.Close();
         
            narysujWszystko();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int a;
            bool b = Int32.TryParse(((TextBox)sender).Text, out a);
            if (b && a > 0 && a<=1000)
                wektorSwiatla.Item3 = a;
            else if (((TextBox)sender).Text == "")
            {
                return;
            }
            else if (a > 1000)
            {
                wektorSwiatla.Item3 = 1000;
                ((TextBox)sender).Text = "1000";
            }
            else
                ((TextBox)sender).Text = wektorSwiatla.Item3.ToString();
            narysujWszystko();
        }

        private void butt_swiatlo_Click(object sender, EventArgs e)
        {

            funkcja = FUNKCJA.SWIATLO;
            narysujWszystko();

        }

        private void butt_WczytajBitmap_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.WCZYTBUMP;
            Stream fileStream = null;
            var selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "Image files (*.jpg, *.jpeg,*.gif,*.tga, *.png) | *.jpg; *.jpeg; *.gif,*.tga; *.png";

            if (selectFileDialog.ShowDialog() == DialogResult.OK && (fileStream = selectFileDialog.OpenFile()) != null)
            {
                string fileName = selectFileDialog.FileName;
                Bitmap pom = new Bitmap(new Bitmap(selectFileDialog.FileName), bitmapa.Bitmap.Size);
                mapa=utworzDirectMap(pom);
            }
            if(fileStream!=null)
                fileStream.Close();
            narysujWszystko();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(wielokatyWypukle.Count>0)
                przesunWypukle();
        }

        private void butt_animacja_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.ANIMACJA;
            if(butt_animacja.Text=="Wystartuj animację")
            {
                butt_animacja.Text = "Zatrzymaj animację";
                timer1.Start();

            }
            else
            {
                butt_animacja.Text = "Wystartuj animację";

                timer1.Stop();
            }
        }

        private void butt_usunBumpMap_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.USUNBUMP;
            mapa = null;
            narysujWszystko();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (bitmapa != null)
            {
                if(tekstura!=null)
                {
                    Bitmap pom = new Bitmap(tekstura.Bitmap, pictureBox1.Size);
                    tekstura = utworzDirectMap(pom);
                }
                if (mapa != null)
                {
                    Bitmap pom = new Bitmap(mapa.Bitmap, pictureBox1.Size);
                    mapa = utworzDirectMap(pom);
                }
                narysujWszystko();
            }
        }

        private void butt_kolorswiatla_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.KOLORSWIATLA;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                swiatlo.Item1 = colorDialog1.Color.R/255.0;
                swiatlo.Item2 = colorDialog1.Color.G / 255.0;
                swiatlo.Item3 = colorDialog1.Color.B / 255.0;
                label1.BackColor = colorDialog1.Color;
                narysujWszystko();
            }
            

        }

        private void butt_kolorWypelniania_Click(object sender, EventArgs e)
        {
            funkcja = FUNKCJA.KOLORWYPELNIENIE;
            if(tekstura==null)
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                kolorWypelniania = colorDialog1.Color;
                label4.BackColor = colorDialog1.Color;
                narysujWszystko();
            }
        }
    }
}
