using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Devise
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Symbole { get; set; }

    public string Libelle { get; set; } = null!;

    public decimal? TauxDefaut { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Banque> Banques { get; set; } = new List<Banque>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<FacturesFinale> FacturesFinales { get; set; } = new List<FacturesFinale>();

    public virtual ICollection<FacturesProforma> FacturesProformas { get; set; } = new List<FacturesProforma>();
}
