using System.ComponentModel.DataAnnotations;

namespace Exo04.Models
{
    public class Marsupilami
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Petit nom")]
        public string PetitNom { get; set; } = "Bliblou le singe";

        [Required]
        [Display(Name = "Couleur")]
        public string Couleur { get; set; } = "Jaune";
    }
}
