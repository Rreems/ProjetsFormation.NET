using System.ComponentModel.DataAnnotations;

namespace M2i.Demo.Upload.Models
{
    public class PictureCreateViewModel
    {
        /*
            Lors de l'envoi du formulaire, on va devoir envoyer un fichier. On n'aura pas d'Id, on peut donc éliminer ce champ des données. Pour réceptionner un fichier, il faut lier cela à une variable de type IFormFile
         */
        [StringLength(100)]
        public required string Title { get; set; }


        public required IFormFile Picture { get; set; }
    }
}
