using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class PalettesLigne
{
    public uint Id { get; set; }

    public uint PaletteId { get; set; }

    public uint VarieteId { get; set; }

    public uint? CalibreId { get; set; }

    public uint? VergerId { get; set; }

    public string? Emballage { get; set; }

    public string? Categorie { get; set; }

    public string? Marque { get; set; }

    public uint? NbrColis { get; set; }

    public uint? NbrFruits { get; set; }

    public string? Suffixe { get; set; }

    public decimal? PoidsNetKg { get; set; }

    public decimal? PoidsBrutKg { get; set; }

    public decimal? PoidsFacturableKg { get; set; }

    public string? IdBaseExport { get; set; }

    public string? StationCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<FacturesFinalesLigne> FacturesFinalesLignes { get; set; } = new List<FacturesFinalesLigne>();

    public virtual PalettesExport Palette { get; set; } = null!;
}
