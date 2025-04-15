using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Exo02Salaries.Classes;

internal class Salarie
{
    // propfull => 1 attribut et sa propriété
    private int _salaire;
    public int Salaire
    {
        get => _salaire;
        set // pour gérer plus efficacement le Salaire total, nous devons changer le setter du Salaire
        {
            // on soustrait l'ancien salaire du salarié au total
            TotalSalaires -= _salaire;
            // on change le salaire du salarié
            _salaire = value;
            // on réaugmente le total des salaires par la nouvelle valeur
            TotalSalaires += _salaire;
        }
    }

    // auto-property => 1 propriété mais l'attribut est caché
    // utile si on ne fait rien de particulier au get ou au set de l'attribut en question
    public string Matricule { get; set; } = "000";
    public string Service { get; set; } = "Salarié par défaut";
    public string Catégorie { get; set; } = "Service par défaut";
    public string Nom { get; set; } = "Catégorie par défaut";
    public static int NombreSalaries { get; private set; } = 0;
    public static int TotalSalaires { get; private set; } = 0;

    public Salarie()
    {
        Salaire = 16236; // SMIC pour les salariés par défaut
        NombreSalaries++;
    }

    public Salarie(string matricule, string service, string catégorie, string nom, int salaire) : this()
    {
        Matricule = matricule;
        Service = service;
        Catégorie = catégorie;
        Nom = nom;
        Salaire = salaire;
    }
    
    public void AfficherSalaire()
    {
        Console.WriteLine($"Le salaire de {Nom} est de {Salaire} euros");
    }

    public static void RemiseAZero()
    {
        NombreSalaries = 0;
        TotalSalaires = 0;
    }
}
