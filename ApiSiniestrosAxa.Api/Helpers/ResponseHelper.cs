using ApiSiniestrosAxa.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiSiniestrosAxa.Api.Helpers
{
    public class ResponseHelper
    {
        public ResponseDto CreateResponseErrorDto(int statusCode, string statusDesc, string category)
        {
            // Potentially use some injected services or configuration
            return new ResponseDto
            {
                MsgRsHdr = new MsgRsHdr
                {
                    Error = new Error
                    {
                        Status = new Status
                        {
                            StatusCode = statusCode,
                            StatusDesc = statusDesc,
                            AdditionalStatus = new AdditionalStatus
                            {
                                ServerStatusCode = statusCode,
                                Category = category,
                                StatusDesc = statusDesc,
                            }
                        },
                    }
                }
            };
        }
    }


}
