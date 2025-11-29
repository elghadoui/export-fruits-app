using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Incoterm
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Libelle { get; set; } = null!;

    public string? Description { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Expedition> Expeditions { get; set; } = new List<Expedition>();

    public virtual ICollection<FacturesFinale> FacturesFinales { get; set; } = new List<FacturesFinale>();

    public virtual ICollection<FacturesProforma> FacturesProformas { get; set; } = new List<FacturesProforma>();
}
