using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class Departamento
{
    public long IdDepartamento { get; set; }

    public string? Descripcion { get; set; }

    public string? Divipola { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public virtual ICollection<Ciudade> Ciudades { get; set; } = new List<Ciudade>();
}
