using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo11Exceptions;

internal class SoldeInsuffisantException : Exception
{
    public float Montant { get; set; }
    public float Solde { get; set; }
    public SoldeInsuffisantException(string? message) : base(message)
    {
    }
    public SoldeInsuffisantException() : base("Le solde était insuffisant !")
    {
    }

    public SoldeInsuffisantException(float montant, float solde) : base($"Le solde était insuffisant ! Montant : {montant}, Solde : {solde}")
    {
        Montant = montant;
        Solde = solde;
    }
}
