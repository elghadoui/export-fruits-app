using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class BaseExport
{
    public string IdUnique { get; set; } = null!;

    public string? Numpal { get; set; }

    public string? Station { get; set; }

    public string? Numdos { get; set; }

    public string? Refexp { get; set; }

    public string? Exportateur { get; set; }

    public string? Idclient { get; set; }

    public string? Clients { get; set; }

    public string? Idtransitaire { get; set; }

    public string? Nomtransitaire { get; set; }

    public string? Idtransporteur { get; set; }

    public string? Transporteur { get; set; }

    public string? NumeroConteneur { get; set; }

    public string? TypeTransport { get; set; }

    public int? SemaineExport { get; set; }

    public string? CmrNumero { get; set; }

    public DateOnly? DateDepart { get; set; }

    public DateOnly? DateArrive { get; set; }

    public string? PortDepart { get; set; }

    public string? Navire { get; set; }

    public string? NumeroPlomb { get; set; }

    public decimal? TemperatureCharge { get; set; }

    public string? DocumentDouanier { get; set; }

    public string? TypeDossier { get; set; }

    public string? CodeDeviseStation { get; set; }

    public decimal? MontantStation { get; set; }

    public string? NomChauffeur { get; set; }

    public string? TelChauffeur { get; set; }

    public string? Remarque { get; set; }

    public string? Numbdq { get; set; }

    public string? RefvergerReel { get; set; }

    public string? RefvergDeclarer { get; set; }

    public string? Codvar { get; set; }

    public string? CodvarDeclarer { get; set; }

    public string? NomVariete { get; set; }

    public string? Codemballage { get; set; }

    public string? Emballage { get; set; }

    public int? Nbrcoliparpalette { get; set; }

    public int? NombreColis { get; set; }

    public int? NbrFruit { get; set; }

    public decimal? Calibre { get; set; }

    public string? Sufix { get; set; }

    public decimal? Pdexport { get; set; }

    public decimal? Dpsbrut { get; set; }

    public decimal? PrixIni { get; set; }

    public string? Categorieexp { get; set; }

    public string? Codmarque { get; set; }

    public string? NomMarque { get; set; }

    public DateTime? DateImport { get; set; }
}
