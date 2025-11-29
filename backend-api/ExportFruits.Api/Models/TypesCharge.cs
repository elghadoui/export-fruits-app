using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class TypesCharge
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Libelle { get; set; } = null!;

    public string? Description { get; set; }

    public string Nature { get; set; } = null!;

    public string? UniteCalculDefaut { get; set; }

    public int? OrdreAffichage { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
