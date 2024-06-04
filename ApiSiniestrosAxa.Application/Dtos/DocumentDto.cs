using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Application.Dtos
{
    using System;
    using Newtonsoft.Json;

    public class DocumentDto
    {
        [JsonProperty("entity-type")]
        public string EntityType { get; set; }

        public string Repository { get; set; }
        public Guid? Uid { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public Guid ParentRef { get; set; }
        public string VersionLabel { get; set; }

        [JsonProperty("dc:created")]
        public DateTime Created { get; set; }

        [JsonProperty("dc:creator")]
        public string Creator { get; set; }

        public bool IsCheckedOut { get; set; }
        public bool IsVersion { get; set; }
        public bool IsProxy { get; set; }
        public string Title { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        public string[] Facets { get; set; }

        [JsonProperty("size")]
        public long? Size { get; set; }

        [JsonProperty("metadata.poliza_ramo_comercial")]
        public string PolizaRamoComercial { get; set; }

        [JsonProperty("metadata.poliza_numero_poliza")]
        public string PolizaNumeroPoliza { get; set; }

        [JsonProperty("metadata.expediente_siniestro_linea_especializada")]
        public string ExpedienteSiniestroLineaEspecializada { get; set; }

        [JsonProperty("metadata.expediente_siniestro_fecha_siniestro")]
        public string ExpedienteSiniestroFechaSiniestro { get; set; }

        [JsonProperty("metadata.poliza_placa_asegurado")]
        public string PolizaPlacaAsegurado { get; set; }

        [JsonProperty("metadata.expediente_siniestro_placa_tercero")]
        public string ExpedienteSiniestroPlacaTercero { get; set; }

        [JsonProperty("metadata.expediente_siniestro_departamento")]
        public string ExpedienteSiniestroDepartamento { get; set; }

        [JsonProperty("expediente_siniestro_ciudad")]
        public string ExpedienteSiniestroCiudad { get; set; }

        [JsonProperty("metadata.expediente_siniestro_hechos")]
        public string ExpedienteSiniestroHechos { get; set; }

        [JsonProperty("metadata.expediente_siniestro_danos")]
        public string ExpedienteSiniestroDanos { get; set; }

        [JsonProperty("metadata.expediente_siniestro_cobertura")]
        public string ExpedienteSiniestroCobertura { get; set; }

        [JsonProperty("metadata.expediente_siniestro_siniestro_grave")]
        public string ExpedienteSiniestroSiniestroGrave { get; set; }

        [JsonProperty("metadata.expediente_siniestro_nombre_reclamante")]
        public string ExpedienteSiniestroNombreReclamante { get; set; }

        [JsonProperty("metadata.expediente_siniestro_tipo_documento_reclamante")]
        public string ExpedienteSiniestroTipoDocumentoReclamante { get; set; }

        [JsonProperty("metadata.expediente_siniestro_id_documento_reclamante")]
        public string ExpedienteSiniestroIdDocumentoReclamante { get; set; }

        [JsonProperty("metadata.expediente_siniestro_direccion_reclamante")]
        public string ExpedienteSiniestroDireccionReclamante { get; set; }

        [JsonProperty("metadata.expediente_siniestro_telefono_reclamante")]
        public string ExpedienteSiniestroTelefonoReclamante { get; set; }

        [JsonProperty("metadata.expediente_siniestro_email_reclamante")]
        public string ExpedienteSiniestroEmailReclamante { get; set; }

        [JsonProperty("metadata.raf_siniestros_descripcion_alerta_raf")]
        public string RafSiniestrosDescripcionAlertaRaf { get; set; }

        [JsonProperty("metadata.raf_siniestros_analisis_raf")]
        public string RafSiniestrosAnalisisRaf { get; set; }

        [JsonProperty("metadata.raf_siniestros_reportar_a_juridico")]
        public string RafSiniestrosReportarAJuridico { get; set; }

        [JsonProperty("metadata.raf_siniestros_reportar_a_suscripcion")]
        public string RafSiniestrosReportarASuscripcion { get; set; }

        [JsonProperty("metadata.raf_siniestros_reportar_riesgo_operativo")]
        public string RafSiniestrosReportarRiesgoOperativo { get; set; }

        [JsonProperty("metadata.raf_siniestros_reportar_ros")]
        public string RafSiniestrosReportarRos { get; set; }

        [JsonProperty("metadata.expediente_siniestro_tipo_reclamacion")]
        public string ExpedienteSiniestroTipoReclamacion { get; set; }

        [JsonProperty("metadata.expediente_siniestro_lugar_de_ocurrencia")]
        public string ExpedienteSiniestroLugarDeOcurrencia { get; set; }

        [JsonProperty("metadata.expediente_siniestro_ciudad_de_ocurrencia")]
        public string ExpedienteSiniestroCiudadDeOcurrencia { get; set; }

        [JsonProperty("metadata.expediente_siniestro_genero")]
        public string ExpedienteSiniestroGenero { get; set; }

        [JsonProperty("metadata.expediente_siniestro_analista")]
        public string ExpedienteSiniestroAnalista { get; set; }

        [JsonProperty("metadata.expediente_siniestro_correo_analista")]
        public string ExpedienteSiniestroCorreoAnalista { get; set; }
    }
}