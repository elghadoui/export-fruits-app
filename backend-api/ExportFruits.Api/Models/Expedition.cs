using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Expedition
{
    public uint Id { get; set; }

    public string Numero { get; set; } = null!;

    public uint SocieteExportId { get; set; }

    public uint ClientId { get; set; }

    public uint? CampagneId { get; set; }

    public uint? IncotermId { get; set; }

    public DateOnly DateExpedition { get; set; }

    public string? ReferenceClient { get; set; }

    public string? Commentaire { get; set; }

    public string Statut { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Campagne? Campagne { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Conteneur> Conteneurs { get; set; } = new List<Conteneur>();

    public virtual ICollection<FacturesFinale> FacturesFinales { get; set; } = new List<FacturesFinale>();

    public virtual ICollection<FacturesProforma> FacturesProformas { get; set; } = new List<FacturesProforma>();

    public virtual Incoterm? Incoterm { get; set; }

    public virtual SocietesExport SocieteExport { get; set; } = null!;
}
