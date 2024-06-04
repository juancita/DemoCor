using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class ListaArchivo
{
    public long IdListaArchivo { get; set; }

    public long? IdTipoReclamacion { get; set; }

    public long? IdCobertura { get; set; }

    public long? IdRamo { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual Cobertura? IdCoberturaNavigation { get; set; }

    public virtual Ramo? IdRamoNavigation { get; set; }

    public virtual TiposReclamacion? IdTipoReclamacionNavigation { get; set; }

    public virtual ICollection<ListaArchivosDetalle> ListaArchivosDetalles { get; set; } = new List<ListaArchivosDetalle>();
}
