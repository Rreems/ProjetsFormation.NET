using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01Classe.Classes;

internal class Dinosaure
{
    //Attribut
    private int _age;
    private string? _espece;
    private int _nbPattes;
    private double _poids;
    private bool _peutVoler = false;

    // Propriétés
    //  (pour accéder et modifier les attributs, principe de l'encapsulation)
    public int Age
    {
        get => _age;
        set => _age = value;
    }
    public string? Espece { get => _espece; set => _espece = value; }
    public int NbPattes { get => _nbPattes; set => _nbPattes = value; }
    public double Poids
    {
        get
        {
            return _poids;
        }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("La valeur passée au poids est invalide !!! Je le met donc à 100 kg.");
                _poids = 100;
            }
            else
                _poids = value;

            //_peutVoler = false;
            //PeutVoler = false;
            //_nom = "test"; // existe pas car auto property
            //Nom = "test";
        }
    }
    public bool PeutVoler { get => this._peutVoler; set => this._peutVoler = value; }

    // Une propriété avec uniquement un getter
    //private string? _nom;
    //public string? NomMajuscule => _nom!.ToUpper(); 
    //public string? NomMajuscule { get => _nom!.ToUpper(); } 
    //public string? NomMajuscule { get { return _nom!.ToUpper(); } }

    // Propriétés Auto
    // ici on a des propriétés avec des attributs private implicites, on ne les a pas déclaré, on a pas de "_regimeAlimentaire" et "_nom"
    // c'est une version abrégée/simplifiée du concept d'encapsulation
    public string RegimeAlimentaire { get; set; } = "Herbivore"; // default value
    public string? Nom { get; set; } = "denver1";


    // Constructeurs (crée une nouvelle instance de Dinosaur)
    //public Dinosaur() { } // constructeur vide, présent de base dans la classe à moins d'en ajouter un nouveau
    public Dinosaure() // constructeur vide, "par défaut"
    {
        Nom = "Dinosaur par défaut";
        Espece = "Espèce par défaut";
        //_age = 120; // on définit l'age directement par l'attribut
        Age = 120; // on définit l'age par la propriété, si la propriété
        Poids = -250;
    }

    public Dinosaure(int age, string espece, int nbPattes, double poids, string regimeAlimentaire, string? nom)
    {
        //this._age = 120;
        //this.Age = age;
        Age = age;
        Espece = espece;
        NbPattes = nbPattes;
        Poids = poids;
        RegimeAlimentaire = regimeAlimentaire;
        Nom = nom;
    }

    //public Dinosaure(int age, string espece)
    //{
    //    _age = age;
    //    _espece = espece;
    //}


    // Méthodes
    public void Afficher()
    {
        Console.WriteLine($"Le Dinosaur {this.Nom} est agé de {Age} ans et est de l'espèce {Espece}");
    }

    public void Crier()
    {
        Console.WriteLine($"Le Dinosaur {Nom} crie !");
    }

    /// <summary>
    /// Méthode qui permet de faire s'envoler le dinosaure, si il peux.
    /// </summary>
    public void SEnvoler()
    {
        if (PeutVoler)
        {
            Console.WriteLine($"Le Dinosaur {Nom} s'envole majestueusement !");
            return;
        }
        //else
        Console.WriteLine($"Le Dinosaur {Nom} saute et s'écrase lamentablement...");
    }
}
