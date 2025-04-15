using System.ComponentModel.DataAnnotations;

namespace M2i.Demo.Upload.Entities
{
    /*
        En base de données, on veut stocker non pas l'image en tant que tel mais le lien vers cette image une fois upload sur notre serveur. On va donc avoir non pas un fichier, mais une chaine de caractère en valeur
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
}
