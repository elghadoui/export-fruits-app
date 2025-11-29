using System;
using System.Collections.Generic;
using ExportFruits.Api.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ExportFruits.Api.Data;

public partial class ExportDbContext : DbContext
{
    public ExportDbContext()
    {
    }

    public ExportDbContext(DbContextOptions<ExportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banque> Banques { get; set; }

    public virtual DbSet<BaseExport> BaseExports { get; set; }

    public virtual DbSet<Calibre> Calibres { get; set; }

    public virtual DbSet<Campagne> Campagnes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Conteneur> Conteneurs { get; set; }

    public virtual DbSet<Devise> Devises { get; set; }

    public virtual DbSet<DossiersExport> DossiersExports { get; set; }

    public virtual DbSet<Expedition> Expeditions { get; set; }

    public virtual DbSet<FacturesFinale> FacturesFinales { get; set; }

    public virtual DbSet<FacturesFinalesLigne> FacturesFinalesLignes { get; set; }

    public virtual DbSet<FacturesProforma> FacturesProformas { get; set; }

    public virtual DbSet<FacturesProformaLigne> FacturesProformaLignes { get; set; }

    public virtual DbSet<Fournisseur> Fournisseurs { get; set; }

    public virtual DbSet<Incoterm> Incoterms { get; set; }

    public virtual DbSet<PalettesExport> PalettesExports { get; set; }

    public virtual DbSet<PalettesLigne> PalettesLignes { get; set; }

    public virtual DbSet<SocietesExport> SocietesExports { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<StationExporteur> StationExporteurs { get; set; }

    public virtual DbSet<TypesCharge> TypesCharges { get; set; }

    public virtual DbSet<Variete> Varietes { get; set; }

    public virtual DbSet<Verger> Vergers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=export_db;user=abdo;password=123;treattinyasboolean=true;connectiontimeout=600;defaultcommandtimeout=600", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_bin")
            .HasCharSet("utf8");

        modelBuilder.Entity<Banque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("banques")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.DeviseId, "fk_banques_devise");

            entity.HasIndex(e => e.NomBanque, "idx_banques_nom");

