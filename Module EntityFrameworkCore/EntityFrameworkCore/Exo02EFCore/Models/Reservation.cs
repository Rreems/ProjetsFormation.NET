using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo02EFCore.Enum;

namespace Exo02EFCore.Models;

public class Reservation
{
    [Column("id")]
    public int Id { get; set; }

    [Column("statut")]
    public StatutReservation Statut { get; set; }


    [Column("client_id")]
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    
    [Column("hotel_id")]
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;


    public List<ReservationChambre> ReservationChambres { get; set; } = new List<ReservationChambre>();

}
