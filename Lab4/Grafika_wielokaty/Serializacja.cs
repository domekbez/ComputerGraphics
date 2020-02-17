using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Serializacja
    {
        public Renderer renderer;
        public Scena scena;
        public List<Model> obiekty;
        public List<Kamera> kamery;
        public Serializacja(Renderer renderer,Scena scena,List<Model> obiekty,List<Kamera> kamery)
        {
            this.renderer = renderer;
            this.scena = scena;
            this.obiekty = obiekty;
            this.kamery = kamery;
        }
    }
}
