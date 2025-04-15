using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceComptesBancaires.Classes
{
    internal class Operation
    {
        public int Numero { get; set; }
        public decimal Montant { get; set; }
        public StatutOperation StatutOperation { get; set; }
        public Operation(int numero, decimal montant, StatutOperation statutOperation)
        {
            Numero = numero;
            Montant = montant;
            StatutOperation = statutOperation;
        }

        public override string? ToString()
        {
            return $"Numero = {Numero}, Montant = {Montant}, StatutOperation = {StatutOperation}";
        }
    }

    enum StatutOperation
    {
        Depot,
        Retrait
    }
}
