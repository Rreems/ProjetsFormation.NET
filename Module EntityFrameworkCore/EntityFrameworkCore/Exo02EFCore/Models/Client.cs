using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo02EFCore.Models;

public class Client
{
    [MaxLength(50), Column("id")]
    public int Id { get; set; }

    [MaxLength(50), Column("nom")]
    public string Nom { get; set; }

    [MaxLength(50), Column("prenom")]
    public string Prenom { get; set; }

    [Column("numero_telephone")]
    public string NumeroTelephone { get; set; }


    public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    [Column("hotel_id")]
    public int? HotelId { get; set; }
    public Hotel Hotel { get; set; }

}
