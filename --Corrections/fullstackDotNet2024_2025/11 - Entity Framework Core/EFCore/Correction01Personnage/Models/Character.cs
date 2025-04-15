using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Personnage.Models
{
    [Table("character")]
    internal class Character
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("pseudo")]
        [MaxLength(20)]
        public string Pseudo { get; set; } = null!; // Equivalent à l'Attribute/DataAnotation [Required]
        [Column("heath_points")]
        public int HeathPoints { get; set; }
        [Column("max_heath_points")]
        public int MaxHeathPoints { get; set; }
        [Column("armor")]
        public int Armor { get; set; }
        [Column("damages")]
        public int Damages { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Column("kills")]
        public int Kills { get; set; } = 0;

        //public int TotalHealthArmor => HeathPoints + Armor;

        //public override string ToString()
        //{
        //    return $"{Id,-5}{Pseudo,-5}{HeathPoints,-5}{MaxHeathPoints,-5}{Armor,-5}{Damages,-5}{CreationDate,-5}{Kills,-5}";
        //}
    }
}
