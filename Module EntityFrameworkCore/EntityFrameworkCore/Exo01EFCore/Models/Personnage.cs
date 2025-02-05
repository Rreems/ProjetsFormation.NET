using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01EFCore.Data;
using Microsoft.Data.SqlClient;

namespace Exo01EFCore.Models;

public class Personnage
{
    public int Id { get; set; }

    public string Pseudo { get; set; } = null!;

    public int PointsDeVie { get; set; }
    public int Armure { get; set; }

    public int Degats { get; set; }

    public DateTime DateCreation { get; set; }

    public int NombrePersonnesTues { get; set; }



    public override string ToString()
    {
        return $"Id: {Id}, Pseudo: {Pseudo}, PointsDeVie: {PointsDeVie}, Armure: {Armure}, Degats: {Degats}, DateCreation: {DateCreation:d}, NombrePersonnesTues: {NombrePersonnesTues}";
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

}
