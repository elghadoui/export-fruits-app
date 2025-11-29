using System;
using System.Collections.Generic;

namespace ExportFruits.Api.Models;

public partial class StationExporteur
{
    public uint Id { get; set; }

    public uint StationId { get; set; }

    public short CodeExportStation { get; set; }

    public uint SocieteExportId { get; set; }

    public bool? Actif { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual SocietesExport SocieteExport { get; set; } = null!;

    public virtual Station Station { get; set; } = null!;
}
