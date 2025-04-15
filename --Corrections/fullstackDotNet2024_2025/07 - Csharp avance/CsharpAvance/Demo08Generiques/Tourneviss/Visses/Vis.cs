using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Generiques.Tourneviss.Visses
{
    public abstract class Vis
    {

        protected string taille;
        public Vis(string taille)
        {
            this.taille = taille;
        }
        public abstract void Serrer();
        public abstract void Desserrer();

    }
}
