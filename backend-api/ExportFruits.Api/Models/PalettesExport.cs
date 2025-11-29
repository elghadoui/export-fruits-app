using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class PalettesExport
{
    public uint Id { get; set; }

    public uint StationId { get; set; }

    public uint DossierId { get; set; }

    public int NumpalStation { get; set; }

    public DateOnly? DatePalette { get; set; }

    public string StatutPalette { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual DossiersExport Dossier { get; set; } = null!;

    public virtual ICollection<PalettesLigne> PalettesLignes { get; set; } = new List<PalettesLigne>();

    public virtual Station Station { get; set; } = null!;
}
