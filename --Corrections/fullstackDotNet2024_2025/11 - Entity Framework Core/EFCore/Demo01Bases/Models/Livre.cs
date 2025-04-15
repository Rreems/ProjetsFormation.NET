using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01Bases.Models;

internal class Livre
{
    // L'ID est détecté automatique si s'apelle "Id" OU "<NomEntité>Id"
    // [Key] // A préciser lorsque l'on ne respecte pas la convention
    public int Id { get; set; }
    //[MinLength(5)]
    //[MaxLength(200)]
    [Required, MinLength(5), MaxLength(200)] // ne pas oublier d'ajouer et d'appliquer la migration
    public string? Titre { get; set; }
    public string? Description { get; set; }
    public string? Auteur { get; set; }
    public DateTime DatePublication { get; set; }


    //public int Matricule => Id; // pas de colonne dans la table
    //public int AgeDuLivre => //calcul de l'age // pas de champ
}
