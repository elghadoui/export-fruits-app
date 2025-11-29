using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Verger
{
    public uint Id { get; set; }

    public uint StationId { get; set; }

    public int RefverStation { get; set; }

    public string? Code { get; set; }

    public string Nom { get; set; } = null!;

    public string? Proprietaire { get; set; }

    public string? Localisation { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Station Station { get; set; } = null!;
}
