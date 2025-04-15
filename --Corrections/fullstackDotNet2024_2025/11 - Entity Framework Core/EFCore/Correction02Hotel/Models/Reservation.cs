using System.Text.Json;
using System.Text.Json.Serialization;
using Correction02Hotel.Models.Enums;

namespace Correction02Hotel.Models;

internal class Reservation
{
    public int Id { get; set; }
    public StatutReservation StatutReservation { get; set; }

    [JsonIgnore] // ne sera jamais écrit par le JsonSerializer
    public List<ReservationChambre> ReservationChambres { get; set; } = new();
    public List<Chambre> Chambres { get; set; } = new();

    //public int ClientId { get; set; }
    public int ClientIdentifiant { get; set; }
    // conventions de nommage selon la clé primaire de Client
    // https://learn.microsoft.com/fr-fr/ef/core/modeling/relationships/conventions#discovering-foreign-key-properties

    public Client Client { get; set; } = null!;

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

}
