using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceComptesBancaires.Classes.Comptes
{
    internal class CompteEpargne : CompteBancaire
    {
        // Bonus:
        // Le compte épargne a un taux d'intérets que l'on peut calculer et ajouter chaque année (nouvelle opération de dépôt)
        public decimal TauxPct { get; set; }
        public DateTime AnniversaireDuCompte { get; private set; }

        public CompteEpargne(Client client, decimal tauxPct) : base(client)
        {
            TauxPct = tauxPct;
            AnniversaireDuCompte = DateTime.Now.AddYears(1); // dans 1 an
        }
        public bool CalculerLesInterets()
        {
            if (DateTime.Now >= AnniversaireDuCompte) // si ça fait au moins 1 an que le compte n'a pas eu ses intérets calculés
            {
                _solde *= (1 + TauxPct) / 100;
                AnniversaireDuCompte = AnniversaireDuCompte.AddYears(1); // on augmente pour l'année suivante
                return true;
            }
            else return false;
        }
    }
}
