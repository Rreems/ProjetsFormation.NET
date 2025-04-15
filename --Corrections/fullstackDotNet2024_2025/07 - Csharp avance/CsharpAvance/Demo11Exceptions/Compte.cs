using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo11Exceptions;

public class Compte
{
    private int code;
    private float solde;
    public float Solde { get => solde;}

    public void Verser(float montant)
    {
        solde += montant;
    }
    public void Retirer(float montant)
    {
        if (montant > solde)
            //throw new Exception("Solde insuffisant");
            //throw new Exception($"Solde insuffisant, retrait de {montant}, disponnible {solde}");
            //throw new SoldeInsuffisantException();
            //throw new SoldeInsuffisantException($"Solde insuffisant, retrait de {montant}, disponnible {solde}");
            throw new SoldeInsuffisantException(montant, solde);
        solde -= montant;
    }
}
