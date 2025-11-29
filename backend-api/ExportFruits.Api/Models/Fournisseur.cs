using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Fournisseur
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string TypeFournisseur { get; set; } = null!;

    public string? Adresse { get; set; }

    public string? Ville { get; set; }

    public string Pays { get; set; } = null!;

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Conteneur> ConteneurTransitaires { get; set; } = new List<Conteneur>();

    public virtual ICollection<Conteneur> ConteneurTransporteurs { get; set; } = new List<Conteneur>();
}
