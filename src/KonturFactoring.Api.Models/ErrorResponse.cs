using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonturFactoring.Api.Models
{
    public class ErrorResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceID { get; set; }
    }
}
