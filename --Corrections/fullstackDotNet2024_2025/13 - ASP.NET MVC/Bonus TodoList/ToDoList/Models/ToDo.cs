using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    [Table("todo")]
    public class ToDo
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [Display(Name ="Titre")]
        public string? Title { get; set; }
        [Column("description")]
        [Display(Name ="Description")]
        public string? Description { get; set; }
        [Column("finished"), Display(Name ="Statut")] // autre syntaxe des DataAnnotation/Attributes
        public bool Finished { get; set; } = false;
    }
}
