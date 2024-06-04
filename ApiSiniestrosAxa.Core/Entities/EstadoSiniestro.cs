using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class EstadoSiniestro
{
    public long IdEstado { get; set; }

    public string? EstadoSiniestro1 { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
