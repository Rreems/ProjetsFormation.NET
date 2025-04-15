using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactWithDtos.DTOs
{
    // Exemple :
    // entité que l'on retournerais dans le controller dans le cas où l'on ne veut que le fullname
    public class ContactFullNameDTO
    {
        [JsonIgnore]
        public string LastName { get; set; } = string.Empty;
        [JsonIgnore]
        public string FirstName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
    }
}
