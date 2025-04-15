using System.ComponentModel.DataAnnotations;

namespace ExoCaisseEnregistreuse.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        public List<Produit>? ListeProduits { get; set; } = new List<Produit>();


    }
}
