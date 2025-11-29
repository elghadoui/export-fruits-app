using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class SocietesExport
{
    public uint Id { get; set; }

    public string Code { get; set; } = null!;

    public string RaisonSociale { get; set; } = null!;

    public string? Rc { get; set; }

    public string? Ice { get; set; }

    public string? Adresse { get; set; }

    public string? Ville { get; set; }

    public string Pays { get; set; } = null!;

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Banque> Banques { get; set; } = new List<Banque>();

    public virtual ICollection<Campagne> Campagnes { get; set; } = new List<Campagne>();

    public virtual ICollection<Conteneur> Conteneurs { get; set; } = new List<Conteneur>();

    public virtual ICollection<Expedition> Expeditions { get; set; } = new List<Expedition>();

    public virtual ICollection<FacturesFinale> FacturesFinales { get; set; } = new List<FacturesFinale>();

    public virtual ICollection<FacturesProforma> FacturesProformas { get; set; } = new List<FacturesProforma>();

    public virtual ICollection<StationExporteur> StationExporteurs { get; set; } = new List<StationExporteur>();
}
