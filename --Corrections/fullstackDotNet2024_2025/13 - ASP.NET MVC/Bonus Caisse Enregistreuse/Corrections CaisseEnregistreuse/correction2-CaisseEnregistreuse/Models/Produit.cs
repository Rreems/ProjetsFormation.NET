using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TpCaisseEnregistreuse.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom Manquant")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Le nom doit être compris entre 1 et 30 caractères.")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Manquante")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "La description doit être comprise entre 1 et 30 caractères.")]
        public string? Description { get; set; }

        [Display(Name = "Prix")]
        [Required(ErrorMessage = "Prix Manquant")]
        [Precision(10,2)]
        public decimal Price { get; set; }

        [Display(Name = "Quantité")]
        [Required(ErrorMessage = "Quantité Manquante")]
        public int StorageQuantity { get; set; }

        public string? ProductUrl { get; set; }

        //[ForeignKey(nameof(Categorie))]
        public int CategorieId { get; set; }

        public Categorie? Categorie { get; set; }

        [Display(Name = "Image")]
        public string? ProduitPath { get; set; }

    }
}





