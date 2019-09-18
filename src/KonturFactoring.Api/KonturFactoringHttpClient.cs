using KonturFactoring.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KonturFactoring.Api
{
    /// <summary>
    /// KonturFactoringHttpClientRaw provide raw requests to kontur factoring without any logic
    /// </summary>
    public class KonturFactoringHttpClient
    {
        private readonly HttpClient _http;

        private const string KONTUR_FACTORING_URL = "https://factoring-api.kontur.ru";

        public KonturFactoringHttpClient(HttpClient httpClient)
        {
            _http = httpClient ?? new HttpClient();
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

        public async Task<(List<DocumentsResponse>, ErrorResponse)> GetDocumentsAsync(DateTime fromDate, int organizationId, int afterKey)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, KONTUR_FACTORING_URL + "/v2/documents");
            var requestBody = new DocumentsRequest(afterKey, 500, fromDate, new List<int> {organizationId});

            return await MakeRequest<List<DocumentsResponse>, ErrorResponse>(request, requestBody);
        }

        private async Task<(TResponse, TError)> MakeRequest<TResponse, TError>(HttpRequestMessage request, object requestBody)
            where TResponse : class where TError : class 
        {
            using (var stringContent = new StringContent(JsonConvert.SerializeObject(requestBody),
                Encoding.UTF8, "application/json"))
            {
                request.Content = stringContent;
                HttpResponseMessage response = await _http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    TResponse responseObj = JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
                    return (responseObj, null);
                }
                
                TError errorResponse = JsonConvert.DeserializeObject<TError>(await response.Content.ReadAsStringAsync());
                return (null, errorResponse);
            }
        }
    }
}
