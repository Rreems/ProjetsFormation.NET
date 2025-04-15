using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03Mock
{
    public class Jeu
    {
        private IDe _de;

        public Jeu(IDe de)
        {
            _de = de;
        }

        public bool Jouer() // méthode pour jouer au jeu => retourne true si on gagne
        {
            return _de.Lancer() == 20;
        }
    }
}
