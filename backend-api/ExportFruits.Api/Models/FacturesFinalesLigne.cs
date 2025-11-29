using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class FacturesFinalesLigne
{
    public uint Id { get; set; }

    public uint FactureId { get; set; }

    public uint? ConteneurId { get; set; }

    public uint? PaletteLigneId { get; set; }

    public uint VarieteId { get; set; }

    public uint? VergerId { get; set; }

    public string? Emballage { get; set; }

    public string? Categorie { get; set; }

    public string? Marque { get; set; }

    public uint? NombreColis { get; set; }

    public decimal PoidsFactureKg { get; set; }

    public decimal PrixUnitaire { get; set; }

    public string ModePrix { get; set; } = null!;

    public decimal MontantDevise { get; set; }

    public decimal MontantMad { get; set; }

    public uint? OrdreAffichage { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Conteneur? Conteneur { get; set; }

    public virtual FacturesFinale Facture { get; set; } = null!;

    public virtual PalettesLigne? PaletteLigne { get; set; }

    public virtual Variete Variete { get; set; } = null!;
}
