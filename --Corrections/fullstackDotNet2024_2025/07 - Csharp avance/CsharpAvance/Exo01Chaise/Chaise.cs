using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exo01Chaise;

//internal class Chaise
//{ 
//    private int _nombrePieds = 4;
//    private string? _materiau = "Bois";
//    private string? _couleur = "Blanche";

//    public Chaise(int nombrePieds, string? materiau, string? couleur)
//    {
//        _nombrePieds = nombrePieds;
//        _materiau = materiau;
//        _couleur = couleur;
//    }

//    public Chaise()
//    {
//        //_nombrePieds = 4;
//        //_materiau = "Bois";
//        //_couleur = "Blanche";
//    }

//    public int NombrePieds { get => _nombrePieds; set => _nombrePieds = value; }
//    public string? Materiau { get => _materiau; set => _materiau = value; }
//    public string? Couleur { get => _couleur; set => _couleur = value; }

//    public void Afficher()
//    {
//        Console.WriteLine($"Je suis une Chaise, avec {this.NombrePieds} pieds en {Materiau} et de couleur {Couleur}");
//    }
//}

//internal class Chaise
//{
//    public int NombrePieds { get; set; } = 4;
//    public string? Materiau { get; set; } = "Bois";
//    public string? Couleur { get; set; } = "Blanche";

//    public Chaise() { }
//    public Chaise(int nombrePieds, string? materiau, string? couleur)
//    {
//        NombrePieds = nombrePieds;
//        Materiau = materiau;
//        Couleur = couleur;
//    }

//    public void Afficher()
//    {
//        Console.WriteLine($"Je suis une Chaise, avec {this.NombrePieds} pieds en {Materiau} et de couleur {Couleur}");
//    }
//}

//internal class Chaise
//{
//    public int NombrePieds { get; set; } = 4;
//    public string? Materiau { get; set; } = "Bois";
//    public string? Couleur { get; set; } = "Blanche";

//    public Chaise() { }
//    public Chaise(int nombrePieds, string? materiau, string? couleur)
//    {
//        NombrePieds = nombrePieds;
//        Materiau = materiau;
//        Couleur = couleur;
//    }

//    public void Afficher()
//    {
//        //Console.WriteLine($"Je suis une Chaise, avec {this.NombrePieds} pieds en {Materiau} et de couleur {Couleur}");

//        //Console.WriteLine(this.ToString());
//        //Console.WriteLine(ToString());

//        Console.WriteLine(this);//appelle le ToString implicitement pour write la representation textuelle de la chaise
//    }

//    // override remplace le comportement de base de la méthode Object.ToString(), cette méthode donne la représentation textuelle de l'instance 
//    public override string ToString()
//    {
//        return $"Je suis une Chaise, avec {NombrePieds} pieds en {Materiau} et de couleur {Couleur}";
//    }
//}


internal class Chaise
{
    public int NombrePieds { get; set; }
    public string? Materiau { get; set; }
    public string? Couleur { get; set; }

    public Chaise() : this(4, "Bois", "Blanche")
    {

    }
    public Chaise(int nombrePieds, string? materiau, string? couleur)
    {
        NombrePieds = nombrePieds;
        Materiau = materiau;
        Couleur = couleur;
    }

    public void Afficher()
    {
        Console.WriteLine(this);
    }

    public override string ToString()
    {
        return $"Je suis une Chaise, avec {NombrePieds} pieds en {Materiau} et de couleur {Couleur}";
    }
}