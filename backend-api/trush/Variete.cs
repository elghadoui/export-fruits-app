// Models/Variete.cs
using System;

namespace ExportFruits.Api.Models
{
    public class Variete
    {
        public int Id { get; set; }                      // id
        public string Code { get; set; } = null!;        // code
        public string Nom { get; set; } = null!;         // nom

        public string Famille { get; set; } = "AUTRE";   // famille (AGRUME, FRUIT_ROUGE, AUTRE)
        public string? TypeProduit { get; set; }         // type_produit

        public int? CodeStationDiaf { get; set; }        // code_station_diaf
        public int? CodeStationZaouia { get; set; }      // code_station_zaouia

        public bool Actif { get; set; } = true;          // actif

        public DateTime CreatedAt { get; set; }          // created_at
        public DateTime UpdatedAt { get; set; }          // updated_at
    }
}
