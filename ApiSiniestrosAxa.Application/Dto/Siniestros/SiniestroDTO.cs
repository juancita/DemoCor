using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Application.Dto.Siniestros
{
    public class SiniestroDTO
    {
        public long? IdTipoReclamante { get; set; }
        public long? IdTipoReclamacion { get; set; }
        public long? IdTipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? Nombre { get; set; }
        public long? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Genero { get; set; }
        public string? Direccion { get; set; }
        public long? IdCiudadResidencia { get; set; }
        public long? IdRamo { get; set; }
        public long? IdCobertura { get; set; }
        public DateTime? FechaSiniestro { get; set; }
        //falta
        public string? LugarOcurrencia { get; set; }
        public long? IdCiudadOcurrencia { get; set; }
        public string? Hechos { get; set; }
        public string? BienesAfectados { get; set; }
        public string? NumeroPoliza { get; set; }
        public string? PlacaAsegurado { get; set; }
        public string? PlacaTerceroAfectado { get; set; }
        public string? NumeroProceso { get; set; }
        public string? NombreFuncionarioAsegurado { get; set; }
        public string? NombreAseguradoDeudor { get; set; }
        //falta campo
        public string? NumeroCredito { get; set; }
        //bool
        public bool? TratamientoDatos { get; set; }
        public string? CreadoPor { get; set; }
        public string? Audit { get; set; }
        public long? IdTipoUsuario { get; set; }

    }
}
