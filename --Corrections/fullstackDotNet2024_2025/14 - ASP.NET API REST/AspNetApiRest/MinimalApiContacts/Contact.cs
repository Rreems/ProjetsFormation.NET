using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


class Contact
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}".Trim();

    [Required]
    [RegularExpression("^[FMN]$", ErrorMessage = "Genre invalide (doit être F, M ou N)")]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }

    public int Age => DateTime.Now.Year - BirthDate.Year;

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }
}

