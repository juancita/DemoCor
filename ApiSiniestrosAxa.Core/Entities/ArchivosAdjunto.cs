using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class ArchivosAdjunto
{
    public long IdArchivoAdjunto { get; set; }

    public long? IdSiniestro { get; set; }

    public long? Nombre { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual Siniestro? IdSiniestroNavigation { get; set; }
}
