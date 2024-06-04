using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class ArchivosSolicitado
{
    public long IdArchivoSolicitado { get; set; }

    public string? Descripcion { get; set; }

    public string? FormularioPdf { get; set; }

    public bool? Eliminado { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<ListaArchivosDetalle> ListaArchivosDetalles { get; set; } = new List<ListaArchivosDetalle>();
}
