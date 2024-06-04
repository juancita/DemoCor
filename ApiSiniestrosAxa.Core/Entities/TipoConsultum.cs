using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class TipoConsultum
{
    public int IdTipoConsulta { get; set; }

    public string Descripcion { get; set; } = null!;
}
