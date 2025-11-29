using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class FacturesFinale
{
    public uint Id { get; set; }

    public string Numero { get; set; } = null!;

    public uint SocieteExportId { get; set; }

    public uint ClientId { get; set; }

    public uint? CampagneId { get; set; }

    public uint DeviseId { get; set; }

    public uint? IncotermId { get; set; }

    public uint? ExpeditionId { get; set; }

    public string ModeFacturation { get; set; } = null!;

    public DateOnly DateFacture { get; set; }

    public DateOnly? DateEcheance { get; set; }

    public decimal TauxChangeFacture { get; set; }

    public decimal? TauxChangeFinal { get; set; }

    public decimal MontantBrutDevise { get; set; }

    public decimal MontantAvoirsDevise { get; set; }

    public decimal MontantNetDevise { get; set; }

    public decimal MontantNetMad { get; set; }

    public string Statut { get; set; } = null!;

    public string? ReferenceClient { get; set; }

    public string? Commentaire { get; set; }

    public uint? ProformaId { get; set; }

    public uint? CreatedBy { get; set; }

    public uint? ValidatedBy { get; set; }

    public DateTime? ValidatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Campagne? Campagne { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Devise Devise { get; set; } = null!;

    public virtual Expedition? Expedition { get; set; }

    public virtual ICollection<FacturesFinalesLigne> FacturesFinalesLignes { get; set; } = new List<FacturesFinalesLigne>();

    public virtual Incoterm? Incoterm { get; set; }

    public virtual FacturesProforma? Proforma { get; set; }

    public virtual SocietesExport SocieteExport { get; set; } = null!;
}
