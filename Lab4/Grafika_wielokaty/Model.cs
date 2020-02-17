using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Model
    {
        public Wektor pozycja { get; set; }
        public Wektor skala { get; set; }
        public Wektor rotacja { get; set; }
        public Siatka siatka { get; set; }
        public Color kolor { get; set; }
        public string name { get; set; }

        public Model(Siatka siatka)
        {
            this.siatka = siatka;
            pozycja = new Wektor(new float[] { 0f, 0f, 0f });
            skala = new Wektor(new float[] { 0.1f, 0.1f, 0.1f });
            rotacja = new Wektor(new float[] { 0, 0, 0 });
            kolor = Color.Black;

        }
        public Macierz zwrocMacierzModelu()
        {
            Macierz obroty = Macierz.macierzObrotowX(rotacja.wek[0]).mnozenieMacierzy(Macierz.macierzObrotowY(rotacja.wek[1])).mnozenieMacierzy(Macierz.macierzObrotowZ(rotacja.wek[2]));
            Macierz skali = Macierz.macierzSkalowania(skala.wek[0], skala.wek[1], skala.wek[2]);
            Macierz pozycji = Macierz.macierzT(pozycja.wek[0], pozycja.wek[1], pozycja.wek[2]);
            
            return pozycji.mnozenieMacierzy(obroty).mnozenieMacierzy(skali);
        }

    }
}
