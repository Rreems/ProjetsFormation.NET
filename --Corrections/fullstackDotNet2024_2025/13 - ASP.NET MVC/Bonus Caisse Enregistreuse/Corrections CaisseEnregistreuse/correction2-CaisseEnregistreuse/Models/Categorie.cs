using System.ComponentModel.DataAnnotations;
using TpCaisseEnregistreuse.Models;

namespace TpCaisseEnregistreuse.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]

        public string Name { get; set; }
        [Display(Name = "Liste des produits")]
        [Required(ErrorMessage = "Liste des produits Manquante")]


        public List<Produit> Produits { get; set; }

    }
}
