using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Calibre
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Libelle { get; set; } = null!;

    public int? Ordre { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
