using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Banque
{
    public uint Id { get; set; }

    public uint SocieteExportId { get; set; }

    public string NomBanque { get; set; } = null!;

    public string? Agence { get; set; }

    public string? Swift { get; set; }

    public string Rib { get; set; } = null!;

    public string? Iban { get; set; }

    public uint? DeviseId { get; set; }

    public bool EstPrincipale { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Devise? Devise { get; set; }

    public virtual SocietesExport SocieteExport { get; set; } = null!;
}
