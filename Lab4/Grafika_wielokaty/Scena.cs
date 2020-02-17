using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Scena
    {
        public List<Model> obiekty { get; set; }
        public Kamera kamera { get; set; }
        public Scena(List<Model> obiekty, Kamera kamera)
        {
            this.obiekty = obiekty;
            this.kamera = kamera;
        }
    }
}
