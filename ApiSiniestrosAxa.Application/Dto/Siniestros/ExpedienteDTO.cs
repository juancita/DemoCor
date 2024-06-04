using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Application.Dto.Siniestros
{ 
    public class ExpedienteDTO
        {
            public string NumeroDeExpediente { get; set; }
            public string NumeroDeSiniestro { get; set; }
            public string TipoDeReclamacion { get; set; }
            public string TipoDeReclamante { get; set; }
            public string CorreoDelReclamante { get; set; }
            public string EstadoActual { get; set; }
            public string AnalistaUsuarioBack { get; set; }
            public string NumeroDePoliza { get; set; }
            public DateTime FechaDeAviso { get; set; }
            public DateTime FechaDeOcurrencia { get; set; }
            public string CorreoElectronicoDelAnalista { get; set; }
            public string Uid { get; set; }
        }
    
}
