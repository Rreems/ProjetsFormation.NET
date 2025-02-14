using System.ComponentModel.DataAnnotations;

namespace Exo06.Models;

public class PictureCreateViewModel
{
    /* Lors de l'envoi du FOrulaire, on va devoir envoyer un fichier.
     * On aura pas d'Id, on élimine donc ce champ. 
     * Pour le réceptionner, il faut le lier à un variable de type IFormFile
     */
    [StringLength(100)]
    public required string Title { get; set; }

    // Image au type: implémentation de l'interf des fichiers
    public required IFormFile Picture { get; set; }
}
