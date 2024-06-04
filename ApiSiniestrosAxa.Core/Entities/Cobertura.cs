using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class Cobertura
{
    public long IdCobertura { get; set; }

    public long? IdTlpoReclamacion { get; set; }

    public long? IdRamo { get; set; }

    public string? Descripcion { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual Ramo? IdRamoNavigation { get; set; }

    public virtual TiposReclamacion? IdTlpoReclamacionNavigation { get; set; }

    public virtual ICollection<ListaArchivo> ListaArchivos { get; set; } = new List<ListaArchivo>();

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
