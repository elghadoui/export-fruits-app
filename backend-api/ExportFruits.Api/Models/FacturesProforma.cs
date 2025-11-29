using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class FacturesProforma
{
    public uint Id { get; set; }

    public string Numero { get; set; } = null!;

    public int Version { get; set; }

    public string TypeVersion { get; set; } = null!;

    public uint SocieteExportId { get; set; }

    public uint ClientId { get; set; }

    public uint? CampagneId { get; set; }

    public uint DeviseId { get; set; }

    public uint? IncotermId { get; set; }

    public uint? ExpeditionId { get; set; }

    public DateOnly DateProforma { get; set; }

    public string? ReferenceClient { get; set; }

    public string? Commentaire { get; set; }

    public decimal TauxChange { get; set; }

    public string Statut { get; set; } = null!;

    public uint? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Campagne? Campagne { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Devise Devise { get; set; } = null!;

    public virtual Expedition? Expedition { get; set; }

    public virtual ICollection<FacturesFinale> FacturesFinales { get; set; } = new List<FacturesFinale>();

    public virtual ICollection<FacturesProformaLigne> FacturesProformaLignes { get; set; } = new List<FacturesProformaLigne>();

    public virtual Incoterm? Incoterm { get; set; }

    public virtual SocietesExport SocieteExport { get; set; } = null!;
}
