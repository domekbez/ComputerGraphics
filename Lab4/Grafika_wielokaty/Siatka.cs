using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Siatka
    {
        public List<Trojkant> trojkanty { get; set; }
        public List<Wierzcholek> wierzcholki { get; set; }

        public void generujWierzcholki()
        {
            wierzcholki = new List<Wierzcholek>();
            foreach (var el in trojkanty)
            {
                el.wierzcholki.Count();
                wierzcholki.Add(el.wierzcholki[0]);
                wierzcholki.Add(el.wierzcholki[1]);
                wierzcholki.Add(el.wierzcholki[2]);

            }

        }
    }
}
