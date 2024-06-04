using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Application.Services;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Application.Dtos;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using ApiSiniestrosAxa.Application.Dto.Siniestros;

namespace ApiSiniestrosAxa.Api.Controllers
{
    [Route("apiSiniestros/v1/[controller]")]
    [ApiController]
    public class SiniestrosController : ControllerBase
    {
        private readonly SiniestroService _siniestroService;
        private readonly AnalistaService _analistaService;
        private readonly EstadoSiniestroService _estadoSiniestroService;
        private readonly MovimientoService _movimientoService;
        private readonly PersonaService _personaService;
        private readonly MovilidadDeSiniestroService _movilidadSiniestroService;
        private readonly IConfiguration _configuration ;

        public SiniestrosController(SiniestroService siniestroService, MovimientoService movimientoService, AnalistaService analistaService, EstadoSiniestroService estadoSiniestroService, PersonaService personaService, MovilidadDeSiniestroService movilidadDeSiniestroService, IConfiguration configuration)
        {
            _siniestroService = siniestroService;
            _analistaService = analistaService;
            _estadoSiniestroService = estadoSiniestroService;
            _movimientoService = movimientoService;
            _personaService = personaService;
            _movilidadSiniestroService = movilidadDeSiniestroService;
            _configuration = configuration;
        }

        [HttpPut("actualizar-estado")]
        public async Task<IActionResult> ActualizarEstado([FromBody] JsonObject obj)
        {
            try
            {
                var json = obj.ToString();
                DocumentDto dto = JsonConvert.DeserializeObject<DocumentDto>(json);

                if (string.IsNullOrWhiteSpace(dto.Uid.ToString()))
                {
                    return BadRequest(new ResponseDto
                    {
                        MsgRsHdr = new MsgRsHdr
                        {
                            Error = new Error
                            {
                                Status = new Status
                                {
                                    StatusCode = 400,
                                    StatusDesc = "El UID no puede estar vacío o nulo.",
                                    AdditionalStatus = new AdditionalStatus
                                    {
                                        ServerStatusCode = 400,
                                        Category = "Validación",
                                        StatusDesc = "El UID no puede estar vacío o nulo.",
                                    }
                                },
                            }
                        }
                    });
                }
                else if (string.IsNullOrWhiteSpace(dto.ExpedienteSiniestroCorreoAnalista))
                {
                    return BadRequest(new ResponseDto
                    {
                        MsgRsHdr = new MsgRsHdr
                        {
                            Error = new Error
                            {
                                Status = new Status
                                {
                                    StatusCode = 400,
                                    StatusDesc = "El Correo no puede estar vacío o nulo.",
                                    AdditionalStatus = new AdditionalStatus
                                    {
                                        ServerStatusCode = 400,
                                        Category = "Validación",
                                        StatusDesc = "El Correo no puede estar vacío o nulo.",
                                    }
                                },
                            }
                        }
                    });
                }

                await _siniestroService.ActualizarEstadoSiniestro(dto);
                
                return Ok(new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr
                    {
                        Message = "Transaccion exitosa"
                    }
                });
            }
            catch (CustomException ce)
            {
                return BadRequest(new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr
                    {
                        Error = new Error
                        {
                            Status = new Status
                            {
                                StatusCode = 400,
                                StatusDesc = ce.Message,
                                AdditionalStatus = new AdditionalStatus
                                {
                                    ServerStatusCode = 400,
                                    Category = "Negocio",
                                    StatusDesc = ce.Message,
                                }
                            },
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr
                    {
                        Error = new Error
                        {
                            Status = new Status
                            {
                                StatusCode = 500,
                                Severity = null,
                                StatusDesc = ex.InnerException.Message,
                                AdditionalStatus = new AdditionalStatus
                                {
                                    ServerStatusCode = 500,
                                    Category = "Error",
                                    StatusDesc = ex.InnerException.Message,
                                }
                            },

                        }
                    }
                });
            }
        }

