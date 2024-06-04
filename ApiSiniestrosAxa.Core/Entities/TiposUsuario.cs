using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class TiposUsuario
{
    public long IdTipoUsuario { get; set; }

    public string? Descripcion { get; set; }

    public string? Vista { get; set; }

    public string? TipoSiniestro { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
