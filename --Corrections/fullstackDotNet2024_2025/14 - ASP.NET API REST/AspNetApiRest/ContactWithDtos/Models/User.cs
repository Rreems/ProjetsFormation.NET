using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactWithDtos.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column("email")]
        public string? Email { get; set; }
        [Column("password")]
        [JsonIgnore]
        public string? Password { get; set; } //ici un hash du password
        [Column("is_admin")]
        public bool IsAdmin { get; set; } = false; // Remplacer par un champ Rôle en String/enum voir un Model Role
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("created_by")]
        public Guid? CreatedBy { get; set; }
        // champ supplémentaires : phone, names, ...
    }
}
