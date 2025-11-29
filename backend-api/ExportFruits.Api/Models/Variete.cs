using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Variete
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Famille { get; set; } = null!;

    public string? TypeProduit { get; set; }

    public int? CodeStationDiaf { get; set; }

    public int? CodeStationZaouia { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<FacturesFinalesLigne> FacturesFinalesLignes { get; set; } = new List<FacturesFinalesLigne>();

    public virtual ICollection<FacturesProformaLigne> FacturesProformaLignes { get; set; } = new List<FacturesProformaLigne>();
}
