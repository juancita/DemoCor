using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class ListaArchivosDetalle
{
    public long IdListaArchivoDetalle { get; set; }

    public long? IdListaArchivo { get; set; }

    public long? IdArchivoSolicitado { get; set; }

    public long? Ordinal { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ArchivosSolicitado? IdArchivoSolicitadoNavigation { get; set; }

    public virtual ListaArchivo? IdListaArchivoNavigation { get; set; }
}
