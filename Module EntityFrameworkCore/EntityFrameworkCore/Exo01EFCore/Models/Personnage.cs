using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Data;
using Microsoft.Data.SqlClient;

namespace Exo01EFCore.Models;

internal class Personnage
{
    public int Id { get; set; }

    public string Pseudo { get; set; }

    public int PointsDeVie { get; set; }
    public int Armure { get; set; }

    public int Degats { get; set; }

    public DateTime DateCreation { get; set; }

    public int NombrePersonnesTues { get; set; }



    public override string ToString()
    {
        return $"Id: {Id}, Pseudo: {Pseudo}, PointsDeVie: {PointsDeVie}, Armure: {Armure}, Degats: {Degats}, DateCreation: {DateCreation:d}, NombrePersonnesTues: {NombrePersonnesTues}";
    }



    public static void Ajouter(Personnage perso)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        context.Personnages.Add(perso);
        context.SaveChanges();

        Personnage.EstIlMort(perso.Id);
    }

    public static bool Modifier(Personnage perso)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        Personnage? persoAModifier = context.Personnages.FirstOrDefault(p => p.Id == perso.Id);


        if (persoAModifier != null)
        {
            // si vide => on laisse le même
            persoAModifier.Pseudo = string.IsNullOrEmpty(perso.Pseudo) ? persoAModifier.Pseudo : perso.Pseudo;

            persoAModifier.PointsDeVie = perso.PointsDeVie;
            persoAModifier.Armure = perso.Armure;
            persoAModifier.Degats = perso.Degats;
            persoAModifier.DateCreation = perso.DateCreation;
            persoAModifier.NombrePersonnesTues = perso.NombrePersonnesTues;
        }
        else
        {
            return false;
        }

        context.SaveChanges();

        Personnage.EstIlMort(persoAModifier.Id);

        return true;


    }


    public static List<Personnage>? Afficher()
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        return context.Personnages.ToList();
    }


    private static bool EstIlMort(int Id)
    {
        using ApplicationDbContext context = new ApplicationDbContext();
        Personnage personnage = context.Personnages.FirstOrDefault(p => p.Id == Id);

        if (personnage.PointsDeVie <= 0)
        {
            context.Personnages.Remove(personnage);
            context.SaveChanges();

            Console.WriteLine($"Debug: {personnage.Pseudo} est mort </3   X_X");

            return true;
        }
        return false;
    }


    public static void Frapper(int IdFrappe, int IdFrappeur)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        Personnage frappe = context.Personnages.FirstOrDefault(p => p.Id == IdFrappe);
        Personnage frappeur = context.Personnages.FirstOrDefault(p => p.Id == IdFrappeur);

        if (frappeur == null ||frappe == null)
        {
            throw new NullReferenceException(frappeur == null ? "Le Personnage qui frappe n'existe pas." : "Le Personnage frappé n'existe pas.");
        }

        if ((frappeur.Degats - frappe.Armure) > 0) frappe.PointsDeVie -= frappeur.Degats - frappe.Armure;

        context.SaveChanges();

        if (Personnage.EstIlMort(frappe.Id))
        {
            frappeur.NombrePersonnesTues++;
            context.SaveChanges();
        }
    }

    public static List<Personnage> AfficherTanks()
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        Double vieArmureMoy = context.Personnages.Average(p => p.PointsDeVie + p.Armure);

        return context.Personnages
            .Where(p => (p.PointsDeVie + p.Armure) > vieArmureMoy)
            .ToList();
    }
}
