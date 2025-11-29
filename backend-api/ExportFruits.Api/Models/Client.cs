using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class Client
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string? AdresseFacturation { get; set; }

    public string? AdresseLivraison { get; set; }

    public string? Ville { get; set; }

    public string Pays { get; set; } = null!;

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public string? ContactPrincipal { get; set; }

    public string TypeClient { get; set; } = null!;

    public uint? DeviseDefautId { get; set; }

    public uint? IncotermDefautId { get; set; }

    public int? DelaiPaiementJours { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Devise? DeviseDefaut { get; set; }

    public virtual ICollection<Expedition> Expeditions { get; set; } = new List<Expedition>();

    public virtual ICollection<FacturesFinale> FacturesFinales { get; set; } = new List<FacturesFinale>();

    public virtual ICollection<FacturesProforma> FacturesProformas { get; set; } = new List<FacturesProforma>();

    public virtual Incoterm? IncotermDefaut { get; set; }
}
