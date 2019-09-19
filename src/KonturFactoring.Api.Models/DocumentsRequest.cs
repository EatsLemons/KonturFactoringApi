using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KonturFactoring.Api.Models
{
    public class DocumentsRequest
    {
        [JsonProperty("afterKey")]
        public long AfterKey { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("fromDate")]
        public DateTime FromDate { get; set; }

        [JsonProperty("organizationIds")]
        public List<int> OrganizationsIds { get; set; }

        public DocumentsRequest(long afterKey, int count, DateTime fromDate, List<int> organizationsIds)
        {
            AfterKey = afterKey;
            Count = count;
            FromDate = fromDate;
            OrganizationsIds = organizationsIds;
        }
    }
}