            entity.HasIndex(e => e.SocieteExportId, "idx_banques_societe");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Agence)
                .HasMaxLength(150)
                .HasColumnName("agence");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("devise_id");
            entity.Property(e => e.EstPrincipale).HasColumnName("est_principale");
            entity.Property(e => e.Iban)
                .HasMaxLength(50)
                .HasColumnName("iban");
            entity.Property(e => e.NomBanque)
                .HasMaxLength(200)
                .HasColumnName("nom_banque");
            entity.Property(e => e.Rib)
                .HasMaxLength(50)
                .HasColumnName("rib");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.Swift)
                .HasMaxLength(20)
                .HasColumnName("swift");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Devise).WithMany(p => p.Banques)
                .HasForeignKey(d => d.DeviseId)
                .HasConstraintName("fk_banques_devise");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.Banques)
                .HasForeignKey(d => d.SocieteExportId)
                .HasConstraintName("fk_banques_societe");
        });

        modelBuilder.Entity<BaseExport>(entity =>
        {
            entity.HasKey(e => e.IdUnique).HasName("PRIMARY");

            entity.ToTable("base_export");

            entity.Property(e => e.IdUnique)
                .HasMaxLength(100)
                .HasColumnName("id_unique");
            entity.Property(e => e.Calibre)
                .HasPrecision(10, 2)
                .HasColumnName("calibre");
            entity.Property(e => e.Categorieexp)
                .HasMaxLength(10)
                .HasColumnName("categorieexp");
            entity.Property(e => e.Clients)
                .HasMaxLength(255)
                .HasColumnName("clients");
            entity.Property(e => e.CmrNumero)
                .HasMaxLength(50)
                .HasColumnName("cmr_numero");
            entity.Property(e => e.CodeDeviseStation)
                .HasMaxLength(10)
                .HasColumnName("code_devise_station");
            entity.Property(e => e.Codemballage)
                .HasMaxLength(50)
                .HasColumnName("codemballage");
            entity.Property(e => e.Codmarque)
                .HasMaxLength(50)
                .HasColumnName("codmarque");
            entity.Property(e => e.Codvar)
                .HasMaxLength(50)
                .HasColumnName("codvar");
            entity.Property(e => e.CodvarDeclarer)
                .HasMaxLength(50)
                .HasColumnName("codvar_declarer");
            entity.Property(e => e.DateArrive).HasColumnName("date_arrive");
            entity.Property(e => e.DateDepart).HasColumnName("date_depart");
            entity.Property(e => e.DateImport)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("date_import");
            entity.Property(e => e.DocumentDouanier)
                .HasMaxLength(100)
                .HasColumnName("document_douanier");
            entity.Property(e => e.Dpsbrut)
                .HasPrecision(15, 2)
                .HasColumnName("dpsbrut");
            entity.Property(e => e.Emballage)
                .HasMaxLength(100)
                .HasColumnName("emballage");
            entity.Property(e => e.Exportateur)
                .HasMaxLength(255)
                .HasColumnName("exportateur");
            entity.Property(e => e.Idclient)
                .HasMaxLength(50)
                .HasColumnName("idclient");
            entity.Property(e => e.Idtransitaire)
                .HasMaxLength(50)
                .HasColumnName("idtransitaire");
            entity.Property(e => e.Idtransporteur)
                .HasMaxLength(50)
                .HasColumnName("idtransporteur");
            entity.Property(e => e.MontantStation)
                .HasPrecision(15, 2)
                .HasColumnName("montant_station");
            entity.Property(e => e.Navire)
                .HasMaxLength(100)
                .HasColumnName("navire");
            entity.Property(e => e.NbrFruit)
                .HasColumnType("int(11)")
                .HasColumnName("nbrFruit");
            entity.Property(e => e.Nbrcoliparpalette)
                .HasColumnType("int(11)")
                .HasColumnName("nbrcoliparpalette");
            entity.Property(e => e.NomChauffeur)
                .HasMaxLength(100)
                .HasColumnName("nom_chauffeur");
            entity.Property(e => e.NomMarque)
                .HasMaxLength(255)
                .HasColumnName("nomMarque");
            entity.Property(e => e.NomVariete)
                .HasMaxLength(255)
                .HasColumnName("nom_variete");
            entity.Property(e => e.NombreColis)
                .HasColumnType("int(11)")
                .HasColumnName("nombre_colis");
            entity.Property(e => e.Nomtransitaire)
                .HasMaxLength(255)
                .HasColumnName("nomtransitaire");
            entity.Property(e => e.Numbdq)
                .HasMaxLength(50)
                .HasColumnName("numbdq");
            entity.Property(e => e.Numdos)
                .HasMaxLength(50)
                .HasColumnName("numdos");
            entity.Property(e => e.NumeroConteneur)
                .HasMaxLength(50)
                .HasColumnName("numero_conteneur");
            entity.Property(e => e.NumeroPlomb)
                .HasMaxLength(50)
                .HasColumnName("numero_plomb");
            entity.Property(e => e.Numpal)
                .HasMaxLength(50)
                .HasColumnName("numpal");
            entity.Property(e => e.Pdexport)
                .HasPrecision(15, 2)
                .HasColumnName("pdexport");
            entity.Property(e => e.PortDepart)
                .HasMaxLength(100)
                .HasColumnName("port_depart");
            entity.Property(e => e.PrixIni)
                .HasPrecision(15, 2)
                .HasColumnName("prixIni");
            entity.Property(e => e.Refexp)
                .HasMaxLength(50)
                .HasColumnName("refexp");
            entity.Property(e => e.RefvergDeclarer)
                .HasMaxLength(50)
                .HasColumnName("refverg_declarer");
            entity.Property(e => e.RefvergerReel)
                .HasMaxLength(50)
                .HasColumnName("refverger_reel");
            entity.Property(e => e.Remarque)
                .HasColumnType("text")
                .HasColumnName("remarque");
            entity.Property(e => e.SemaineExport)
                .HasColumnType("int(11)")
                .HasColumnName("semaine_export");
            entity.Property(e => e.Station)
                .HasMaxLength(10)
                .HasColumnName("station");
            entity.Property(e => e.Sufix).HasMaxLength(10);
            entity.Property(e => e.TelChauffeur)
                .HasMaxLength(50)
                .HasColumnName("tel_chauffeur");
            entity.Property(e => e.TemperatureCharge)
                .HasPrecision(10, 2)
                .HasColumnName("temperature_charge");
            entity.Property(e => e.Transporteur)
                .HasMaxLength(255)
                .HasColumnName("transporteur");
            entity.Property(e => e.TypeDossier)
                .HasMaxLength(50)
                .HasColumnName("type_dossier");
            entity.Property(e => e.TypeTransport)
                .HasMaxLength(50)
                .HasColumnName("type_transport");
        });

        modelBuilder.Entity<Calibre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("calibres")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Ordre, "idx_calibres_ordre");

            entity.HasIndex(e => e.Code, "uq_calibres_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
            entity.Property(e => e.Ordre)
                .HasColumnType("int(11)")
                .HasColumnName("ordre");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Campagne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("campagnes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => new { e.DateDebut, e.DateFin }, "idx_campagnes_periode");

            entity.HasIndex(e => new { e.SocieteExportId, e.Code }, "uq_campagnes_societe_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateDebut).HasColumnName("date_debut");
            entity.Property(e => e.DateFin).HasColumnName("date_fin");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.Campagnes)
                .HasForeignKey(d => d.SocieteExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_campagnes_societe");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("clients")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.DeviseDefautId, "fk_clients_devise");

            entity.HasIndex(e => e.IncotermDefautId, "fk_clients_incoterm");

            entity.HasIndex(e => e.Nom, "idx_clients_nom");

            entity.HasIndex(e => e.Pays, "idx_clients_pays");

            entity.HasIndex(e => e.Code, "uq_clients_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.AdresseFacturation)
                .HasMaxLength(255)
                .HasColumnName("adresse_facturation");
            entity.Property(e => e.AdresseLivraison)
                .HasMaxLength(255)
                .HasColumnName("adresse_livraison");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.ContactPrincipal)
                .HasMaxLength(100)
                .HasColumnName("contact_principal");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DelaiPaiementJours)
                .HasDefaultValueSql("'30'")
                .HasColumnType("int(11)")
                .HasColumnName("delai_paiement_jours");
            entity.Property(e => e.DeviseDefautId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("devise_defaut_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IncotermDefautId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("incoterm_defaut_id");
            entity.Property(e => e.Nom)
                .HasMaxLength(200)
                .HasColumnName("nom");
            entity.Property(e => e.Pays)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Espagne'")
                .HasColumnName("pays");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
            entity.Property(e => e.TypeClient)
                .HasDefaultValueSql("'AUTRE'")
                .HasColumnType("enum('GMS','IMPORTATEUR','GROSSISTE','AUTRE')")
                .HasColumnName("type_client");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Ville)
                .HasMaxLength(100)
                .HasColumnName("ville");

            entity.HasOne(d => d.DeviseDefaut).WithMany(p => p.Clients)
                .HasForeignKey(d => d.DeviseDefautId)
                .HasConstraintName("fk_clients_devise");

            entity.HasOne(d => d.IncotermDefaut).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IncotermDefautId)
                .HasConstraintName("fk_clients_incoterm");
        });

        modelBuilder.Entity<Conteneur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("conteneurs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.TransitaireId, "fk_cont_transitaire");

            entity.HasIndex(e => e.TransporteurId, "fk_cont_transporteur");

            entity.HasIndex(e => e.DateDepart, "idx_cont_date");

            entity.HasIndex(e => e.NumeroConteneur, "idx_cont_numero");

            entity.HasIndex(e => e.ExpeditionId, "idx_conteneurs_expedition");

            entity.HasIndex(e => new { e.SocieteExportId, e.NumeroConteneur, e.DateDepart }, "uq_cont_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateArrivee).HasColumnName("date_arrivee");
            entity.Property(e => e.DateDepart).HasColumnName("date_depart");
            entity.Property(e => e.DocumentDouanier)
                .HasMaxLength(20)
                .HasColumnName("document_douanier");
            entity.Property(e => e.ExpeditionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("expedition_id");
            entity.Property(e => e.Navire)
                .HasMaxLength(50)
                .HasColumnName("navire");
            entity.Property(e => e.NumeroConteneur)
                .HasMaxLength(30)
                .HasColumnName("numero_conteneur");
            entity.Property(e => e.NumeroPlomb)
                .HasMaxLength(30)
                .HasColumnName("numero_plomb");
            entity.Property(e => e.PortArrivee)
                .HasMaxLength(100)
                .HasColumnName("port_arrivee");
            entity.Property(e => e.PortDepart)
                .HasMaxLength(100)
                .HasColumnName("port_depart");
            entity.Property(e => e.Remarque)
                .HasMaxLength(255)
                .HasColumnName("remarque");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.TemperatureCharge)
                .HasColumnType("int(11)")
                .HasColumnName("temperature_charge");
            entity.Property(e => e.TransitaireId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("transitaire_id");
            entity.Property(e => e.TransporteurId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("transporteur_id");
            entity.Property(e => e.TypeDossier)
                .HasMaxLength(5)
                .HasColumnName("type_dossier");
            entity.Property(e => e.TypeTransport)
                .HasMaxLength(10)
                .HasColumnName("type_transport");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Expedition).WithMany(p => p.Conteneurs)
                .HasForeignKey(d => d.ExpeditionId)
                .HasConstraintName("fk_conteneurs_expedition");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.Conteneurs)
                .HasForeignKey(d => d.SocieteExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cont_societe");

            entity.HasOne(d => d.Transitaire).WithMany(p => p.ConteneurTransitaires)
                .HasForeignKey(d => d.TransitaireId)
                .HasConstraintName("fk_cont_transitaire");

            entity.HasOne(d => d.Transporteur).WithMany(p => p.ConteneurTransporteurs)
                .HasForeignKey(d => d.TransporteurId)
                .HasConstraintName("fk_cont_transporteur");
        });

        modelBuilder.Entity<Devise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("devises")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Code, "uq_devises_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .HasColumnName("libelle");
            entity.Property(e => e.Symbole)
                .HasMaxLength(10)
                .HasColumnName("symbole");
            entity.Property(e => e.TauxDefaut)
                .HasPrecision(10, 4)
                .HasColumnName("taux_defaut");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DossiersExport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("dossiers_export")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ConteneurId, "idx_dos_conteneur");

            entity.HasIndex(e => e.SemaineExport, "idx_dos_semaine");

            entity.HasIndex(e => new { e.StationId, e.NumdosStation }, "uq_dos_station_numdos").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CmrNumero)
                .HasMaxLength(20)
                .HasColumnName("cmr_numero");
            entity.Property(e => e.CodeDeviseStation)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("code_devise_station");
            entity.Property(e => e.ConteneurId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("conteneur_id");
            entity.Property(e => e.CoursDeviseStation)
                .HasPrecision(16, 4)
                .HasColumnName("cours_devise_station");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateDossier).HasColumnName("date_dossier");
            entity.Property(e => e.EtatDossierStation)
                .HasColumnType("smallint(6)")
                .HasColumnName("etat_dossier_station");
            entity.Property(e => e.MontantStation)
                .HasPrecision(16, 2)
                .HasColumnName("montant_station");
            entity.Property(e => e.NomChauffeur)
                .HasMaxLength(50)
                .HasColumnName("nom_chauffeur");
            entity.Property(e => e.NumdosStation)
                .HasColumnType("int(11)")
                .HasColumnName("numdos_station");
            entity.Property(e => e.Remarque)
                .HasMaxLength(255)
                .HasColumnName("remarque");
            entity.Property(e => e.SemaineExport)
                .HasColumnType("int(11)")
                .HasColumnName("semaine_export");
            entity.Property(e => e.StationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("station_id");
            entity.Property(e => e.TelChauffeur)
                .HasMaxLength(20)
                .HasColumnName("tel_chauffeur");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Conteneur).WithMany(p => p.DossiersExports)
                .HasForeignKey(d => d.ConteneurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dos_conteneur");

            entity.HasOne(d => d.Station).WithMany(p => p.DossiersExports)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dos_station");
        });

        modelBuilder.Entity<Expedition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("expeditions")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.CampagneId, "fk_expeditions_campagne");

            entity.HasIndex(e => e.IncotermId, "fk_expeditions_incoterm");

            entity.HasIndex(e => e.SocieteExportId, "fk_expeditions_societe");

            entity.HasIndex(e => e.ClientId, "idx_expeditions_client");

            entity.HasIndex(e => e.DateExpedition, "idx_expeditions_date");

            entity.HasIndex(e => e.Statut, "idx_expeditions_statut");

            entity.HasIndex(e => e.Numero, "uq_expeditions_numero").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CampagneId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("campagne_id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("client_id");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateExpedition).HasColumnName("date_expedition");
            entity.Property(e => e.IncotermId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("incoterm_id");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");
            entity.Property(e => e.ReferenceClient)
                .HasMaxLength(50)
                .HasColumnName("reference_client");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.Statut)
                .HasDefaultValueSql("'BROUILLON'")
                .HasColumnType("enum('BROUILLON','CONFIRMEE','PARTIELLEMENT_FACTUREE','FACTUREE','CLOTUREE')")
                .HasColumnName("statut");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Campagne).WithMany(p => p.Expeditions)
                .HasForeignKey(d => d.CampagneId)
                .HasConstraintName("fk_expeditions_campagne");

            entity.HasOne(d => d.Client).WithMany(p => p.Expeditions)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_expeditions_client");

            entity.HasOne(d => d.Incoterm).WithMany(p => p.Expeditions)
                .HasForeignKey(d => d.IncotermId)
                .HasConstraintName("fk_expeditions_incoterm");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.Expeditions)
                .HasForeignKey(d => d.SocieteExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_expeditions_societe");
        });

        modelBuilder.Entity<FacturesFinale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("factures_finales")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.CampagneId, "fk_ff_campagne");

            entity.HasIndex(e => e.DeviseId, "fk_ff_devise");

            entity.HasIndex(e => e.ExpeditionId, "fk_ff_expedition");

            entity.HasIndex(e => e.IncotermId, "fk_ff_incoterm");

            entity.HasIndex(e => e.ProformaId, "fk_ff_proforma");

            entity.HasIndex(e => e.SocieteExportId, "fk_ff_societe");

            entity.HasIndex(e => e.ClientId, "idx_ff_client");

            entity.HasIndex(e => e.DateFacture, "idx_ff_date");

            entity.HasIndex(e => e.Statut, "idx_ff_statut");

            entity.HasIndex(e => e.Numero, "uq_ff_numero").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CampagneId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("campagne_id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("client_id");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by");
            entity.Property(e => e.DateEcheance).HasColumnName("date_echeance");
            entity.Property(e => e.DateFacture).HasColumnName("date_facture");
            entity.Property(e => e.DeviseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("devise_id");
            entity.Property(e => e.ExpeditionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("expedition_id");
            entity.Property(e => e.IncotermId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("incoterm_id");
            entity.Property(e => e.ModeFacturation)
                .HasDefaultValueSql("'PAR_EXPEDITION'")
                .HasColumnType("enum('PAR_EXPEDITION','PAR_CONTENEUR','AUTRE')")
                .HasColumnName("mode_facturation");
            entity.Property(e => e.MontantAvoirsDevise)
                .HasPrecision(14, 2)
                .HasColumnName("montant_avoirs_devise");
            entity.Property(e => e.MontantBrutDevise)
                .HasPrecision(14, 2)
                .HasColumnName("montant_brut_devise");
            entity.Property(e => e.MontantNetDevise)
                .HasPrecision(14, 2)
                .HasColumnName("montant_net_devise");
            entity.Property(e => e.MontantNetMad)
                .HasPrecision(14, 2)
                .HasColumnName("montant_net_mad");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");
            entity.Property(e => e.ProformaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("proforma_id");
            entity.Property(e => e.ReferenceClient)
                .HasMaxLength(50)
                .HasColumnName("reference_client");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.Statut)
                .HasDefaultValueSql("'BROUILLON'")
                .HasColumnType("enum('BROUILLON','VALIDEE','PAYEE','PARTIELLEMENT_PAYEE')")
                .HasColumnName("statut");
            entity.Property(e => e.TauxChangeFacture)
                .HasPrecision(10, 4)
                .HasColumnName("taux_change_facture");
            entity.Property(e => e.TauxChangeFinal)
                .HasPrecision(10, 4)
                .HasColumnName("taux_change_final");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.ValidatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("validated_at");
            entity.Property(e => e.ValidatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("validated_by");

            entity.HasOne(d => d.Campagne).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.CampagneId)
                .HasConstraintName("fk_ff_campagne");

            entity.HasOne(d => d.Client).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ff_client");

            entity.HasOne(d => d.Devise).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.DeviseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ff_devise");

            entity.HasOne(d => d.Expedition).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.ExpeditionId)
                .HasConstraintName("fk_ff_expedition");

            entity.HasOne(d => d.Incoterm).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.IncotermId)
                .HasConstraintName("fk_ff_incoterm");

            entity.HasOne(d => d.Proforma).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.ProformaId)
                .HasConstraintName("fk_ff_proforma");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.FacturesFinales)
                .HasForeignKey(d => d.SocieteExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ff_societe");
        });

        modelBuilder.Entity<FacturesFinalesLigne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("factures_finales_lignes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.PaletteLigneId, "fk_ffl_palette_ligne");

            entity.HasIndex(e => e.ConteneurId, "idx_ffl_conteneur");

            entity.HasIndex(e => e.FactureId, "idx_ffl_facture");

            entity.HasIndex(e => e.VarieteId, "idx_ffl_variete");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Categorie)
                .HasMaxLength(10)
                .HasColumnName("categorie");
            entity.Property(e => e.ConteneurId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("conteneur_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Emballage)
                .HasMaxLength(100)
                .HasColumnName("emballage");
            entity.Property(e => e.FactureId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("facture_id");
            entity.Property(e => e.Marque)
                .HasMaxLength(100)
                .HasColumnName("marque");
            entity.Property(e => e.ModePrix)
                .HasDefaultValueSql("'PAR_KG'")
                .HasColumnType("enum('PAR_KG','PAR_COLIS')")
                .HasColumnName("mode_prix");
            entity.Property(e => e.MontantDevise)
                .HasPrecision(14, 2)
                .HasColumnName("montant_devise");
            entity.Property(e => e.MontantMad)
                .HasPrecision(14, 2)
                .HasColumnName("montant_mad");
            entity.Property(e => e.NombreColis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("nombre_colis");
            entity.Property(e => e.OrdreAffichage)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ordre_affichage");
            entity.Property(e => e.PaletteLigneId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("palette_ligne_id");
            entity.Property(e => e.PoidsFactureKg)
                .HasPrecision(12, 3)
                .HasColumnName("poids_facture_kg");
            entity.Property(e => e.PrixUnitaire)
                .HasPrecision(10, 4)
                .HasColumnName("prix_unitaire");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VarieteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("variete_id");
            entity.Property(e => e.VergerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("verger_id");

            entity.HasOne(d => d.Conteneur).WithMany(p => p.FacturesFinalesLignes)
                .HasForeignKey(d => d.ConteneurId)
                .HasConstraintName("fk_ffl_conteneur");

            entity.HasOne(d => d.Facture).WithMany(p => p.FacturesFinalesLignes)
                .HasForeignKey(d => d.FactureId)
                .HasConstraintName("fk_ffl_facture");

            entity.HasOne(d => d.PaletteLigne).WithMany(p => p.FacturesFinalesLignes)
                .HasForeignKey(d => d.PaletteLigneId)
                .HasConstraintName("fk_ffl_palette_ligne");

            entity.HasOne(d => d.Variete).WithMany(p => p.FacturesFinalesLignes)
                .HasForeignKey(d => d.VarieteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ffl_variete");
        });

        modelBuilder.Entity<FacturesProforma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("factures_proforma")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.CampagneId, "fk_pf_campagne");

            entity.HasIndex(e => e.DeviseId, "fk_pf_devise");

            entity.HasIndex(e => e.ExpeditionId, "fk_pf_expedition");

            entity.HasIndex(e => e.IncotermId, "fk_pf_incoterm");

            entity.HasIndex(e => e.SocieteExportId, "fk_pf_societe");

            entity.HasIndex(e => e.ClientId, "idx_pf_client");

            entity.HasIndex(e => e.DateProforma, "idx_pf_date");

            entity.HasIndex(e => e.Statut, "idx_pf_statut");

            entity.HasIndex(e => new { e.Numero, e.Version }, "uq_pf_num_version").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CampagneId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("campagne_id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("client_id");
            entity.Property(e => e.Commentaire)
                .HasMaxLength(255)
                .HasColumnName("commentaire");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("created_by");
            entity.Property(e => e.DateProforma).HasColumnName("date_proforma");
            entity.Property(e => e.DeviseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("devise_id");
            entity.Property(e => e.ExpeditionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("expedition_id");
            entity.Property(e => e.IncotermId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("incoterm_id");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");
            entity.Property(e => e.ReferenceClient)
                .HasMaxLength(50)
                .HasColumnName("reference_client");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.Statut)
                .HasDefaultValueSql("'BROUILLON'")
                .HasColumnType("enum('BROUILLON','VALIDE','ANNULEE')")
                .HasColumnName("statut");
            entity.Property(e => e.TauxChange)
                .HasPrecision(10, 4)
                .HasColumnName("taux_change");
            entity.Property(e => e.TypeVersion)
                .HasDefaultValueSql("'INITIALE'")
                .HasColumnType("enum('INITIALE','CONFIRMEE','REVISEE')")
                .HasColumnName("type_version");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Version)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("version");

            entity.HasOne(d => d.Campagne).WithMany(p => p.FacturesProformas)
                .HasForeignKey(d => d.CampagneId)
                .HasConstraintName("fk_pf_campagne");

            entity.HasOne(d => d.Client).WithMany(p => p.FacturesProformas)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pf_client");

            entity.HasOne(d => d.Devise).WithMany(p => p.FacturesProformas)
                .HasForeignKey(d => d.DeviseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pf_devise");

            entity.HasOne(d => d.Expedition).WithMany(p => p.FacturesProformas)
                .HasForeignKey(d => d.ExpeditionId)
                .HasConstraintName("fk_pf_expedition");

            entity.HasOne(d => d.Incoterm).WithMany(p => p.FacturesProformas)
                .HasForeignKey(d => d.IncotermId)
                .HasConstraintName("fk_pf_incoterm");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.FacturesProformas)
                .HasForeignKey(d => d.SocieteExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pf_societe");
        });

        modelBuilder.Entity<FacturesProformaLigne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("factures_proforma_lignes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ProformaId, "idx_pfl_proforma");

            entity.HasIndex(e => e.VarieteId, "idx_pfl_variete");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CalibreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("calibre_id");
            entity.Property(e => e.Categorie)
                .HasMaxLength(10)
                .HasColumnName("categorie");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Emballage)
                .HasMaxLength(100)
                .HasColumnName("emballage");
            entity.Property(e => e.Marque)
                .HasMaxLength(100)
                .HasColumnName("marque");
            entity.Property(e => e.ModePrix)
                .HasDefaultValueSql("'PAR_KG'")
                .HasColumnType("enum('PAR_KG','PAR_COLIS')")
                .HasColumnName("mode_prix");
            entity.Property(e => e.MontantLigneDevise)
                .HasPrecision(14, 2)
                .HasColumnName("montant_ligne_devise");
            entity.Property(e => e.OrdreAffichage)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ordre_affichage");
            entity.Property(e => e.PoidsPrevuKg)
                .HasPrecision(12, 3)
                .HasDefaultValueSql("'0.000'")
                .HasColumnName("poids_prevu_kg");
            entity.Property(e => e.PrixUnitaire)
                .HasPrecision(10, 4)
                .HasColumnName("prix_unitaire");
            entity.Property(e => e.ProformaId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("proforma_id");
            entity.Property(e => e.QuantiteColis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("quantite_colis");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VarieteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("variete_id");

            entity.HasOne(d => d.Proforma).WithMany(p => p.FacturesProformaLignes)
                .HasForeignKey(d => d.ProformaId)
                .HasConstraintName("fk_pfl_proforma");

            entity.HasOne(d => d.Variete).WithMany(p => p.FacturesProformaLignes)
                .HasForeignKey(d => d.VarieteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pfl_variete");
        });

        modelBuilder.Entity<Fournisseur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("fournisseurs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nom, "idx_fournisseurs_nom");

            entity.HasIndex(e => e.TypeFournisseur, "idx_fournisseurs_type");

            entity.HasIndex(e => e.Code, "uq_fournisseurs_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Adresse)
                .HasMaxLength(255)
                .HasColumnName("adresse");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(200)
                .HasColumnName("nom");
            entity.Property(e => e.Pays)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Maroc'")
                .HasColumnName("pays");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
            entity.Property(e => e.TypeFournisseur)
                .HasDefaultValueSql("'AUTRE'")
                .HasColumnType("enum('TRANSITAIRE','TRANSPORTEUR','STATION','AUTRE')")
                .HasColumnName("type_fournisseur");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Ville)
                .HasMaxLength(100)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<Incoterm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("incoterms")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Code, "uq_incoterms_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PalettesExport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("palettes_export")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.DossierId, "idx_pal_dossier");

            entity.HasIndex(e => new { e.StationId, e.NumpalStation }, "uq_pal_station_numpal").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DatePalette).HasColumnName("date_palette");
            entity.Property(e => e.DossierId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("dossier_id");
            entity.Property(e => e.NumpalStation)
                .HasColumnType("int(11)")
                .HasColumnName("numpal_station");
            entity.Property(e => e.StationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("station_id");
            entity.Property(e => e.StatutPalette)
                .HasDefaultValueSql("'DISPONIBLE'")
                .HasColumnType("enum('DISPONIBLE','EXPEDIEE','FACTUREE')")
                .HasColumnName("statut_palette");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Dossier).WithMany(p => p.PalettesExports)
                .HasForeignKey(d => d.DossierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pal_dossier");

            entity.HasOne(d => d.Station).WithMany(p => p.PalettesExports)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pal_station");
        });

        modelBuilder.Entity<PalettesLigne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("palettes_lignes");

            entity.HasIndex(e => e.PaletteId, "idx_palette");

            entity.HasIndex(e => e.StationCode, "idx_station");

            entity.HasIndex(e => e.VarieteId, "idx_variete");

            entity.HasIndex(e => e.VergerId, "idx_verger");

            entity.HasIndex(e => e.IdBaseExport, "uq_pl_id_base_export").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CalibreId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("calibre_id");
            entity.Property(e => e.Categorie)
                .HasMaxLength(10)
                .HasColumnName("categorie");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Emballage)
                .HasMaxLength(100)
                .HasColumnName("emballage");
            entity.Property(e => e.IdBaseExport)
                .HasMaxLength(100)
                .HasColumnName("id_base_export");
            entity.Property(e => e.Marque)
                .HasMaxLength(100)
                .HasColumnName("marque");
            entity.Property(e => e.NbrColis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("nbr_colis");
            entity.Property(e => e.NbrFruits)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("nbr_fruits");
            entity.Property(e => e.PaletteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("palette_id");
            entity.Property(e => e.PoidsBrutKg)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("poids_brut_kg");
            entity.Property(e => e.PoidsFacturableKg)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("poids_facturable_kg");
            entity.Property(e => e.PoidsNetKg)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("poids_net_kg");
            entity.Property(e => e.StationCode)
                .HasMaxLength(20)
                .HasColumnName("station_code");
            entity.Property(e => e.Suffixe)
                .HasMaxLength(10)
                .HasColumnName("suffixe");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VarieteId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("variete_id");
            entity.Property(e => e.VergerId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("verger_id");

            entity.HasOne(d => d.Palette).WithMany(p => p.PalettesLignes)
                .HasForeignKey(d => d.PaletteId)
                .HasConstraintName("fk_pl_palette");
        });

        modelBuilder.Entity<SocietesExport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("societes_export")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Code, "uq_societes_export_code").IsUnique();

            entity.HasIndex(e => e.Email, "uq_societes_export_email").IsUnique();

            entity.HasIndex(e => e.Ice, "uq_societes_export_ice").IsUnique();

            entity.HasIndex(e => e.Rc, "uq_societes_export_rc").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Adresse)
                .HasMaxLength(255)
                .HasColumnName("adresse");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Ice)
                .HasMaxLength(50)
                .HasColumnName("ice");
            entity.Property(e => e.Pays)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Maroc'")
                .HasColumnName("pays");
            entity.Property(e => e.RaisonSociale)
                .HasMaxLength(200)
                .HasColumnName("raison_sociale");
            entity.Property(e => e.Rc)
                .HasMaxLength(50)
                .HasColumnName("rc");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Ville)
                .HasMaxLength(100)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("stations")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.TypeStation, "idx_stations_type");

            entity.HasIndex(e => e.Code, "uq_stations_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Nom)
                .HasMaxLength(200)
                .HasColumnName("nom");
            entity.Property(e => e.Pays)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Maroc'")
                .HasColumnName("pays");
            entity.Property(e => e.TypeStation)
                .HasDefaultValueSql("'AUTRE'")
                .HasColumnType("enum('AGRUME','FRUIT_ROUGE','MIX','AUTRE')")
                .HasColumnName("type_station");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Ville)
                .HasMaxLength(100)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<StationExporteur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("station_exporteurs")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.SocieteExportId, "idx_se_societe");

            entity.HasIndex(e => new { e.StationId, e.CodeExportStation }, "uq_se_station_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.CodeExportStation)
                .HasColumnType("smallint(6)")
                .HasColumnName("code_export_station");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.SocieteExportId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("societe_export_id");
            entity.Property(e => e.StationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("station_id");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SocieteExport).WithMany(p => p.StationExporteurs)
                .HasForeignKey(d => d.SocieteExportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_se_societe");

            entity.HasOne(d => d.Station).WithMany(p => p.StationExporteurs)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_se_station");
        });

        modelBuilder.Entity<TypesCharge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("types_charges")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nature, "idx_types_charges_nature");

            entity.HasIndex(e => e.Code, "uq_types_charges_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
            entity.Property(e => e.Nature)
                .HasDefaultValueSql("'AUTRE'")
                .HasColumnType("enum('TRANSIT','TRANSPORT','EMBALLAGE','CONDITIONNEMENT','COMMISSION','AUTRE')")
                .HasColumnName("nature");
            entity.Property(e => e.OrdreAffichage)
                .HasColumnType("int(11)")
                .HasColumnName("ordre_affichage");
            entity.Property(e => e.UniteCalculDefaut)
                .HasColumnType("enum('PALETTE','CONTENEUR','COLIS','KG','POURCENT')")
                .HasColumnName("unite_calcul_defaut");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Variete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("varietes")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Famille, "idx_varietes_famille");

            entity.HasIndex(e => e.TypeProduit, "idx_varietes_type");

            entity.HasIndex(e => e.Code, "uq_varietes_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CodeStationDiaf)
                .HasColumnType("int(11)")
                .HasColumnName("code_station_diaf");
            entity.Property(e => e.CodeStationZaouia)
                .HasColumnType("int(11)")
                .HasColumnName("code_station_zaouia");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Famille)
                .HasDefaultValueSql("'AUTRE'")
                .HasColumnType("enum('AGRUME','FRUIT_ROUGE','AUTRE')")
                .HasColumnName("famille");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.TypeProduit)
                .HasMaxLength(50)
                .HasColumnName("type_produit");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Verger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vergers")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Nom, "idx_vergers_nom");

            entity.HasIndex(e => e.Proprietaire, "idx_vergers_proprietaire");

            entity.HasIndex(e => new { e.StationId, e.RefverStation }, "uq_vergers_station_refver").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("actif");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Localisation)
                .HasMaxLength(200)
                .HasColumnName("localisation");
            entity.Property(e => e.Nom)
                .HasMaxLength(150)
                .HasColumnName("nom");
            entity.Property(e => e.Proprietaire)
                .HasMaxLength(150)
                .HasColumnName("proprietaire");
            entity.Property(e => e.RefverStation)
                .HasColumnType("int(11)")
                .HasColumnName("refver_station");
            entity.Property(e => e.StationId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("station_id");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Station).WithMany(p => p.Vergers)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vergers_station");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
