using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class TipoCertificacion
{
    public int IdTipoCertificacion { get; set; }

    public string Descripcion { get; set; } = null!;
}
