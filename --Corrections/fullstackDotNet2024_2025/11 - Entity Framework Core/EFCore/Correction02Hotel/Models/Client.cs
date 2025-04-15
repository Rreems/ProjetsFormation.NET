using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Hotel.Models;

internal class Client
{
    [Key]
    public int Identifiant { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public List<Reservation> Reservations { get; set; } = new(); // = [];
}
