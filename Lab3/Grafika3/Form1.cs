using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika3
{
    public partial class Form1 : Form
    {
        Bitmap bitmapa;
        Bitmap bitmapa2;
        int kolR;
        int kolB;
        int kolG;
        int kolorow;
        bool obraz = false;


        public Form1()
        {

            InitializeComponent();
            bitmapa = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bitmapa2 = new Bitmap(pictureBox2.Width,pictureBox2.Height);
            kolR = kolG = kolB = kolorow = 7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream fileStream = null;
            var selectFileDialog = new OpenFileDialog();
            selectFileDialog.Filter = "Image files (*.jpg, *.jpeg,*.gif,*.tga, *.png) | *.jpg; *.jpeg; *.gif,*.tga; *.png";
            if (selectFileDialog.ShowDialog() == DialogResult.OK && (fileStream = selectFileDialog.OpenFile()) != null)
            {
                string fileName = selectFileDialog.FileName;
                bitmapa = new Bitmap(new Bitmap(selectFileDialog.FileName), pictureBox1.Size);
                obraz = true;
            }
            if (fileStream != null)
                fileStream.Close();
            pictureBox1.Image = bitmapa;
            pictureBox1.Invalidate();
            bitmapa2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!obraz) return;

            if(radioButton1.Checked)
                AlgorytmyRedukcji.rozpraszanieSrednie(kolR, kolG, kolB, bitmapa, bitmapa2);
            else if(radioButton2.Checked)
                AlgorytmyRedukcji.uporzadkowaneDrzenie(kolR, kolG, kolB, bitmapa, bitmapa2,true);
            else if (radioButton3.Checked)
                AlgorytmyRedukcji.uporzadkowaneDrzenie(kolR, kolG, kolB, bitmapa, bitmapa2,false);
            else if (radioButton4.Checked)
                AlgorytmyRedukcji.propagacjaBledu(kolR, kolG, kolB, bitmapa, bitmapa2);
            else if (radioButton5.Checked)
                AlgorytmyRedukcji.algPopularnosciowy(kolorow, bitmapa, bitmapa2);



            pictureBox1.Image = bitmapa;
            pictureBox1.Invalidate();
            pictureBox2.Image = bitmapa2;
            pictureBox2.Invalidate();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            kolR = (int)((NumericUpDown)sender).Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            kolG = (int)((NumericUpDown)sender).Value;

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            kolB = (int)((NumericUpDown)sender).Value;

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            kolorow = (int)((NumericUpDown)sender).Value;

        }
    }
}
