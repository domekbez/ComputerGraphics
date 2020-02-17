using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_wielokaty
{
    public partial class Form1 : Form
    {
        Material przykladowyMaterial;
        Stopwatch czas;
        DateTime klatkiCzas;
        int klatki = 0;
        Color kolor;
        DirectBitmap bitmapa;
        DirectBitmap tekstura;
        float promienKuli = 1f, wysokoscStozka = 1f, wysokoscWalca = 2f, aSzescianu = 2f, bSzescianu = 2f, cSzescianu = 2f,
            promienWalca = 1f, promienStozka = 1f;
        int podzialStozka = 20,podzialPhi=20,podzialTheta=20,podzialWalca=50;
        List<Model> obiekty;
        Kamera kameraGlowna;
        List<Kamera> kamery;
        int ileKul = 0, ileWalcow = 0, ileProstopadloscianow = 0, ileStozkow = 0,ileKamer=0;
        Scena scena;
        Renderer rend;
        bool wcisnietaMysz = false;
        Kamera wybranaKamera;
        bool zbuffer = true, scanlinia = true, backculling = true, czySiatka = true;
        Wektor pozycjaMyszy;
        Model wybranyObiekt;
        Wektor swiatlo, kolorSwiatla;
        static public Color kolorWypelniania=Color.Black;
        bool czyKamera = false;


        public Form1()
        {
            InitializeComponent();

            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            czas = new Stopwatch();
            czas.Start();
            kolor = Color.Black;
            bitmapa = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = new DirectBitmap(pictureBox1.Width, pictureBox1.Height).Bitmap;
            timer1.Tick += new EventHandler(timer1_Tick);
            kameraGlowna = new Kamera(new Wektor(0, 0, 10), new Wektor(0, 0, 0));
            kameraGlowna.name = "Kamera Glowna";
            obiekty = new List<Model>();
            scena = new Scena(obiekty, kameraGlowna);
            rend = new Renderer(bitmapa.Width,bitmapa.Height,(float)Math.PI/2, 100f, 1f);
            obiekty = new List<Model>();
            swiatlo = new Wektor(400, 400, 1);
            kolorSwiatla = new Wektor(200, 200, 200);
            wybranaKamera = kameraGlowna;
            kamery = new List<Kamera>();
            kamery.Add(kameraGlowna);
            tabela2.HorizontalScroll.Maximum = 0;
            tabela2.AutoScroll = false;
            tabela2.VerticalScroll.Visible = false;
            tabela2.AutoScroll = true;
            przykladowyMaterial = new Material(0.3f,1f,0.3f, 1);
            klatkiCzas = DateTime.Now;
            numericUpDownSwiatloX.Maximum = pictureBox1.Width;
            numericUpDownSwiatloY.Maximum = pictureBox1.Height;

            timer1.Start();


        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            wybierzObiekt(e.X,e.Y);
        }
        private void narysujSwiatlo()
        {
            int x = (int)swiatlo.wek[0];
            int y = (int)swiatlo.wek[1];

            for (int i = -5; i <= 5; i++)
            {
                for (int j = -5; j <= 5; j++)
                    if (x + i > 0 && x + i < pictureBox1.Width - 1 && y + j > 0 && y + j < pictureBox1.Height - 1)
                    {
                        if (i == -5 || i == 5 || j == -5 || j == 5)
                            bitmapa.SetPixel(x + i, y + j, Color.Black);

                        else
                            bitmapa.SetPixel(x + i, y + j, Color.Yellow);
                    }
            }
            pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                scena.kamera.pozycja.wek[2] -= 0.5f;
            else
                scena.kamera.pozycja.wek[2] += 0.5f;

        }
        private void wybierzObiekt(int x, int y)
        {
            float z = float.MinValue;
            bool flaga = false;
            foreach (var el in scena.obiekty)
            {
                foreach (var el2 in el.siatka.trojkanty)
                {
                    if(el2.jestWSrodku(x,y))
                    {

                        float a = el2.wierzcholki[0].pozycjaPrzekszt.wek[2];
                        if(a > z)
                        {
                            flaga = true;
                            z = a;
                            wybranyObiekt = el;
                            listBox1.ClearSelected();
                            listBox1.SelectedItem = el.name;
                            ustawNumerics(el);
                            break;
                        }
                    }
                }
            }
            if(!flaga)
            wybranyObiekt = null;
        }

        private void ustawNumerics(Model el)
        {
            numericUpDownPozycjaX.Value = (decimal)el.pozycja.wek[0];
            numericUpDownPozycjaY.Value = (decimal)el.pozycja.wek[1];
            numericUpDownPozycjaZ.Value = (decimal)el.pozycja.wek[2];
            numericUpDownRotacjaX.Value = (decimal)(el.rotacja.wek[0]*(180/Math.PI));
            numericUpDownRotacjaY.Value = (decimal)(el.rotacja.wek[1]*(180/Math.PI));
            numericUpDownRotacjaZ.Value = (decimal)(el.rotacja.wek[2]*(180/Math.PI));
            numericUpDownSkalaX.Value = (decimal)el.skala.wek[0];
            numericUpDownSkalaY.Value = (decimal)el.skala.wek[1];
            numericUpDownSkalaZ.Value = (decimal)el.skala.wek[2];





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
            bitmapa = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            listBox1.Items.Clear();
            listBox1.Items.Add("Kamera Glowna");
            ileKul = ileProstopadloscianow = ileStozkow = ileWalcow = 0;

            pictureBox1.Image = bitmapa.Bitmap;
            pictureBox1.Invalidate();
            obiekty.Clear();
            scena.obiekty.Clear();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (wcisnietaMysz)
            {
                scena.kamera.pozycja.wek[0] += (e.X - pozycjaMyszy.wek[0]) / pictureBox1.Width;
                scena.kamera.pozycja.wek[1] += (e.Y - pozycjaMyszy.wek[1]) / pictureBox1.Height;
                
                narysujWszystko();
            }
        }
        public void narysujWszystko()
        {
            clear();
            bitmapa.resetujGlebokosc();
            if (rend != null)
                rend.renderuj(kameraGlowna.pozycja,przykladowyMaterial,bitmapa,swiatlo,kolorSwiatla,scena,tekstura,backculling,zbuffer,scanlinia,czySiatka);
            narysujSwiatlo();
            pictureBox1.Image = bitmapa.Bitmap;
            pictureBox1.Invalidate();
        }
        

        //Kula
        private void button1_Click_1(object sender, EventArgs e)
        {
            Kula kula = new Kula(promienKuli);
            Siatka s = kula.generujKule(podzialPhi, podzialTheta);
            Model m = new Model(s);
            m.skala = new Wektor(2f, 2f, 2f);
            m.kolor = Color.Brown;

            obiekty.Add(m);

            scena.obiekty.Add(m);
            string a = "Kula" + ileKul.ToString();
            m.name = a;
            listBox1.Items.Add(a);
            ileKul++;


            //narysujWszystko();
        }
        
        //Prostopadloscian
        private void button2_Click(object sender, EventArgs e)
        {
            Prostopadloscian prostopadloscian = new Prostopadloscian();
            Siatka s = prostopadloscian.generujProstopadloscian(aSzescianu,bSzescianu,cSzescianu);
            Model m = new Model(s);
           // m.rotacja = new Wektor(0.5f, 0.5f, 0f);
            m.skala = new Wektor(1f, 1f, 1f);
            m.kolor = Color.Red;

            obiekty.Add(m);

            scena.obiekty.Add(m);
            string a = "Prostopadloscian" + ileProstopadloscianow.ToString();
            m.name = a;
            listBox1.Items.Add(a);
            ileProstopadloscianow++;

            //narysujWszystko();
        }

       

        private void numericUpDownSkalaX_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                wybranyObiekt.skala.wek[0] = (float)((NumericUpDown)sender).Value;
                //narysujWszystko();
            }
        }

        private void numericUpDownSkalaY_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                wybranyObiekt.skala.wek[1] = (float)((NumericUpDown)sender).Value;
                //narysujWszystko();
            }
        }

        private void numericUpDownSkalaZ_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                wybranyObiekt.skala.wek[2] = (float)((NumericUpDown)sender).Value;
                //narysujWszystko();
            }
        }

        private void numericUpDownRotacjaX_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                float pom = (float)((NumericUpDown)sender).Value;
                wybranyObiekt.rotacja.wek[0] = (float)((pom * Math.PI) / 180);
            }
        }

        private void numericUpDownRotacjaY_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                float pom = (float)((NumericUpDown)sender).Value;
                wybranyObiekt.rotacja.wek[1] = (float)((pom * Math.PI) / 180);
            }

        }

        private void numericUpDownRotacjaZ_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                float pom = (float)((NumericUpDown)sender).Value;
                wybranyObiekt.rotacja.wek[2] = (float)((pom * Math.PI) / 180);
            }

        }

        private void numericUpDownPozycjaX_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                wybranyObiekt.pozycja.wek[0] = (float)((NumericUpDown)sender).Value;
                //narysujWszystko();
            }
        }

        private void numericUpDownPozycjaY_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                wybranyObiekt.pozycja.wek[1] = (float)((NumericUpDown)sender).Value;
                //narysujWszystko();
            }
        }

        private void numericUpDownPozycjaZ_ValueChanged(object sender, EventArgs e)
        {
            if (wybranyObiekt != null)
            {
                wybranyObiekt.pozycja.wek[2] = (float)((NumericUpDown)sender).Value;
                //narysujWszystko();
            }
        }

        private void butt_wczytajteksture_Click(object sender, EventArgs e)
        {
            Stream fileStream = null;
            var selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "Image files (*.jpg, *.jpeg,*.gif,*.tga, *.png) | *.jpg; *.jpeg; *.gif,*.tga; *.png";
            if (selectFileDialog.ShowDialog() == DialogResult.OK && (fileStream = selectFileDialog.OpenFile()) != null)
            {
                string fileName = selectFileDialog.FileName;
                Bitmap pom = new Bitmap(new Bitmap(selectFileDialog.FileName), bitmapa.Bitmap.Size);
                tekstura = utworzDirectMap(pom);

            }
            if (fileStream != null)
                fileStream.Close();

            //narysujWszystko();
        }

        private void buttStozek_Click(object sender, EventArgs e)
        {
            Stozek stozek = new Stozek();
            Siatka s = stozek.generujStozek(podzialStozka,wysokoscStozka,promienStozka);
            Model m = new Model(s);
            m.skala = new Wektor(2f, 2f, 2f);
            m.kolor = Color.Blue;
            
            obiekty.Add(m);
            
            scena.obiekty.Add(m);
            string a = "Stozek" + ileStozkow.ToString();
            m.name = a;
            listBox1.Items.Add(a);
            ileStozkow++;

            //narysujWszystko();
        }
        //a
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            aSzescianu = (float)((NumericUpDown)sender).Value;

        }

        private void numericUpDownWalecR_ValueChanged(object sender, EventArgs e)
        {
            promienWalca = (float)((NumericUpDown)sender).Value;

        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox l = (ListBox)sender;
            if (l.SelectedItems.Count == 0) return;
            string name = l.SelectedItem.ToString();
            foreach (var el in obiekty)
            {
                if (el.name.CompareTo(name) == 0)
                {
                    wybranyObiekt = el;
                    ustawNumerics(wybranyObiekt);
                    czyKamera = false;
                    return;
                }
            }
            foreach (var el in kamery)
            {
                if (el.name.CompareTo(name) == 0)
                {
                    scena.kamera = el;
                    wybranaKamera = el;
                    czyKamera = true;
                    return;
                }
            }
        }

        private void buttonUsunObiekt_Click(object sender, EventArgs e)
        {
            if(czyKamera)
            {
                if (wybranaKamera.name.CompareTo("Kamera Glowna")!=0)
                {
                    listBox1.Items.Remove(wybranaKamera.name);
                    kamery.Remove(wybranaKamera);
                    scena.kamera = kameraGlowna;
                    wybranaKamera = kameraGlowna;
                }
                return;
            }
            if (wybranyObiekt == null)
                return;
            
            if (wybranyObiekt.name.StartsWith("K"))
                ileKul--;
            if (wybranyObiekt.name.StartsWith("W"))
                ileWalcow--;
            if (wybranyObiekt.name.StartsWith("S"))
                ileStozkow--;
            if (wybranyObiekt.name.StartsWith("P"))
                ileProstopadloscianow--;

            listBox1.Items.Remove(wybranyObiekt.name);
            obiekty.Remove(wybranyObiekt);
            scena.obiekty.Remove(wybranyObiekt);
            wybranyObiekt = null;
            //narysujWszystko();
                
            
        }

        private void checkBoxScanLinia_CheckedChanged(object sender, EventArgs e)
        {
            scanlinia = !scanlinia;
            //narysujWszystko();
        }

        private void numericUpDownSwiatloX_ValueChanged(object sender, EventArgs e)
        {
            swiatlo.wek[0]= (float)((NumericUpDown)sender).Value;

        }

        private void numericUpDownSwiatloY_ValueChanged(object sender, EventArgs e)
        {
            swiatlo.wek[1] = (float)((NumericUpDown)sender).Value;

        }

        private void numericUpDownSwiatloZ_ValueChanged(object sender, EventArgs e)
        {
            swiatlo.wek[2] = (float)((NumericUpDown)sender).Value;

        }

        private void numericUpDownKatWidzenia_ValueChanged(object sender, EventArgs e)
        {
            float pom = (float)((NumericUpDown)sender).Value;
            rend.fov = (float)((pom * Math.PI) / 180);

        }

        private void numericUpDownPrzedniaPlaszczyzna_ValueChanged(object sender, EventArgs e)
        {
            rend.blizszaSciana = (float)((NumericUpDown)sender).Value;

        }

        private void numericUpDownTylnaPlaszczyzna_ValueChanged(object sender, EventArgs e)
        {
            rend.dalszaSciana= (float)((NumericUpDown)sender).Value;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            numericUpDownSwiatloX.Maximum = pictureBox1.Width;
            numericUpDownSwiatloY.Maximum = pictureBox1.Height;
            if (rend != null)
            {
                rend.height = pictureBox1.Height;
                rend.width = pictureBox1.Width;
                rend.aspekt = rend.width / rend.height;
            }

        }

        private void buttonZapiszScene_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();


            Stream stream = null;
            var selectFileDialog = new SaveFileDialog();
            selectFileDialog.Filter = "Text files (*.txt) | *.txt";
            if (selectFileDialog.ShowDialog() == DialogResult.OK && (stream = selectFileDialog.OpenFile()) != null)
            {
                Serializacja serializacja = new Serializacja(rend, scena, obiekty, kamery);

                formatter.Serialize(stream, serializacja);

            }
            if (stream != null)
                stream.Close();
        }

        private void buttonWczytajScene_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();


            Stream stream = null;
            var selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "Text files (*.txt) | *.txt";
            if (selectFileDialog.ShowDialog() == DialogResult.OK && (stream = selectFileDialog.OpenFile()) != null)
            {
                try
                {
                    Serializacja serializacja = (Serializacja)formatter.Deserialize(stream);
                    scena = serializacja.scena;
                    rend = serializacja.renderer;
                    obiekty = serializacja.obiekty;
                    kamery = serializacja.kamery;
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Kamera Glowna");
                    foreach (var el in obiekty)
                    {
                        listBox1.Items.Add(el.name);
                    }
                    foreach (var el in kamery)
                    {
                        if (el.name.CompareTo("Kamera Glowna") != 0)
                            listBox1.Items.Add(el.name);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            if (stream != null)
                stream.Close();

            //Stream stream = new FileStream(@"Scena.txt", FileMode.Open, FileAccess.Read);
            
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void checkBoxSiatka_CheckedChanged(object sender, EventArgs e)
        {
            czySiatka = !czySiatka;
        }

        private void buttonKameraObiekt_Click(object sender, EventArgs e)
        {
            if (wybranyObiekt == null) return;
            Kamera kamera = new Kamera(new Wektor(0, 0, 10), wybranyObiekt.pozycja);
            scena.kamera = kamera;
            string a = "kamera" + ileKamer + "-" + wybranyObiekt.name;
            kamera.name = a;
            listBox1.Items.Add(a);
            ileKamer++;
            kamery.Add(kamera);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            narysujWszystko();
            klatki++;
            if ((DateTime.Now -klatkiCzas).TotalMilliseconds>1000)
            {
                this.Text ="Zadanie 4  - "+ klatki + " klatek";
                klatki = 0;
                klatkiCzas = DateTime.Now;

            }
        }

        private void checkBoxBackfaceCulling_CheckedChanged(object sender, EventArgs e)
        {
            backculling = !backculling;
            //narysujWszystko();
        }

        private void checkBoxZBuffer_CheckedChanged(object sender, EventArgs e)
        {
            zbuffer = !zbuffer;
            //narysujWszystko();
        }

        private void numericUpDownPromienStozka_ValueChanged(object sender, EventArgs e)
        {
            promienStozka = (float)((NumericUpDown)sender).Value;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!wcisnietaMysz)
            {
                pozycjaMyszy = new Wektor(e.X, e.Y, 0);
            }
            wcisnietaMysz = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            wcisnietaMysz = false;

        }

        //b
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            bSzescianu = (float)((NumericUpDown)sender).Value;

        }
        //c
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            cSzescianu = (float)((NumericUpDown)sender).Value;

        }

        private void buttWalec_Click(object sender, EventArgs e)
        {
            Walec walec = new Walec();
            Siatka s = walec.generujWalec(podzialWalca,wysokoscWalca,promienWalca);

            Model m = new Model(s);
            m.skala = new Wektor(2, 2, 2);
            m.kolor = Color.Green;
            
            obiekty.Add(m);
            scena.obiekty.Add(m);
            //scena.kamera = new Kamera(new Wektor(0, 0, 10), m.pozycja);
            string a = "Walec" + ileWalcow.ToString();
            m.name = a;
            listBox1.Items.Add(a);
            ileWalcow++;

            //narysujWszystko();
        }
        //theta
        private void numericUpDownKulaPhi_ValueChanged(object sender, EventArgs e)
        {
            podzialTheta = (int)((NumericUpDown)sender).Value;

        }

        private void numericUpDownWysokoscWalca_ValueChanged(object sender, EventArgs e)
        {
            wysokoscWalca=(float)((NumericUpDown)sender).Value;
        }

        //podzialWalca
        private void numericUpDownPromienWalca_ValueChanged(object sender, EventArgs e)
        {
            podzialWalca= (int)((NumericUpDown)sender).Value;

        }
        

        private void numericUpDownWysokoscStozka_ValueChanged(object sender, EventArgs e)
        {
            wysokoscStozka= (int)((NumericUpDown)sender).Value;

        }

        private void numericUpDownPodzialStozka_ValueChanged(object sender, EventArgs e)
        {
            podzialStozka= (int)((NumericUpDown)sender).Value;

        }

        private void numericUpDownKulaPodzialPhi_ValueChanged(object sender, EventArgs e)
        {
            podzialPhi = (int)((NumericUpDown)sender).Value;

        }

        private void numericUPDownKulaPromien_ValueChanged(object sender, EventArgs e)
        {
            promienKuli= (float)((NumericUpDown)sender).Value;

        }
    }
}
