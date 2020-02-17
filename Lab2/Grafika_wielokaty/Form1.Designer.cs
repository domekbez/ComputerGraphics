namespace Grafika_wielokaty
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabela = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabela2 = new System.Windows.Forms.TableLayoutPanel();
            this.tworz_wiel = new System.Windows.Forms.Button();
            this.przes_wierz = new System.Windows.Forms.Button();
            this.przes_wielok = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.butt_generujwypukle = new System.Windows.Forms.Button();
            this.butt_tkst = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.butt_swiatlo = new System.Windows.Forms.Button();
            this.butt_WczytajBitmap = new System.Windows.Forms.Button();
            this.butt_animacja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butt_usunBumpMap = new System.Windows.Forms.Button();
            this.butt_predkosc = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.butt_kolorswiatla = new System.Windows.Forms.Button();
            this.butt_kolorWypelniania = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabela2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butt_predkosc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabela
            // 
            this.tabela.ColumnCount = 2;
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tabela.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabela.Controls.Add(this.pictureBox1, 0, 0);
            this.tabela.Controls.Add(this.tabela2, 1, 0);
            this.tabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela.Location = new System.Drawing.Point(0, 0);
            this.tabela.Name = "tabela";
            this.tabela.RowCount = 1;
            this.tabela.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabela.Size = new System.Drawing.Size(1900, 953);
            this.tabela.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1514, 947);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // tabela2
            // 
            this.tabela2.ColumnCount = 2;
            this.tabela2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabela2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabela2.Controls.Add(this.tworz_wiel, 0, 0);
            this.tabela2.Controls.Add(this.przes_wierz, 0, 1);
            this.tabela2.Controls.Add(this.przes_wielok, 1, 0);
            this.tabela2.Controls.Add(this.button_clear, 1, 8);
            this.tabela2.Controls.Add(this.butt_generujwypukle, 0, 2);
            this.tabela2.Controls.Add(this.butt_tkst, 1, 7);
            this.tabela2.Controls.Add(this.textBox2, 1, 3);
            this.tabela2.Controls.Add(this.butt_swiatlo, 1, 2);
            this.tabela2.Controls.Add(this.butt_WczytajBitmap, 0, 7);
            this.tabela2.Controls.Add(this.butt_animacja, 1, 1);
            this.tabela2.Controls.Add(this.label1, 0, 6);
            this.tabela2.Controls.Add(this.label2, 1, 4);
            this.tabela2.Controls.Add(this.butt_usunBumpMap, 0, 8);
            this.tabela2.Controls.Add(this.butt_predkosc, 0, 3);
            this.tabela2.Controls.Add(this.label3, 0, 4);
            this.tabela2.Controls.Add(this.butt_kolorswiatla, 0, 5);
            this.tabela2.Controls.Add(this.butt_kolorWypelniania, 1, 5);
            this.tabela2.Controls.Add(this.label4, 1, 6);
            this.tabela2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela2.Location = new System.Drawing.Point(1523, 3);
            this.tabela2.Name = "tabela2";
            this.tabela2.RowCount = 9;
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66599F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66599F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66599F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.330332F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.330332F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67118F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67019F));
            this.tabela2.Size = new System.Drawing.Size(374, 947);
            this.tabela2.TabIndex = 2;
            // 
            // tworz_wiel
            // 
            this.tworz_wiel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tworz_wiel.Location = new System.Drawing.Point(10, 10);
            this.tworz_wiel.Margin = new System.Windows.Forms.Padding(10);
            this.tworz_wiel.Name = "tworz_wiel";
            this.tworz_wiel.Size = new System.Drawing.Size(167, 124);
            this.tworz_wiel.TabIndex = 0;
            this.tworz_wiel.Text = "Tworzenie wielokąta";
            this.tworz_wiel.UseVisualStyleBackColor = true;
            this.tworz_wiel.Click += new System.EventHandler(this.button1_Click);
            // 
            // przes_wierz
            // 
            this.przes_wierz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.przes_wierz.Location = new System.Drawing.Point(10, 154);
            this.przes_wierz.Margin = new System.Windows.Forms.Padding(10);
            this.przes_wierz.Name = "przes_wierz";
            this.przes_wierz.Size = new System.Drawing.Size(167, 124);
            this.przes_wierz.TabIndex = 8;
            this.przes_wierz.Text = "Przesuwanie wierzchołka";
            this.przes_wierz.UseVisualStyleBackColor = true;
            this.przes_wierz.Click += new System.EventHandler(this.przes_wierz_Click);
            // 
            // przes_wielok
            // 
            this.przes_wielok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.przes_wielok.Location = new System.Drawing.Point(197, 10);
            this.przes_wielok.Margin = new System.Windows.Forms.Padding(10);
            this.przes_wielok.Name = "przes_wielok";
            this.przes_wielok.Size = new System.Drawing.Size(167, 124);
            this.przes_wielok.TabIndex = 9;
            this.przes_wielok.Text = "Przesuwanie wielokąta";
            this.przes_wielok.UseVisualStyleBackColor = true;
            this.przes_wielok.Click += new System.EventHandler(this.przes_wielok_Click);
            // 
            // button_clear
            // 
            this.button_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_clear.Location = new System.Drawing.Point(197, 810);
            this.button_clear.Margin = new System.Windows.Forms.Padding(10);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(167, 127);
            this.button_clear.TabIndex = 1;
            this.button_clear.Text = "Wyczyść";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // butt_generujwypukle
            // 
            this.butt_generujwypukle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_generujwypukle.Location = new System.Drawing.Point(10, 298);
            this.butt_generujwypukle.Margin = new System.Windows.Forms.Padding(10);
            this.butt_generujwypukle.Name = "butt_generujwypukle";
            this.butt_generujwypukle.Size = new System.Drawing.Size(167, 124);
            this.butt_generujwypukle.TabIndex = 11;
            this.butt_generujwypukle.Text = "Generuj Wielokąty";
            this.butt_generujwypukle.UseVisualStyleBackColor = true;
            this.butt_generujwypukle.Click += new System.EventHandler(this.butt_generujwypukle_Click);
            // 
            // butt_tkst
            // 
            this.butt_tkst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_tkst.Location = new System.Drawing.Point(197, 666);
            this.butt_tkst.Margin = new System.Windows.Forms.Padding(10);
            this.butt_tkst.Name = "butt_tkst";
            this.butt_tkst.Size = new System.Drawing.Size(167, 124);
            this.butt_tkst.TabIndex = 14;
            this.butt_tkst.Text = "Wczytaj teksturę";
            this.butt_tkst.UseVisualStyleBackColor = true;
            this.butt_tkst.Click += new System.EventHandler(this.butt_tkst_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Location = new System.Drawing.Point(230, 457);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "30";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // butt_swiatlo
            // 
            this.butt_swiatlo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_swiatlo.Location = new System.Drawing.Point(197, 298);
            this.butt_swiatlo.Margin = new System.Windows.Forms.Padding(10);
            this.butt_swiatlo.Name = "butt_swiatlo";
            this.butt_swiatlo.Size = new System.Drawing.Size(167, 124);
            this.butt_swiatlo.TabIndex = 17;
            this.butt_swiatlo.Text = "Ustaw Światlo";
            this.butt_swiatlo.UseVisualStyleBackColor = true;
            this.butt_swiatlo.Click += new System.EventHandler(this.butt_swiatlo_Click);
            // 
            // butt_WczytajBitmap
            // 
            this.butt_WczytajBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_WczytajBitmap.Location = new System.Drawing.Point(10, 666);
            this.butt_WczytajBitmap.Margin = new System.Windows.Forms.Padding(10);
            this.butt_WczytajBitmap.Name = "butt_WczytajBitmap";
            this.butt_WczytajBitmap.Size = new System.Drawing.Size(167, 124);
            this.butt_WczytajBitmap.TabIndex = 19;
            this.butt_WczytajBitmap.Text = "Wczytaj bumpmapę";
            this.butt_WczytajBitmap.UseVisualStyleBackColor = true;
            this.butt_WczytajBitmap.Click += new System.EventHandler(this.butt_WczytajBitmap_Click);
            // 
            // butt_animacja
            // 
            this.butt_animacja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_animacja.Location = new System.Drawing.Point(197, 154);
            this.butt_animacja.Margin = new System.Windows.Forms.Padding(10);
            this.butt_animacja.Name = "butt_animacja";
            this.butt_animacja.Size = new System.Drawing.Size(167, 124);
            this.butt_animacja.TabIndex = 20;
            this.butt_animacja.Text = "Wystartuj animację";
            this.butt_animacja.UseVisualStyleBackColor = true;
            this.butt_animacja.Click += new System.EventHandler(this.butt_animacja_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 626);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.MaximumSize = new System.Drawing.Size(100, 20);
            this.label1.MinimumSize = new System.Drawing.Size(100, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 21;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 504);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Wysokość światła (z)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butt_usunBumpMap
            // 
            this.butt_usunBumpMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_usunBumpMap.Location = new System.Drawing.Point(10, 810);
            this.butt_usunBumpMap.Margin = new System.Windows.Forms.Padding(10);
            this.butt_usunBumpMap.Name = "butt_usunBumpMap";
            this.butt_usunBumpMap.Size = new System.Drawing.Size(167, 127);
            this.butt_usunBumpMap.TabIndex = 23;
            this.butt_usunBumpMap.Text = "Usuń bumpmapę";
            this.butt_usunBumpMap.UseVisualStyleBackColor = true;
            this.butt_usunBumpMap.Click += new System.EventHandler(this.butt_usunBumpMap_Click);
            // 
            // butt_predkosc
            // 
            this.butt_predkosc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butt_predkosc.Location = new System.Drawing.Point(41, 445);
            this.butt_predkosc.Name = "butt_predkosc";
            this.butt_predkosc.Size = new System.Drawing.Size(104, 56);
            this.butt_predkosc.TabIndex = 12;
            this.butt_predkosc.ValueChanged += new System.EventHandler(this.butt_predkosc_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Szybkość animacji";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butt_kolorswiatla
            // 
            this.butt_kolorswiatla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_kolorswiatla.Location = new System.Drawing.Point(10, 576);
            this.butt_kolorswiatla.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.butt_kolorswiatla.Name = "butt_kolorswiatla";
            this.butt_kolorswiatla.Size = new System.Drawing.Size(167, 40);
            this.butt_kolorswiatla.TabIndex = 25;
            this.butt_kolorswiatla.Text = "Kolor światła";
            this.butt_kolorswiatla.UseVisualStyleBackColor = true;
            this.butt_kolorswiatla.Click += new System.EventHandler(this.butt_kolorswiatla_Click);
            // 
            // butt_kolorWypelniania
            // 
            this.butt_kolorWypelniania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butt_kolorWypelniania.Location = new System.Drawing.Point(197, 576);
            this.butt_kolorWypelniania.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.butt_kolorWypelniania.Name = "butt_kolorWypelniania";
            this.butt_kolorWypelniania.Size = new System.Drawing.Size(167, 40);
            this.butt_kolorWypelniania.TabIndex = 26;
            this.butt_kolorWypelniania.Text = "Kolor";
            this.butt_kolorWypelniania.UseVisualStyleBackColor = true;
            this.butt_kolorWypelniania.Click += new System.EventHandler(this.butt_kolorWypelniania_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(230, 626);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.MaximumSize = new System.Drawing.Size(100, 20);
            this.label4.MinimumSize = new System.Drawing.Size(100, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 27;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 953);
            this.Controls.Add(this.tabela);
            this.MinimumSize = new System.Drawing.Size(1918, 1000);
            this.Name = "Form1";
            this.Text = "Zadanie 2";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabela2.ResumeLayout(false);
            this.tabela2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butt_predkosc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabela;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tabela2;
        private System.Windows.Forms.Button tworz_wiel;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button przes_wierz;
        private System.Windows.Forms.Button przes_wielok;
        private System.Windows.Forms.Button butt_generujwypukle;
        private System.Windows.Forms.TrackBar butt_predkosc;
        private System.Windows.Forms.Button butt_tkst;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button butt_swiatlo;
        private System.Windows.Forms.Button butt_WczytajBitmap;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button butt_animacja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butt_usunBumpMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butt_kolorswiatla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butt_kolorWypelniania;
        private System.Windows.Forms.Label label4;
    }
}

