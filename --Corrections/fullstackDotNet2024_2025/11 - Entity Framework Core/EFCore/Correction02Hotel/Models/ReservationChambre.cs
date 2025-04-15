using Microsoft.EntityFrameworkCore;

namespace Correction02Hotel.Models;

[PrimaryKey(nameof(ChambreNumero),nameof(ReservationId))]
internal class ReservationChambre
{
    //public (int ReservationId, int ChambreNumero) Id => (ChambreNumero, ReservationId); // pour simplifier l'utilisation

    // [ForeignKey(nameof(Chambre))]
    public int ChambreNumero { get; set; }
    public Chambre Chambre { get; set; } = null!;
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;

    // possible d'ajouter des champs (ex: durrée de reservation de la chambre, nombre de personne dans la chambre, ...)
}
