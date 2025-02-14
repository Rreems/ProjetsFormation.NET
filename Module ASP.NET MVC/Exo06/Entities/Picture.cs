using System.ComponentModel.DataAnnotations;

namespace Exo06.Entities;

/*
 * En BDD on stocke non pas l'image, mais le lien vers l'image
 * une fois upload sur notre serveur. On aura non plus un fichier,
 * mais une chaine de caractère en valeur
*/
public class Picture
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public required string Title { get; set; }

    [StringLength(50)]
    public required string PictureUrl { get; set; }
}
