using System;
using System.Collections.Generic;
using System.Data;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class MovilidadDeSiniestro
{
    public int Id { get; set; }

    public string NumeroSiniestro { get; set; } = null!;

    public string? EstadoActual { get; set; }

    public string? Analista { get; set; }

    public long? NumeroPoliza { get; set; }

    public DateTime? FechaAviso { get; set; }

    public DateTime? FechaOcurrencia { get; set; }

    public string? Placa { get; set; }

    public string? Motor { get; set; }

    public string? Chasis { get; set; }

    public string? Marca { get; set; }

    public int? Anio { get; set; }
}
