// Models/SocieteExport.cs
using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models
{
    public class SocieteExport
    {
        public int Id { get; set; }                      // id
        public string Code { get; set; } = null!;        // code
        public string Nom { get; set; } = null!;         // nom

        public string? Rc { get; set; }                  // rc
        public string? Ice { get; set; }                 // ice
        public string? Adresse { get; set; }             // adresse
        public string? Ville { get; set; }               // ville
        public string? Pays { get; set; }                // pays
        public string? Telephone { get; set; }           // telephone
        public string? Email { get; set; }               // email

        public string? CocPrefix { get; set; }           // coc_prefix
        public string? LogoPath { get; set; }            // logo_path

        // Banque
        public string? BanqueNom { get; set; }           // banque_nom
        public string? BanqueSwift { get; set; }         // banque_swift
        public string? BanqueRib { get; set; }           // banque_rib
        public string? BanqueAgence { get; set; }        // banque_agence

        public bool Actif { get; set; } = true;          // actif

        public DateTime CreatedAt { get; set; }          // created_at
        public DateTime UpdatedAt { get; set; }          // updated_at

        // Navigation
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<StationExporteur> StationExporteurs { get; set; } = new List<StationExporteur>();
    }
}
