using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class Ciudade
{
    public long IdCiudad { get; set; }

    public long? IdDepartamento { get; set; }

    public string? Descripcion { get; set; }

    public string? Divipola { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual ICollection<Siniestro> SiniestroIdCiudadOcurrenciaNavigations { get; set; } = new List<Siniestro>();

    public virtual ICollection<Siniestro> SiniestroIdCiudadResidenciaNavigations { get; set; } = new List<Siniestro>();
}
