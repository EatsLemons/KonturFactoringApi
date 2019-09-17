using System;
using System.Collections.Generic;

namespace KonturFactoring.Api.Models
{
    public class DocumentsRequest
    {
        public int AfterKey { get; set; }

        public int Count { get; set; }

        public DateTime? FromDate { get; set; }

        public List<int> OrganizationsIds { get; set; }
    }
}