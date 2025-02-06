using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo02EFCore.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Exo02EFCore.Models;

public class Chambre
{
    [Key, Column("numero_id")]
    public int NumeroId { get; set; }

    [Column("statut")]
    public StatutChambre Statut  { get; set; }

    [Column("nombre_lits")]
    public int NombreLits { get; set; }

    [Column("tarif"), Precision(20,2)]
    public Decimal Tarif { get; set; }


    [Column("hotel_id")]
    public int? HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;

    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<ReservationChambre> ReservationChambres { get; set; } = new List<ReservationChambre>();

}
