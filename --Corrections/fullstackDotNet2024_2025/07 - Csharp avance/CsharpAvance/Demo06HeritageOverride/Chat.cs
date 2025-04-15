using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06HeritageOverride
{
    internal sealed class Chat : Mammifere // sealed => Chat ne pourra pas être hérité
    {
        public Chat(string nom, bool estVivant, string genre) : base(nom, estVivant, genre)
        {
        }


        public override void SeDeplacer()
        {
            Console.WriteLine("Le chat marche sur ses 4 pattes");
        }

        public override void Crier()
        {
            //base.Crier();
            Console.WriteLine("Le chat miaule !");
        }
    }
}
