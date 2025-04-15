using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ExoCaisseEnregistreuse.Models
{
    public class Produit
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Precision(6, 2)]
        [Display(Name = "Prix")]
        public decimal Prix { get; set; }

        [Display(Name = "Quantité en stock")]
        public int QteEnStock { get; set; }

        [ForeignKey(nameof(Categorie))]
        public int CategorieId { get; set; }

        public Categorie? Categorie { get; set; }
        [Display(Name = "Image")]
        public string? ImagePath { get; set; } = "/images/cd0317d6-962a-4a51-9aed-52ee018cd754-placeholder.png";




    }
}

