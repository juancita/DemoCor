using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Application.Dto.Siniestros;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using ApiSiniestrosAxa.Application.Dtos;
using Microsoft.Extensions.Configuration;


namespace ApiSiniestrosAxa.Application.Services
{
    public class SiniestroService
    {
        private readonly ISiniestroRepository _siniestroRepository;

        private readonly AnalistaService _analistaService;
        private readonly EstadoSiniestroService _estadoSiniestroService;
        private readonly MovimientoService _movimientoService;
        private readonly PersonaService _personaService;
        private readonly IConfiguration _configuration;
        private readonly MovilidadDeSiniestroService _movilidadSiniestroService;

        public SiniestroService(ISiniestroRepository siniestroRepository, AnalistaService analistaService, EstadoSiniestroService estadoSiniestroService, MovimientoService movimientoService, MovilidadDeSiniestroService movilidadSiniestroService, PersonaService personaService)
        {
            _siniestroRepository = siniestroRepository;
            _analistaService = analistaService;
            _estadoSiniestroService = estadoSiniestroService;
            _movimientoService = movimientoService;
            _movilidadSiniestroService = movilidadSiniestroService;
            _personaService = personaService;
        }

        public async Task<IEnumerable<Siniestro>> GetAllSiniestrosAsync(Siniestro siniestro)
        {
            return await _siniestroRepository.GetAllAsync(siniestro);
        }
        public async Task<Siniestro> GetSiniestroByUidAsync(Guid? uid)
        {
            return await _siniestroRepository.GetSiniestroByUidAsync(uid);
        }


        public async Task<Siniestro> GetSiniestroByIdAsync(long id)
        {
            return await _siniestroRepository.GetByIdAsync(id);
        }

        public async Task AddSiniestroAsync(Siniestro siniestro)
        {
            await _siniestroRepository.AddAsync(siniestro);
        }

        public async Task UpdateSiniestroAsync(Siniestro siniestro)
        {
            await _siniestroRepository.UpdateAsync(siniestro);
        }

        public async Task ActualizarEstadoSiniestro(DocumentDto? dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            Siniestro siniestro = await GetSiniestroByUidAsync(dto.Uid);
            Analista analista = await VerificarOCrearAnalista(dto);
            EstadoSiniestro estadoSiniestro = await _estadoSiniestroService.GetEstadoSiniestroByStateAsync(dto.State);

            await ActualizarSiniestro(siniestro, estadoSiniestro, dto);
            await RegistrarMovimiento(siniestro, estadoSiniestro, analista);
        }

        private async Task<Analista> VerificarOCrearAnalista(DocumentDto dto)
        {
            var analista = await _analistaService.GetAnalistaByEmailAsync(dto.ExpedienteSiniestroCorreoAnalista);
            if (analista == null)
            {
                analista = await _analistaService.AddAnalistaAsync(new Analista
                {
                    Correo = dto.ExpedienteSiniestroCorreoAnalista,
                    Nombre = dto.ExpedienteSiniestroAnalista
                });
            }
            return analista;
        }

        private async Task ActualizarSiniestro(Siniestro siniestro, EstadoSiniestro estadoSiniestro, DocumentDto dto)
        {
            try
            {
                siniestro.IdEstadoSiniestro = estadoSiniestro.IdEstado;
                siniestro.NumeroPoliza = dto.PolizaNumeroPoliza;
                siniestro.Correo = dto.ExpedienteSiniestroCorreoAnalista;
                await UpdateSiniestroAsync(siniestro);
            }
            catch (Exception ex)
            {
                throw new CustomException("Error al actualizar el siniestro", ex);
            }
        }

