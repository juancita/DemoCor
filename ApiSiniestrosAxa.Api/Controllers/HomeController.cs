using ApiSiniestrosAxa.Application;
using ApiSiniestrosAxa.Application.Dtos;
using ApiSiniestrosAxa.Application.Services;
using ApiSiniestrosAxa.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text.Json.Nodes;

[Route("ApiSiniestros/v1/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly SiniestroService _siniestroService;
    private readonly AnalistaService _analistaService;
    private readonly EstadoSiniestroService _estadoSiniestroService;
    private readonly MovimientoService _movimientoService;
    private readonly PersonaService _personaService;
    private readonly MovilidadDeSiniestroService _movilidadSiniestroService;

    public HomeController(SiniestroService siniestroService, MovimientoService movimientoService, AnalistaService analistaService, EstadoSiniestroService estadoSiniestroService, PersonaService personaService, MovilidadDeSiniestroService movilidadDeSiniestroService)
    {
        _siniestroService = siniestroService;
        _analistaService = analistaService;
        _estadoSiniestroService = estadoSiniestroService;
        _movimientoService = movimientoService;
        _personaService = personaService;
        _movilidadSiniestroService = movilidadDeSiniestroService;
    }

    [HttpPut("actualizar-estado")]
    public async Task<IActionResult> ActualizarEstado([FromBody] JsonObject obj)
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
        try
        {
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
                                Category= "Error",
                                StatusDesc = ex.InnerException.Message,
                            }
                        },
                        
                    }
                }
            });
        }
    }

    [HttpGet("consultar-siniestros")]
    public async Task<ActionResult<IEnumerable<Object>>> ConsultarSiniestros(int TipoConsulta, int TipoDocumento, string ValorBusqueda)
    {
        try { 
        var response = new ResponseDto
        {
            MsgRsHdr = new MsgRsHdr(),
            Body = new Body { Results = new List<Object>() }
        };

        switch (TipoConsulta)
        {
            case 1:
                Persona persona = new Persona();
                persona.IdTipoDocumento = TipoDocumento;
                persona.Documento = ValorBusqueda;
                IEnumerable<Persona> personas = await _personaService.GetAllPersonasAsync(persona);
                if(personas.Count() > 0)
                {
                    Siniestro siniestroSearch = new Siniestro();
                    siniestroSearch.IdPersona = persona.IdPersona;
                    response.Body.Results = (List<object>)await _siniestroService.GetAllSiniestrosAsync(siniestroSearch);
                }
                break;
            case 2:
                Siniestro siniestro = new Siniestro();
                siniestro.NumeroExpediente = ValorBusqueda;
                response.Body.Results = (List<object>)await _siniestroService.GetAllSiniestrosAsync(siniestro);
                break;
            case 3:
                MovilidadDeSiniestro movilidadSiniestro = new MovilidadDeSiniestro();
                movilidadSiniestro.Placa = ValorBusqueda;
                response.Body.Results = (List<object>)await _movilidadSiniestroService.GetAllMovilidadDeSiniestrosAsync(movilidadSiniestro);
                break;
        }
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
                                Category= "Error",
                                StatusDesc = ex.InnerException.Message,
                            }
                        },
                        
                    }
                }
            });
        }
    }
}