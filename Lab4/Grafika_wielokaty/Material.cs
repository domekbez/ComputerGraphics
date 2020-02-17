using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Material
    {
        float ks,ka,kd;
        float alfa;
        public Material(float ks, float kd, float ka, float alfa)
        {
            this.ks = ks;
            this.kd = kd;
            this.ka = ka;
            this.alfa = alfa; 
        }
        public Color Phong(Color Ia, Color Id, Color Is,Wektor Li,Wektor N,Wektor V,float If)
        {
            int  r,g,b;
            float LiN = Wektor.iloczynSkalarny(Li, N);
            Wektor R = new Wektor(2 * LiN * N.wek[0] - Li.wek[0], 2 * LiN * N.wek[1] - Li.wek[1], 2 * LiN * N.wek[2] - Li.wek[2]);
            R = R.normalizacja();
            r = (int)((ka * (Ia.R / 255f) + (kd * LiN * (Id.R / 255f) + ks * Wektor.iloczynSkalarny(R, V) * (Is.R / 255f)) * If) * 255);
            g = (int)((ka * (Ia.G / 255f) + (kd * LiN * (Id.G / 255f) + ks * Wektor.iloczynSkalarny(R, V) * (Is.G / 255f)) * If)* 255);
            b = (int)((ka * (Ia.B / 255f) + (kd * LiN * (Id.B / 255f) + ks * Wektor.iloczynSkalarny(R, V) * (Is.B / 255f)) * If) * 255);
            if (r < 0 || r > 255)
                r = 0;
            if (g < 0 || g > 255)
                g = 0;
            if (b < 0 || b > 255)
                b = 0;
            return Color.FromArgb(r, g, b);
        }
    }
}
