using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo08Generiques.Tourneviss.Visses;

namespace Demo08Generiques.Tourneviss
{
    public class TournevisAEmbout<T> where T : Vis
    {
        // s'adaptera à la vis passée à l'instanciation et la définition
        public void Utiliser(T vis)
        {
            vis.Serrer();
            vis.Desserrer();
        }
    }
}
