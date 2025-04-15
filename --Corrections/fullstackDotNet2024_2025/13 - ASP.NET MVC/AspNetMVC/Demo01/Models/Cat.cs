using System.ComponentModel.DataAnnotations;

namespace Demo01.Models
{
    public class Cat
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Range(0, 60)]
        public int Age { get; set; }

        public string? Breed { get; set; }
        public string? Color { get; set; }
    }
}
