using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo08Generiques.Tourneviss.Visses;

namespace Demo08Generiques.Tourneviss
{
    public static class TournevisUniversel
    {
        public static void Utiliser<T>(T vis) where T : Vis
        {
            // s'adaptera à la vis passée à l'appel
            vis.Serrer();
            vis.Desserrer();
        }
    }

}
