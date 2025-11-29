using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Station
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string TypeStation { get; set; } = null!;

    public string? Ville { get; set; }

    public string Pays { get; set; } = null!;

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<DossiersExport> DossiersExports { get; set; } = new List<DossiersExport>();

    public virtual ICollection<PalettesExport> PalettesExports { get; set; } = new List<PalettesExport>();

    public virtual ICollection<StationExporteur> StationExporteurs { get; set; } = new List<StationExporteur>();

    public virtual ICollection<Verger> Vergers { get; set; } = new List<Verger>();
}
