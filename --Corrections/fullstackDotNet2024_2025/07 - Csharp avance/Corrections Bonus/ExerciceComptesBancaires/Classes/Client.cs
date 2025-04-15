using ExerciceComptesBancaires.Classes.Comptes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceComptesBancaires.Classes
{
    internal class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Identifiant { get; set; }
        public List<CompteBancaire> CompteBancaires { get; set; } = new List<CompteBancaire>();
        public Client(string nom, string prenom, string identifiant)
        {
            Nom = nom;
            Prenom = prenom;
            Identifiant = identifiant;
        }
        public override string? ToString()
        {
            return $"Client: Nom= {Nom} Prenom= {Prenom} Identifiant= {Identifiant}";
        }
    }
}
