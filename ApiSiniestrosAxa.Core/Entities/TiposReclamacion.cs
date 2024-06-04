using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class TiposReclamacion
{   
    public long IdTipoReclamacion { get; set; }

    public string? Descripcion { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Cobertura> Coberturas { get; set; } = new List<Cobertura>();

    public virtual ICollection<ListaArchivo> ListaArchivos { get; set; } = new List<ListaArchivo>();

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
