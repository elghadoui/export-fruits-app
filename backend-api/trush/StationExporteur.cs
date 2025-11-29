// Models/StationExporteur.cs
using System;

namespace ExportFruits.Api.Models
{
    public class StationExporteur
    {
        public int Id { get; set; }                      // id

        public int StationId { get; set; }               // station_id
        public Station Station { get; set; } = null!;

        public int SocieteExportId { get; set; }         // societe_export_id
        public SocieteExport SocieteExport { get; set; } = null!;

        public string CodeExportStation { get; set; } = null!;  // code_export_station (refexp)

        public bool Actif { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
