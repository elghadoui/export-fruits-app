// Models/Station.cs
using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models
{
    public class Station
    {
        public int Id { get; set; }                      // id
        public string Code { get; set; } = null!;        // code : DIAF, ZAOUIA...
        public string Nom { get; set; } = null!;         // nom : "Station DIAF", ...

        public bool Actif { get; set; } = true;

        public DateTime CreatedAt { get; set; }          // optionnel si tu l'ajoutes en SQL
        public DateTime UpdatedAt { get; set; }

        public ICollection<StationExporteur> StationExporteurs { get; set; } = new List<StationExporteur>();
    }
}
