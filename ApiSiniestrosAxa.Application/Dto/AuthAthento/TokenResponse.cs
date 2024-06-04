using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using ApiSiniestrosAxa.Application.Dtos;
using System.Net;

namespace ApiSiniestrosAxa.Application.Dto.AuthAthento
{
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
    public class StatusTokenResponse
    {
        public HttpStatusCode Code { get; set; }
        public TokenResponse tokenResponse { get; set; }

    }
}
