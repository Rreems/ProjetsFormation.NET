using System.ComponentModel.DataAnnotations;

namespace Exo01.Models;

public class Contact
{
    [Display(Name = "Id du contact"), MaxLength(50)]
    public string Id { get; set; }

    
    [Display(Name = "Nom"), MaxLength(50), Required]
    public string Nom { get; set; }


    [Display(Name = "Prénom"), MaxLength(50)]
    public string Prenom { get; set; }


    [Display(Name = "Numéro de téléphone"), MaxLength(50)]
    public string Numero { get; set; }
}
