using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class Movimiento
{
    public long IdMovimiento { get; set; }

    public long? IdSiniestro { get; set; }

    public long? IdAnalista { get; set; }

    public long? IdEstado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual Analista? IdAnalistaNavigation { get; set; }

    public virtual EstadoSiniestro? IdEstadoNavigation { get; set; }

    public virtual Siniestro? IdSiniestroNavigation { get; set; }
}
