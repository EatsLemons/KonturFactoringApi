using KonturFactoring.Api.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KonturFactoring.Api
{
    /// <summary>
    /// KonturFactoringHttpClientRaw provide raw requests to kontur factoring without any logic
    /// </summary>
    public class KonturFactoringHttpClientRaw
    {
        private readonly HttpClient _http;

        private const string KONTUR_FACTORING_URL = "https://factoring-api.kontur.ru";

        public KonturFactoringHttpClientRaw(HttpClient httpClient)
        {
            if (httpClient == null)
                httpClient = new HttpClient();

            _http = httpClient;
        }

        public async Task<(AuthResponse, ErrorResponse)> AuthAsync(string login, string password)
        {
            if (login == null) throw new ArgumentNullException("login");
            if (password == null) throw new ArgumentNullException("password");

            var request = new HttpRequestMessage(HttpMethod.Post, KONTUR_FACTORING_URL + "/v2/auth");

            using (var stringContent = new StringContent(JsonConvert.SerializeObject(new AuthRequest(login, password)), Encoding.UTF8, "application/json"))
            {
                request.Content = stringContent;
                HttpResponseMessage response = await _http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(await response.Content.ReadAsStringAsync());
                    return (authResponse, null);
                }
                
                ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
                return (null, errorResponse);
            }
        }
    }
}
