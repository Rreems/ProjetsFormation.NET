using System.ComponentModel.DataAnnotations;

namespace Exo06.Models;

/*
 * En BDD on stocke non pas l'image, mais le lien vers l'image
 * une fois upload sur notre serveur. On aura non plus un fichier,
 * mais une chaine de caractère en valeur
*/
public class PictureViewModel
{
    public long Id { get; init; }

    public required string Title { get; init; }

    public required string PictureUrl { get; init; }
}
