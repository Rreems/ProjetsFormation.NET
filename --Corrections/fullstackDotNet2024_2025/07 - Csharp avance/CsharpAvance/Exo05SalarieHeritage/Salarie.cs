using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Exo05SalarieHeritage;

internal class Salarie
{
    private decimal _salaire;
    public decimal Salaire
    {
        get => _salaire;
        set 
        {
            TotalSalaires -= _salaire;
            _salaire = value;
            TotalSalaires += _salaire;
        }
    }
    public virtual decimal SalaireTotal => Salaire; // pourra être override pour Commercial pour ajouter la commission

    public string Matricule { get; set; } = "000";
    public string Nom { get; set; } = "Salarié par défaut";
    public string Service { get; set; } = "Service par défaut";
    public string Categorie { get; set; } = "Catégorie par défaut";
    public static int NombreSalaries { get; private set; } = 0;
    public static decimal TotalSalaires { get; private set; } = 0;

    public Salarie()
    {
        Salaire = 16236;
        NombreSalaries++;
    }

    public Salarie(string matricule, string service, string catégorie, string nom, decimal salaire) : this()
    {
        Matricule = matricule;
        Service = service;
        Categorie = catégorie;
        Nom = nom;
        Salaire = salaire;
    }
    
    public virtual void AfficherSalaire()
    {
        Console.WriteLine($"Le salaire de {Nom} est de {Salaire} euros");
    }

    public static void RemiseAZero()
    {
        NombreSalaries = 0;
        TotalSalaires = 0;
    }

    public override string ToString()
    {
        return $"{GetType().Name} : Nom = {Nom}, Service = {Service}, Categorie = {Categorie}, Salaire fixe = {Salaire}, Salaire total : {SalaireTotal}";
    }
}
