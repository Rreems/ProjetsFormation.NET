using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceComptesBancaires.Classes.Comptes
{
    internal class ComptePayant : CompteBancaire
    {
        // Bonus :
        // le compte payant facture chaque opération (créant une nouvelle opération de retrait)
        public decimal CoutOperation { get; set; } 
        public ComptePayant(Client client, decimal coutOperation) : base(client)
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(decimal montant)
        {
            var reussit = base.Depot(montant);
            if (reussit)
                FacturerOperation();
            return reussit;
        }

        public override bool Retrait(decimal montant)
        {
            var reussit = base.Retrait(montant);
            if (reussit)
                FacturerOperation();
            return reussit;
        }

        private void FacturerOperation()
        {
            Operation operation = new Operation(_operations.Count + 1, CoutOperation, StatutOperation.Retrait);
            _operations.Add(operation);
            _solde -= CoutOperation;
        }
    }
}
