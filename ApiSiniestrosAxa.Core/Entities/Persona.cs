using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class Persona
{
    public long IdPersona { get; set; }

    public long? IdTipoDocumento { get; set; }

    public string? Nombre { get; set; }

    public string? Documento { get; set; }

    public string? Genero { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual TiposDocumento? IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
