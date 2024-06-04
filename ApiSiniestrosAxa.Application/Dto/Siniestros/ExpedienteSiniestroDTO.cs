using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Application.Dto.Siniestros
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class RefNbr
    {
        [JsonProperty("nom_ref")]
        public string? NomRef { get; set; }
        [JsonProperty("valor_ref")]
        public string? ValorRef { get; set; }
    }

    public class Properties
    {
        [JsonProperty("expediente_siniestro_tipo_remitente")]
        public string? ExpedienteSiniestroTipoRemitente { get; set; }

        [JsonProperty("expediente_siniestro_tipo_reclamacion")]
        public string? ExpedienteSiniestroTipoReclamacion { get; set; }
        [JsonProperty("expediente_siniestro_tipo_documento_reclamante")]
        public string? ExpedienteSiniestroTipoDocumentoReclamante { get; set; }

        [JsonProperty("expediente_siniestro_id_documento_reclamante")]
        public string? ExpedienteSiniestroIdDocumentoReclamante { get; set; }

        [JsonProperty("expediente_siniestro_nombre_reclamante")]
        public string? ExpedienteSiniestroNombreReclamante { get; set; }

        [JsonProperty("expediente_siniestro_telefono_reclamante")]
        public string? ExpedienteSiniestroTelefonoReclamante { get; set; }

        [JsonProperty("expediente_siniestro_email_reclamante")]
        public string? ExpedienteSiniestroEmailReclamante { get; set; }
        [JsonProperty("expediente_siniestro_genero")]
        public string? ExpedienteSiniestroGenero { get; set; }

        [JsonProperty("expediente_siniestro_direccion_reclamante")]
        public string? ExpedienteSiniestroDireccionReclamante { get; set; }        

        [JsonProperty("expediente_siniestro_departamento")]
        public string? ExpedienteSiniestroDepartamento { get; set; }

        [JsonProperty("expediente_siniestro_ciudad")]
        public string? ExpedienteSiniestroCiudad { get; set; }

        [JsonProperty("poliza_ramo_comercial")]
        public string? PolizaRamoComercial { get; set; }

        [JsonProperty("expediente_siniestro_cobertura")]
        public string? ExpedienteSiniestroCobertura { get; set; }

        [JsonProperty("expediente_siniestro_fecha_siniestro")]
        public string? ExpedienteSiniestroFechaSiniestro { get; set; }

        [JsonProperty("expediente_siniestro_lugar_de_ocurrencia")]
        public string? ExpedienteSiniestroLugarDeOcurrencia { get; set; }

        [JsonProperty("expediente_siniestro_ciudad_de_ocurrencia")]
        public string? ExpedienteSiniestroCiudadDeOcurrencia { get; set; }

        [JsonProperty("expediente_siniestro_hechos")]
        public string? ExpedienteSiniestroHechos { get; set; }

        [JsonProperty("expediente_siniestro_danos")]
        public string? ExpedienteSiniestroDanos { get; set; }
        [JsonProperty("poliza_numero_poliza")]
        public string? PolizaNumeroPoliza { get; set; }

        [JsonProperty("poliza_placa_asegurado")]
        public string? PolizaPlacaAsegurado { get; set; }

        [JsonProperty("expediente_siniestro_placa_tercero")]
        public string? ExpedienteSiniestroPlacaTercero { get; set; }
        [JsonProperty("expediente_siniestro_numero_proceso")]
        public string? ExpedienteSiniestroNumeroProceso { get; set; }

        [JsonProperty("expediente_siniestro_nombre_funcionario")]
        public string? ExpedienteSiniestroNombreFuncionario { get; set; }
        [JsonProperty("expediente_siniestro_nombre_asegurado")]
        public string? ExpedienteSiniestroNombreAsegurado { get; set; }
        [JsonProperty("expediente_siniestro_numero_contrato_credito_afectado")]
        public string? ExpedienteSiniestroNumeroContratoCreditoAfectado { get; set; }

        [JsonProperty("expediente_siniestro_fecha_aviso")]
        public string? ExpedienteSiniestroFechaAviso { get; set; }
    }

    public class Params
    {
        [JsonProperty("runPostloadOperations")]
        public bool? RunPostloadOperations { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("audit")]
        public string? Audit { get; set; }
        [JsonProperty("properties")]
        public Properties? Properties { get; set; }
        [JsonProperty("extractValue")]
        public string? ExtractValue { get; set; }
    }

    public class JsonDoc
    {
        [JsonProperty("input")]
        public string? Input { get; set; }
        [JsonProperty("params")]
        public Params? Params { get; set; }
    }

    public class Root
    {
        [JsonProperty("idDocType")]
        public string? IdDocType { get; set; }
        [JsonProperty("refNbr")]
        public List<RefNbr>? RefNbr { get; set; }
        [JsonProperty("dateEffective")]
        public string? DateEffective { get; set; }
        [JsonProperty("dateCreate")]
        public string? DateCreate { get; set; }
        [JsonProperty("jsonDoc")]
        public JsonDoc? JsonDoc { get; set; }
        [JsonProperty("download")]
        public bool Download { get; set; }
    }

}
