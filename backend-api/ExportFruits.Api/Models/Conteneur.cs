using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Conteneur
{
    public uint Id { get; set; }

    public uint SocieteExportId { get; set; }

    public uint? ExpeditionId { get; set; }

    public string NumeroConteneur { get; set; } = null!;

    public string? TypeTransport { get; set; }

    public DateOnly? DateDepart { get; set; }

    public DateOnly? DateArrivee { get; set; }

    public string? PortDepart { get; set; }

    public string? PortArrivee { get; set; }

    public string? Navire { get; set; }

    public string? NumeroPlomb { get; set; }

    public uint? TransitaireId { get; set; }

    public uint? TransporteurId { get; set; }

    public int? TemperatureCharge { get; set; }

    public string? DocumentDouanier { get; set; }

    public string? TypeDossier { get; set; }

    public string? Remarque { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<DossiersExport> DossiersExports { get; set; } = new List<DossiersExport>();

    public virtual Expedition? Expedition { get; set; }

    public virtual ICollection<FacturesFinalesLigne> FacturesFinalesLignes { get; set; } = new List<FacturesFinalesLigne>();

    public virtual SocietesExport SocieteExport { get; set; } = null!;

    public virtual Fournisseur? Transitaire { get; set; }

    public virtual Fournisseur? Transporteur { get; set; }
}
