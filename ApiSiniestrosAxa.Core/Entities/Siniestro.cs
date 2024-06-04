using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiSiniestrosAxa.Core.Entities;

public partial class Siniestro
{
    public long IdSiniestro { get; set; }

    public long? IdPersona { get; set; }

    public long? IdTipoUsuario { get; set; }

    public long? IdTipoReclamante { get; set; }

    public long? IdTipoReclamacion { get; set; }

    public long? IdCobertura { get; set; }

    public long? IdRamo { get; set; }

    public long? Celular { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public long? IdEstadoSiniestro { get; set; }

    public long? IdCiudadResidencia { get; set; }

    public long? IdCiudadOcurrencia { get; set; }

    public string? NumeroSiniestro { get; set; }

    public DateTime? FechaSiniestro { get; set; }

    public DateTime? FechaAviso { get; set; }

    public string? NumeroExpediente { get; set; }

    public string? Hechos { get; set; }

    public string? BienesAfectados { get; set; }  

    public string? NumeroProceso { get; set; }

    public string? NombreFuncionarioAsegurado { get; set; }

    public string? NombreAseguradoDeudor { get; set; }

    public string? PlacaAsegurado { get; set; }

    public string? NumeroPoliza { get; set; }

    public string? PlacaTerceroAfectado { get; set; }

    public bool? TratamientoDatos { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime? Creado { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? Modificado { get; set; }

    public Guid? Uid { get; set; }

    public string? LugarOcurrencia { get; set; }

    public string? NumeroCredito { get; set; }

    public virtual ICollection<ArchivosAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivosAdjunto>();
    [JsonIgnore]
    public virtual Ciudade? IdCiudadOcurrenciaNavigation { get; set; }
    [JsonIgnore]
    public virtual Ciudade? IdCiudadResidenciaNavigation { get; set; }
    [JsonIgnore]
    public virtual Cobertura? IdCoberturaNavigation { get; set; }
    [JsonIgnore]
    public virtual EstadoSiniestro? IdEstadoSiniestroNavigation { get; set; }
    
    [JsonIgnore]
    public virtual Persona? IdPersonaNavigation { get; set; }
    [JsonIgnore]
    public virtual Ramo? IdRamoNavigation { get; set; }
    [JsonIgnore]
    public virtual TiposReclamacion? IdTipoReclamacionNavigation { get; set; }
    [JsonIgnore]
    public virtual TiposReclamante? IdTipoReclamanteNavigation { get; set; }
    [JsonIgnore]
    public virtual TiposUsuario? IdTipoUsuarioNavigation { get; set; }
    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
