using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonturFactoring.Api.Models
{
    public class AuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in_seconds")]
        public int ExpiresInSeconds { get; set; }
    }
}
