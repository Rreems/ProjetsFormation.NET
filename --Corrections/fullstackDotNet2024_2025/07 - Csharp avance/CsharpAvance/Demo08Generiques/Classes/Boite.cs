using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo08Generiques.Classes
{
    public class Boite<T> // where T : Mammifere // seulement des mammifere (Mammifere, Chien, Chat, ...)
    //public class Boite<T, T2, T3> 
    {
        private T valeur;
        public T Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        public T Methode(T entree) { return valeur;  }
    }
}
