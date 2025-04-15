using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text.Json;
using System.Text.Json.Serialization;
using Correction02Hotel.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Correction02Hotel.Models;

internal class Chambre
{
    [Key]
    public int Numero { get; set; }
    public StatutChambre Statut { get; set; }
    public int NombreLits { get; set; }
    // Permet de préciser la partie entière et le nombre de décimal en base de données
    [Precision(14, 2)]
    public decimal Tarif { get; set; }

    [JsonIgnore] // ne sera jamais écrit par le JsonSerializer
    public List<ReservationChambre> ReservationChambres { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];


    public string ToJson()
    {
        //return $"{{numero: {Numero}, statut: {Statut}, nombreLit: {NombreLits}, tarif: {Tarif}}}";
        return JsonSerializer.Serialize(this);
    }
}