        private async Task RegistrarMovimiento(Siniestro siniestro, EstadoSiniestro estadoSiniestro, Analista analista)
        {
            try
            {

                Movimiento movimiento = new Movimiento
                {
                    IdSiniestro = siniestro.IdSiniestro,
                    IdEstado = estadoSiniestro.IdEstado,
                    IdAnalista = analista.IdAnalista
                };
                await _movimientoService.AddMovimientoAsync(movimiento);
            }
            catch (Exception ex)
            {
                throw new CustomException("Error al Agregar movimiento", ex);
            }
        }
        public async Task<StatusSinisterResponse> AddSiniestroAthentoAsync(SiniestroDTO siniestro, string token)
        {
            try
            {
                DateTime currentUtcDate = DateTime.UtcNow;
                string Fecha = currentUtcDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                string responseContent;
                var urlAthento = _configuration.GetSection("Athento:UrlAthento").Value;
                var apiDocumentManagement = _configuration.GetSection("Athento:ApiDocumentManagement").Value;
                var input = _configuration.GetSection("Athento:Input").Value;
                string url = urlAthento + apiDocumentManagement;
               
                var rootObject = new Root
                {
                    IdDocType = "2",
                    RefNbr = new List<RefNbr>
            {
                new RefNbr { NomRef = "Radicación Siniestro" + currentUtcDate.ToString("MMddyyyyHHmm") + siniestro.Documento,
                             ValorRef = currentUtcDate.ToString("MMddyyyyHHmm") + siniestro.Documento}
            },
                    DateEffective = Fecha,
                    DateCreate = Fecha,
                    JsonDoc = new JsonDoc
                    {
                        Input = input,
                        Params = new Params
                        {
                            RunPostloadOperations = true,
                            Type = "expediente_siniestro",
                            Audit = siniestro.Audit,
                            Properties = new Properties
                            {
                                ExpedienteSiniestroTipoRemitente = siniestro.IdTipoReclamante.ToString(), 
                                ExpedienteSiniestroTipoReclamacion = siniestro.IdTipoReclamacion.ToString(),
                                ExpedienteSiniestroTipoDocumentoReclamante = siniestro.IdTipoDocumento.ToString(),
                                ExpedienteSiniestroIdDocumentoReclamante = siniestro.Documento,
                                ExpedienteSiniestroNombreReclamante = siniestro.Nombre,
                                ExpedienteSiniestroTelefonoReclamante = siniestro.Celular.ToString(),
                                ExpedienteSiniestroEmailReclamante = siniestro.Correo,
                                ExpedienteSiniestroGenero = siniestro.Genero,
                                ExpedienteSiniestroDireccionReclamante = siniestro.Direccion,
                                ExpedienteSiniestroCiudad = siniestro.IdCiudadResidencia.ToString(),
                                PolizaRamoComercial = siniestro.IdRamo.ToString(),
                                ExpedienteSiniestroCobertura = siniestro.IdCobertura.ToString(),
                                ExpedienteSiniestroFechaSiniestro = siniestro.FechaSiniestro.ToString(),
                                ExpedienteSiniestroLugarDeOcurrencia = siniestro.LugarOcurrencia,
                                ExpedienteSiniestroCiudadDeOcurrencia = siniestro.IdCiudadOcurrencia.ToString(),
                                ExpedienteSiniestroHechos = siniestro.Hechos,
                                ExpedienteSiniestroDanos = siniestro.BienesAfectados,
                                PolizaNumeroPoliza = siniestro.NumeroPoliza,
                                PolizaPlacaAsegurado = siniestro.PlacaAsegurado,
                                ExpedienteSiniestroPlacaTercero = siniestro.PlacaTerceroAfectado,
                                ExpedienteSiniestroNumeroProceso = siniestro.NumeroProceso,
                                ExpedienteSiniestroNombreFuncionario = siniestro.NombreFuncionarioAsegurado,
                                ExpedienteSiniestroNombreAsegurado = siniestro.NombreAseguradoDeudor,
                                ExpedienteSiniestroNumeroContratoCreditoAfectado = siniestro.NumeroCredito,
                                ExpedienteSiniestroFechaAviso = Fecha

                            },
                            ExtractValue = "extractValue"
                        }
                    },
                    Download = false
                };
                
                var json = JsonConvert.SerializeObject(rootObject);
                
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                };

                var client = new HttpClient(handler);

                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.PostAsync(url, content);

                if ((int)response.StatusCode != 200)
                {
                    return new StatusSinisterResponse
                    {
                        Code = response.StatusCode,
                        statusSinister = new StatusSinister
                        {
                            Message = "Error Negocio"
                        }

                    };
                }

                responseContent = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseContent);

                string expedienteConsecutivo = (string)jsonResponse["body"]["result"][0]["athentoJson"]["metadata.expediente_siniestro_consecutivo"];

                string uid = jsonResponse["body"]?["result"]?[0]?["uid"]?.ToString();

                string state = (string)jsonResponse["body"]["result"][0]["athentoJson"]["state"];

                if (string.IsNullOrEmpty(expedienteConsecutivo) || string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(state))
                {
                    throw new Exception("Alguno de estos campos en nulo: Consecutivo, Uid, state");
                }

                EstadoSiniestro estadoSiniestro = await _estadoSiniestroService.GetEstadoSiniestroByStateAsync(state);

