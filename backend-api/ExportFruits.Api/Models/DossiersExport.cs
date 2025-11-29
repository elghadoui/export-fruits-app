using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class DossiersExport
{
    public uint Id { get; set; }

    public uint StationId { get; set; }

    public int NumdosStation { get; set; }

    public uint ConteneurId { get; set; }

    public DateOnly? DateDossier { get; set; }

    public int? SemaineExport { get; set; }

    public string? CmrNumero { get; set; }

    public string? CodeDeviseStation { get; set; }

    public decimal? CoursDeviseStation { get; set; }

    public decimal? MontantStation { get; set; }

    public string? NomChauffeur { get; set; }

    public string? TelChauffeur { get; set; }

    public short? EtatDossierStation { get; set; }

    public string? Remarque { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Conteneur Conteneur { get; set; } = null!;

    public virtual ICollection<PalettesExport> PalettesExports { get; set; } = new List<PalettesExport>();

    public virtual Station Station { get; set; } = null!;
}
