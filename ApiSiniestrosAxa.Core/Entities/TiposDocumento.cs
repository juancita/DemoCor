using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class TiposDocumento
{
    public long IdTipoDocumento { get; set; }

    public string? Descripcion { get; set; }

    public string? Codigo { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
