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
            this.tabela = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabela2 = new System.Windows.Forms.TableLayoutPanel();
            this.tworz_wiel = new System.Windows.Forms.Button();
            this.tworz_okr = new System.Windows.Forms.Button();
            this.przes_okr = new System.Windows.Forms.Button();
            this.zmien_prom = new System.Windows.Forms.Button();
            this.usun_wierz = new System.Windows.Forms.Button();
            this.dod_wierz = new System.Windows.Forms.Button();
            this.przes_wierz = new System.Windows.Forms.Button();
            this.przes_wielok = new System.Windows.Forms.Button();
            this.Przes_kraw = new System.Windows.Forms.Button();
            this.Kraw_rown = new System.Windows.Forms.Button();
            this.button_kolor = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_prost = new System.Windows.Forms.Button();
            this.buttonusunrel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabela2.SuspendLayout();
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
            this.tabela2.Controls.Add(this.tworz_okr, 1, 0);
            this.tabela2.Controls.Add(this.przes_okr, 0, 1);
            this.tabela2.Controls.Add(this.zmien_prom, 1, 1);
            this.tabela2.Controls.Add(this.usun_wierz, 0, 2);
            this.tabela2.Controls.Add(this.dod_wierz, 1, 2);
            this.tabela2.Controls.Add(this.przes_wierz, 0, 3);
            this.tabela2.Controls.Add(this.przes_wielok, 1, 3);
            this.tabela2.Controls.Add(this.Przes_kraw, 0, 4);
            this.tabela2.Controls.Add(this.Kraw_rown, 1, 4);
            this.tabela2.Controls.Add(this.button_kolor, 1, 6);
            this.tabela2.Controls.Add(this.button_clear, 0, 6);
            this.tabela2.Controls.Add(this.button_prost, 0, 5);
            this.tabela2.Controls.Add(this.buttonusunrel, 1, 5);
            this.tabela2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabela2.Location = new System.Drawing.Point(1523, 3);
            this.tabela2.Name = "tabela2";
            this.tabela2.RowCount = 7;
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28555F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28555F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28555F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28555F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28555F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28555F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2867F));
            this.tabela2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabela2.Size = new System.Drawing.Size(374, 947);
            this.tabela2.TabIndex = 2;
            // 
            // tworz_wiel
            // 
            this.tworz_wiel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tworz_wiel.Location = new System.Drawing.Point(3, 3);
            this.tworz_wiel.Name = "tworz_wiel";
            this.tworz_wiel.Size = new System.Drawing.Size(181, 129);
            this.tworz_wiel.TabIndex = 0;
            this.tworz_wiel.Text = "Tworzenie wielokąta";
            this.tworz_wiel.UseVisualStyleBackColor = true;
            this.tworz_wiel.Click += new System.EventHandler(this.button1_Click);
            // 
            // tworz_okr
            // 
            this.tworz_okr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tworz_okr.Location = new System.Drawing.Point(190, 3);
            this.tworz_okr.Name = "tworz_okr";
            this.tworz_okr.Size = new System.Drawing.Size(181, 129);
            this.tworz_okr.TabIndex = 3;
            this.tworz_okr.Text = "Tworzenie okręgu";
            this.tworz_okr.UseVisualStyleBackColor = true;
            this.tworz_okr.Click += new System.EventHandler(this.tworz_okr_Click);
            // 
            // przes_okr
            // 
            this.przes_okr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.przes_okr.Location = new System.Drawing.Point(3, 138);
            this.przes_okr.Name = "przes_okr";
            this.przes_okr.Size = new System.Drawing.Size(181, 129);
            this.przes_okr.TabIndex = 4;
            this.przes_okr.Text = "Przesuwanie okręgu";
            this.przes_okr.UseVisualStyleBackColor = true;
            this.przes_okr.Click += new System.EventHandler(this.przes_okr_Click);
            // 
            // zmien_prom
            // 
            this.zmien_prom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zmien_prom.Location = new System.Drawing.Point(190, 138);
            this.zmien_prom.Name = "zmien_prom";
            this.zmien_prom.Size = new System.Drawing.Size(181, 129);
            this.zmien_prom.TabIndex = 5;
            this.zmien_prom.Text = "Zmienianie promienia";
            this.zmien_prom.UseVisualStyleBackColor = true;
            this.zmien_prom.Click += new System.EventHandler(this.zmien_prom_Click);
            // 
            // usun_wierz
            // 
            this.usun_wierz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usun_wierz.Location = new System.Drawing.Point(3, 273);
            this.usun_wierz.Name = "usun_wierz";
            this.usun_wierz.Size = new System.Drawing.Size(181, 129);
            this.usun_wierz.TabIndex = 6;
            this.usun_wierz.Text = "Usuwanie wierzchołka";
            this.usun_wierz.UseVisualStyleBackColor = true;
            this.usun_wierz.Click += new System.EventHandler(this.usun_wierz_Click);
            // 
            // dod_wierz
            // 
            this.dod_wierz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dod_wierz.Location = new System.Drawing.Point(190, 273);
            this.dod_wierz.Name = "dod_wierz";
            this.dod_wierz.Size = new System.Drawing.Size(181, 129);
            this.dod_wierz.TabIndex = 7;
            this.dod_wierz.Text = "Dodawanie wierzchołka";
            this.dod_wierz.UseVisualStyleBackColor = true;
            this.dod_wierz.Click += new System.EventHandler(this.dod_wierz_Click);
            // 
            // przes_wierz
            // 
            this.przes_wierz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.przes_wierz.Location = new System.Drawing.Point(3, 408);
            this.przes_wierz.Name = "przes_wierz";
            this.przes_wierz.Size = new System.Drawing.Size(181, 129);
            this.przes_wierz.TabIndex = 8;
            this.przes_wierz.Text = "Przesuwanie wierzchołka";
            this.przes_wierz.UseVisualStyleBackColor = true;
            this.przes_wierz.Click += new System.EventHandler(this.przes_wierz_Click);
            // 
            // przes_wielok
            // 
            this.przes_wielok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.przes_wielok.Location = new System.Drawing.Point(190, 408);
            this.przes_wielok.Name = "przes_wielok";
            this.przes_wielok.Size = new System.Drawing.Size(181, 129);
            this.przes_wielok.TabIndex = 9;
            this.przes_wielok.Text = "Przesuwanie wielokąta";
            this.przes_wielok.UseVisualStyleBackColor = true;
            this.przes_wielok.Click += new System.EventHandler(this.przes_wielok_Click);
            // 
            // Przes_kraw
            // 
            this.Przes_kraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Przes_kraw.Location = new System.Drawing.Point(3, 543);
            this.Przes_kraw.Name = "Przes_kraw";
            this.Przes_kraw.Size = new System.Drawing.Size(181, 129);
            this.Przes_kraw.TabIndex = 10;
            this.Przes_kraw.Text = "Przesuwanie  krawędzi";
            this.Przes_kraw.UseVisualStyleBackColor = true;
            this.Przes_kraw.Click += new System.EventHandler(this.Przes_kraw_Click);
            // 
            // Kraw_rown
            // 
            this.Kraw_rown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Kraw_rown.Location = new System.Drawing.Point(190, 543);
            this.Kraw_rown.Name = "Kraw_rown";
            this.Kraw_rown.Size = new System.Drawing.Size(181, 129);
            this.Kraw_rown.TabIndex = 11;
            this.Kraw_rown.Text = "Rownoleglość";
            this.Kraw_rown.UseVisualStyleBackColor = true;
            this.Kraw_rown.Click += new System.EventHandler(this.Kraw_rown_Click);
            // 
            // button_kolor
            // 
            this.button_kolor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_kolor.Location = new System.Drawing.Point(190, 813);
            this.button_kolor.Name = "button_kolor";
            this.button_kolor.Size = new System.Drawing.Size(181, 131);
            this.button_kolor.TabIndex = 2;
            this.button_kolor.Text = "Wybieranie koloru";
            this.button_kolor.UseVisualStyleBackColor = true;
            this.button_kolor.Click += new System.EventHandler(this.button_kolor_Click);
            // 
            // button_clear
            // 
            this.button_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_clear.Location = new System.Drawing.Point(3, 813);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(181, 131);
            this.button_clear.TabIndex = 1;
            this.button_clear.Text = "Wyczyść";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_prost
            // 
            this.button_prost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_prost.Location = new System.Drawing.Point(3, 678);
            this.button_prost.Name = "button_prost";
            this.button_prost.Size = new System.Drawing.Size(181, 129);
            this.button_prost.TabIndex = 12;
            this.button_prost.Text = "Prostopadłość";
            this.button_prost.UseVisualStyleBackColor = true;
            this.button_prost.Click += new System.EventHandler(this.button_prost_Click);
            // 
            // buttonusunrel
            // 
            this.buttonusunrel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonusunrel.Location = new System.Drawing.Point(190, 678);
            this.buttonusunrel.Name = "buttonusunrel";
            this.buttonusunrel.Size = new System.Drawing.Size(181, 129);
            this.buttonusunrel.TabIndex = 13;
            this.buttonusunrel.Text = "Usuwanie relacji";
            this.buttonusunrel.UseVisualStyleBackColor = true;
            this.buttonusunrel.Click += new System.EventHandler(this.buttonusunrel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 953);
            this.Controls.Add(this.tabela);
            this.MinimumSize = new System.Drawing.Size(1918, 1000);
            this.Name = "Form1";
            this.Text = "Zadanie 1";
            this.tabela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabela2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabela;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tabela2;
        private System.Windows.Forms.Button tworz_wiel;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_kolor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button tworz_okr;
        private System.Windows.Forms.Button przes_okr;
        private System.Windows.Forms.Button zmien_prom;
        private System.Windows.Forms.Button usun_wierz;
        private System.Windows.Forms.Button dod_wierz;
        private System.Windows.Forms.Button przes_wierz;
        private System.Windows.Forms.Button przes_wielok;
        private System.Windows.Forms.Button Przes_kraw;
        private System.Windows.Forms.Button Kraw_rown;
        private System.Windows.Forms.Button button_prost;
        private System.Windows.Forms.Button buttonusunrel;
    }
}