                Persona persona = new Persona
                {
                    IdTipoDocumento = siniestro.IdTipoDocumento,
                    Nombre = siniestro.Nombre,
                    Documento = siniestro.Documento,
                    Genero = siniestro.Genero,
                    CreadoPor = siniestro.CreadoPor,
                    Creado = currentUtcDate
                };

                var personaExist = await _personaService.GetPersonaByDocumentAsync(persona);

                if (personaExist == null)
                {
                    personaExist = await _personaService.AddPersonaAsync(persona);
                }

                Siniestro siniestroF = new Siniestro
                {
                    IdPersona = personaExist.IdPersona,
                    IdTipoReclamante = siniestro.IdTipoReclamante,
                    IdTipoReclamacion = siniestro.IdTipoReclamacion,
                    IdCobertura = siniestro.IdCobertura,
                    IdRamo = siniestro.IdRamo,
                    Celular = siniestro.Celular,
                    Correo = siniestro.Correo,
                    Direccion = siniestro.Direccion,
                    IdCiudadResidencia = siniestro.IdCiudadResidencia,
                    IdCiudadOcurrencia = siniestro.IdCiudadOcurrencia,
                    FechaSiniestro = siniestro.FechaSiniestro,
                    LugarOcurrencia = siniestro.LugarOcurrencia,
                    Hechos = siniestro.Hechos,
                    BienesAfectados = siniestro.BienesAfectados,
                    NumeroPoliza = siniestro.NumeroPoliza,
                    PlacaAsegurado = siniestro.PlacaAsegurado,
                    PlacaTerceroAfectado = siniestro.PlacaTerceroAfectado,
                    NumeroProceso = siniestro.NumeroProceso,
                    NombreFuncionarioAsegurado = siniestro.NombreFuncionarioAsegurado,
                    NombreAseguradoDeudor = siniestro.NombreAseguradoDeudor,
                    NumeroCredito = siniestro.NumeroCredito,
                    TratamientoDatos = siniestro.TratamientoDatos,
                    CreadoPor = siniestro.CreadoPor,
                    IdEstadoSiniestro = estadoSiniestro.IdEstado,
                    NumeroSiniestro = expedienteConsecutivo,
                    FechaAviso = currentUtcDate,
                    Creado = currentUtcDate,
                    Uid = Guid.Parse(uid),
                    NumeroExpediente = expedienteConsecutivo,
                    IdTipoUsuario = siniestro.IdTipoUsuario
                };

                await _siniestroRepository.AddAsync(siniestroF);

                return new StatusSinisterResponse
                {
                    Code = response.StatusCode,
                    statusSinister = new StatusSinister
                    {
                        Message = "Expediente creado exitosamente.",
                        NumeroExpediente = siniestroF.NumeroExpediente
                    }

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el siniestro", ex);
            }
        }

        public async Task GetAllSiniestroByDocsAsync(object dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<object>> GetSiniestrosByPersonaAsync(int tipoDocumento, string documento)
        {
            List<object> resultList = new List<object>();
            Persona persona = new Persona();
            persona.IdTipoDocumento = tipoDocumento;
            persona.Documento = documento;
            IEnumerable<Persona> personas = await _personaService.GetAllPersonasAsync(persona);
            if (personas.Any())
            {
                Siniestro siniestroSearch = new Siniestro();
                siniestroSearch.IdPersona = personas.First().IdPersona;
                IEnumerable<Siniestro> siniestros = await GetAllSiniestrosAsync(siniestroSearch);
                IEnumerable<ExpedienteDTO> lstREt = new List<ExpedienteDTO>();
                resultList.AddRange(siniestros.Cast<object>());
            }
            return resultList;
        }

        public async Task<List<object>> GetSiniestrosByNumeroExpedienteAsync(string numeroExpediente)
        {
            List<object> resultList = new List<object>();
            Siniestro siniestro = new Siniestro();
            siniestro.NumeroExpediente = numeroExpediente;
            IEnumerable<Siniestro> siniestros = await GetAllSiniestrosAsync(siniestro);
            resultList.AddRange(siniestros.Cast<object>());
            return resultList;
        }

        public async Task<List<object>> GetMovilidadSiniestrosByPlacaAsync(string placa)
        {
            List<object> resultList = new List<object>();
            MovilidadDeSiniestro movilidadSiniestro = new MovilidadDeSiniestro();
            movilidadSiniestro.Placa = placa;
            IEnumerable<MovilidadDeSiniestro> movilidadSiniestros = await _movilidadSiniestroService.GetAllMovilidadDeSiniestrosAsync(movilidadSiniestro);
            resultList.AddRange(movilidadSiniestros.Cast<object>());
            return resultList;
        }



    }
}
