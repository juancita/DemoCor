using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Application.Dtos
{
    public class ResponseDto
    {
        public MsgRsHdr? MsgRsHdr { get; set; }
        public Body Body { get; set; }
    }

    public class MsgRsHdr
    {
        public Error? Error { get; set; } = null;
        public string Message { get; set; } = null;

    }

    public class Body
    {
        public List<object> Results { get; set; }
    }

    public class Error
    {
        public Status Status { get; set; }
        
    }

    public class Status
    {
        public int StatusCode { get; set; }
        public string? Severity { get; set; }
        public string StatusDesc { get; set; }
        public AdditionalStatus AdditionalStatus { get; set; }
    }

    public class AdditionalStatus
    {
        public int ServerStatusCode { get; set; }
        public string Category { get; set; }
        public string StatusDesc { get; set; }
    }
    public class StatusSinister
    {
        public string Message { get; set; }
        public string NumeroExpediente { get; set; }
    }
    public class StatusSinisterResponse
    {
        public HttpStatusCode Code { get; set; }
        public StatusSinister statusSinister { get; set; }
        
    }

}
