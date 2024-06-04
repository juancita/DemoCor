using System.Collections.Generic;
using System.Threading.Tasks;
using ApiSiniestrosAxa.Core.Interfaces;
using ApiSiniestrosAxa.Core.Entities;
using ApiSiniestrosAxa.Application.Dto.AuthAthento;
using ApiSiniestrosAxa.Application.Services;
using System.Text.Json;
using ApiSiniestrosAxa.Application.Dtos;
using Microsoft.Extensions.Configuration;

namespace ApiSiniestrosAxa.Application.External
{
    public class AuthAthentoService
    {
        private readonly IConfiguration _configuration;
        public AuthAthentoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<StatusTokenResponse> GetTokenAsync(AuthAthentoDto authAthentoDto)
        {
            try
            {
                var urlAthento = _configuration.GetSection("Athento:UrlAthento").Value;
                var apiToken = _configuration.GetSection("Athento:ApiToken").Value;
                string url = urlAthento + apiToken;

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                var client = new HttpClient(handler);

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", authAthentoDto.Authorization);

                var collection = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("grant_type", authAthentoDto.Type)
        };

                var content = new FormUrlEncodedContent(collection);
                request.Content = content;

                var response = await client.SendAsync(request);

                string responseContent = await response.Content.ReadAsStringAsync();
                var responseStream = await response.Content.ReadAsStreamAsync();
                if ((int)response.StatusCode != 200)
                {
                    return new StatusTokenResponse
                    {
                        Code = response.StatusCode

                    };
                }
                var responseToken = await JsonSerializer.DeserializeAsync<TokenResponse>(responseStream);

                return new StatusTokenResponse
                {
                    Code = response.StatusCode,
                    tokenResponse = responseToken
                };

            }
            catch (Exception ex)
            {
                throw new CustomException("Error al autenticar", ex);
            }

        }
    }
}
