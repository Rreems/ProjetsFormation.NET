using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Commande.Classes
{
    internal class Commande
    {
        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }

        public override string ToString()
        {
            return $"Commande n°{Id} réalisée le {DateCommande:d} pour un montant de {Total} euros";
        }

        public Commande(decimal total, DateTime dateCommande, int clientId)
        {
            DateCommande = dateCommande;
            Total = total;
            ClientId = clientId;
        }

        public Commande(int id, decimal total, DateTime dateCommande, int clientId) : this(total, dateCommande, clientId)
        {
            Id = id;
        }
    }
}
