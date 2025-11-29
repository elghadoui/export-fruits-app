using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class FacturesProformaLigne
{
    public uint Id { get; set; }

    public uint ProformaId { get; set; }

    public uint VarieteId { get; set; }

    public uint? CalibreId { get; set; }

    public string? Emballage { get; set; }

    public string? Marque { get; set; }

    public string? Categorie { get; set; }

    public uint? QuantiteColis { get; set; }

    public decimal? PoidsPrevuKg { get; set; }

    public decimal PrixUnitaire { get; set; }

    public string ModePrix { get; set; } = null!;

    public decimal MontantLigneDevise { get; set; }

    public uint? OrdreAffichage { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual FacturesProforma Proforma { get; set; } = null!;

    public virtual Variete Variete { get; set; } = null!;
}