        [HttpGet("GetSiniestros")]
        public async Task<ActionResult<IEnumerable<Object>>> ConsultarSiniestros(int tipoConsulta, int tipoDocumento, string valorBusqueda)
        {
            try
            {
                
                var response = new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr(),
                    Body = new Body { Results = new List<object>() }
                };

                switch (tipoConsulta)
                {
                    case 1:
                        response.Body.Results = await _siniestroService.GetSiniestrosByPersonaAsync(tipoDocumento, valorBusqueda);
                        break;
                    case 2:
                        response.Body.Results = await _siniestroService.GetSiniestrosByNumeroExpedienteAsync(valorBusqueda);
                        break;
                    case 3:
                        response.Body.Results = await _siniestroService.GetMovilidadSiniestrosByPlacaAsync(valorBusqueda);
                        break;
                }
               
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr
                    {
                        Error = new Error
                        {
                            Status = new Status
                            {
                                StatusCode = 500,
                                Severity = null,
                                StatusDesc = ex.InnerException.Message,
                                AdditionalStatus = new AdditionalStatus
                                {
                                    ServerStatusCode = 500,
                                    Category = "Error",
                                    StatusDesc = ex.InnerException.Message,
                                }
                            },

                        }
                    }
                });
            }
        }

        private IEnumerable<Siniestro> SetSiniestrosList(IEnumerable<MovilidadDeSiniestro> listaMovilidadSiniestros)
        {
            List<Siniestro> LstSiniestros = new List<Siniestro>();
            foreach (MovilidadDeSiniestro element in listaMovilidadSiniestros)
            {
                Siniestro siniestro = new Siniestro
                {
                    NumeroSiniestro = element.NumeroSiniestro,
                    NumeroPoliza = element.NumeroPoliza.ToString(),
                    FechaAviso = element.FechaOcurrencia,
                    FechaSiniestro = element.FechaOcurrencia
                };
                LstSiniestros.Add(siniestro);
            }
            return LstSiniestros;
        }
        [HttpPost("post-siniestro-athento")]
        public async Task<ActionResult> PostSiniestroAthento([FromBody] SiniestroDTO siniestro = null, [FromHeader(Name = "Token")] string token = null)
        {
            try
            {
                if (string.IsNullOrEmpty(token) || siniestro == null)
                {
                    return BadRequest(new ResponseDto
                    {
                        MsgRsHdr = new MsgRsHdr
                        {
                            Error = new Error
                            {
                                Status = new Status
                                {
                                    StatusCode = 400,
                                    StatusDesc = "El Token no puede estar vacío o nulo.",
                                    AdditionalStatus = new AdditionalStatus
                                    {
                                        ServerStatusCode = 400,
                                        Category = "Validación",
                                        StatusDesc = "El Token no puede estar vacío o nulo.",
                                    }
                                },
                            }
                        }
                    });
                }
                var response = new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr(),
                    Body = new Body { Results = new List<Object>() }
                };

                var respuestaSiniestros = await _siniestroService.AddSiniestroAthentoAsync(siniestro, token);

                if ((int)respuestaSiniestros.Code != 200)
                {
                    return BadRequest(new ResponseDto
                    {
                        MsgRsHdr = new MsgRsHdr
                        {
                            Error = new Error
                            {
                                Status = new Status
                                {
                                    StatusCode = 400,
                                    StatusDesc = respuestaSiniestros.Code.ToString(),
                                    AdditionalStatus = new AdditionalStatus
                                    {
                                        ServerStatusCode = 400,
                                        Category = "Validación",
                                        StatusDesc = respuestaSiniestros.Code.ToString(),
                                    }
                                },
                            }
                        }
                    });
                }

                response.Body.Results.Add(respuestaSiniestros);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto
                {
                    MsgRsHdr = new MsgRsHdr
                    {
                        Error = new Error
                        {
                            Status = new Status
                            {
                                StatusCode = 500,
                                Severity = null,
                                StatusDesc = ex.InnerException.Message,
                                AdditionalStatus = new AdditionalStatus
                                {
                                    ServerStatusCode = 500,
                                    Category = "Error",
                                    StatusDesc = ex.InnerException.Message,
                                }
                            },

                        }
                    }
                });
            }

        }
    }
}


