using System.ComponentModel.DataAnnotations;

namespace Exercice05.Models
{
    public class Marmoset
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string Color { get; set; }

        [Range(0, 50)]
        public int Age { get; set; }
    }
}
