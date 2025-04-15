using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceComptesBancaires.Classes.Comptes
{
    internal class CompteCourant : CompteBancaire
    {
        public CompteCourant(Client client) : base(client)
        {
        }
    }
}
