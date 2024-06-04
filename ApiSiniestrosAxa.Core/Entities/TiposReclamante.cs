using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class TiposReclamante
{
    public long IdTipoReclamante { get; set; }

    public string? Descripcion { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
