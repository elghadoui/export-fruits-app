// Models/Client.cs
using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models
{
    public class Client
    {
        public int Id { get; set; }                      // id
        public string Code { get; set; } = null!;        // code
        public string Nom { get; set; } = null!;         // nom

        public string? AdresseFacturation { get; set; }  // adresse_facturation
        public string? AdresseLivraison { get; set; }    // adresse_livraison
        public string? Ville { get; set; }               // ville
        public string? Pays { get; set; }                // pays
        public string? Telephone { get; set; }           // telephone
        public string? Email { get; set; }               // email
        public string? ContactPrincipal { get; set; }    // contact_principal

        public string? IncotermDefaut { get; set; }      // incoterm_defaut
        public int? DeviseDefautId { get; set; }         // devise_defaut_id
        public int DelaiPaiementJours { get; set; }      // delai_paiement_jours

        public bool Actif { get; set; } = true;          // actif

        public DateTime CreatedAt { get; set; }          // created_at
        public DateTime UpdatedAt { get; set; }          // updated_at

        // FK (optionnel) vers SocieteExport principal si tu veux
        public int? SocieteExportId { get; set; }
        public SocieteExport? SocieteExport { get; set; }
    }
}
