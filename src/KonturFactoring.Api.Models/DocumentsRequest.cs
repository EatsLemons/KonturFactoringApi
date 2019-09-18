using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KonturFactoring.Api.Models
{
    public class DocumentsRequest
    {
        [JsonProperty("afterKey")]
        public int AfterKey { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("fromDate")]
        public DateTime? FromDate { get; set; }

        [JsonProperty("organizationIds")]
        public List<int> OrganizationsIds { get; set; }
    }
}