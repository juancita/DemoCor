using ApiSiniestrosAxa.Application.External;
using ApiSiniestrosAxa.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiSiniestrosAxa.Application.Dto.AuthAthento;
using ApiSiniestrosAxa.Application.Dtos;
using Newtonsoft.Json.Linq;

namespace ApiSiniestrosAxa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAthentoController : ControllerBase
    {
        private readonly AuthAthentoService _authAthentoService;
        public AuthAthentoController(AuthAthentoService authAthentoService) {
            _authAthentoService = authAthentoService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> GetMovimientos(AuthAthentoDto authAthentoDto = null)
        {
            try
            {
                if (authAthentoDto.Type == null || authAthentoDto.Authorization == null)
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
                                    StatusDesc = "El tipo o Autorizacion no puede estar vacío o nulo.",
                                    AdditionalStatus = new AdditionalStatus
                                    {
                                        ServerStatusCode = 400,
                                        Category = "Validación",
                                        StatusDesc = "El tipo o Autorizacion no puede estar vacío o nulo.",
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

                var auth = await _authAthentoService.GetTokenAsync(authAthentoDto);

                if ((int)auth.Code != 200)
                {
                    return StatusCode((int)auth.Code,new ResponseDto
                    {
                        MsgRsHdr = new MsgRsHdr
                        {
                            Error = new Error
                            {
                                Status = new Status
                                {
                                    StatusCode = (int)auth.Code,
                                    StatusDesc = auth.Code.ToString(),
                                    AdditionalStatus = new AdditionalStatus
                                    {
                                        ServerStatusCode = (int)auth.Code,
                                        Category = "Validación",
                                        StatusDesc = auth.Code.ToString(),
                                    }
                                },
                            }
                        }
                    });
                }

                response.Body.Results.Add(auth);

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
