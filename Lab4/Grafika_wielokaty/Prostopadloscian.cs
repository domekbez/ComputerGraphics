using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    class Prostopadloscian
    {
        //Zrodlo (model przykladowego szescianu) - http://www.opengl-tutorial.org/beginners-tutorials/tutorial-7-model-loading/#example-obj-file
        public Siatka generujProstopadloscian(float a, float b, float c)
        {
            float a1 = a / 2;
            float b1 = b / 2;
            float c1 = c / 2;

            Siatka s = new Siatka();
            s.trojkanty = new List<Trojkant>();

            Trojkant t = new Trojkant();
            Wierzcholek w = new Wierzcholek(a1, b1, -c1, new Wektor(0, 0, -1,1), 0.748573f, 0.750412f);
            t.wierzcholki.Add(w);
            Wierzcholek w2 = new Wierzcholek(a1, -b1, -c1, new Wektor(0, 0, -1,1), 0.749279f, 0.501284f);
            t.wierzcholki.Add(w2);
            Wierzcholek w3 = new Wierzcholek(-a1, -b1, -c1, new Wektor(0, 0, -1,1), 0.999110f, 0.501077f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, b1, -c1, new Wektor(0, 0, -1,1), 0.748573f, 0.750412f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, -b1, -c1, new Wektor(0, 0, -1,1), 0.999110f, 0.501077f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, b1, -c1, new Wektor(0, 0, -1,1), 0.999455f, 0.750380f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(-a1, -b1, c1, new Wektor(-1, 0, 0,1), 0.250471f, 0.500702f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, b1, c1, new Wektor(-1, 0, 0,1), 0.249682f, 0.749677f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, b1, -c1, new Wektor(-1, 0, 0,1), 0.001085f, 0.750380f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(-a1, -b1, c1, new Wektor(-1, 0, 0,1), 0.250471f, 0.500702f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, b1, -c1, new Wektor(-1, 0, 0,1), 0.001085f, 0.750380f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, -b1, -c1, new Wektor(-1, 0, 0,1), 0.001517f, 0.499994f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, -b1, c1, new Wektor(0, 0, 1,1), 0.499422f, 0.500239f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(a1, b1, c1, new Wektor(0, 0, 1,1), 0.500149f, 0.750166f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, -b1, c1, new Wektor(0, 0, 1,1), 0.250471f, 0.500702f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, b1, c1, new Wektor(0, 0, 1,1), 0.500149f, 0.750166f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, b1, c1, new Wektor(0, 0, 1,1), 0.249682f, 0.749677f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, -b1, c1, new Wektor(0, 0, 1,1), 0.250471f, 0.500702f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);
            //7
            t = new Trojkant();
            w = new Wierzcholek(a1, -b1, -c1, new Wektor(1, 0, 0,1), 0.250471f, 0.500702f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(a1, b1, -c1, new Wektor(1, 0, 0,1), 0.748573f, 0.750412f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(a1, -b1, c1, new Wektor(1, 0, 0,1), 0.499422f, 0.500239f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, b1, -c1, new Wektor(1, 0, 0,1), 0.748573f, 0.750412f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(a1, b1, c1, new Wektor(1, 0, 0,1), 0.500149f, 0.750166f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(a1, -b1, c1, new Wektor(1, 0, 0,1), 0.499422f, 0.500239f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, b1, -c1, new Wektor(0, 1, 0,1), 0.748573f, 0.750412f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, b1, -c1, new Wektor(0, 1, 0,1), 0.748355f, 0.998230f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(a1, b1, c1, new Wektor(0, 1, 0,1), 0.500149f, 0.750166f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(-a1, b1, -c1, new Wektor(0, 1, 0,1), 0.748355f, 0.998230f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, b1, c1, new Wektor(0, 1, 0,1), 0.500193f, 0.998728f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(a1, b1, c1, new Wektor(0, 1, 0,1), 0.500149f, 0.750166f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, -b1, -c1, new Wektor(0, -1, 0,1), 0.749279f, 0.501284f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(a1, -b1, c1, new Wektor(0, -1, 0,1), 0.499422f, 0.500239f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, -b1, c1, new Wektor(0, -1, 0,1), 0.498993f, 0.250415f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);

            t = new Trojkant();
            w = new Wierzcholek(a1, -b1, -c1, new Wektor(0, -1, 0,1), 0.749279f, 0.501284f);
            t.wierzcholki.Add(w);
            w2 = new Wierzcholek(-a1, -b1, c1, new Wektor(0, -1, 0,1), 0.498993f, 0.250415f);
            t.wierzcholki.Add(w2);
            w3 = new Wierzcholek(-a1, -b1, -c1, new Wektor(0, -1, 0,1), 0.748953f, 0.250920f);
            t.wierzcholki.Add(w3);
            s.trojkanty.Add(t);





            s.generujWierzcholki();

            return s;



        }
   
    }
}
