using System;
using Newtonsoft.Json;

namespace KonturFactoring.Api.Models
{
    /// <summary>
    /// note: парсить ответ следует как List<DocumentsResponse>
    /// </summary>
    public class DocumentsResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
        
        [JsonProperty("totalSumWithVat")]
        public decimal TotalSumWithVat { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("seller")]
        public CompanyInfo Seller { get; set; }

        [JsonProperty("buyer")]
        public CompanyInfo Buyer { get; set; }

        [JsonProperty("relations")]
        public Relations Relations { get; set; }

        [JsonProperty("mustBeConfirmed")]
        public bool MustBeConfirmed { get; set; }

        [JsonProperty("confirmationInfo")]
        public ConfirmationInfo ConfirmationInfo { get; set; }

        [JsonProperty("afterKey")]
        public long AfterKey { get; set; }
    }

    public class ConfirmationInfo
    {
        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("delayStartDate")]
        public DateTime DelayStartDate { get; set; }
    }

    public class Relations
    {
        [JsonProperty("organizationIds")]
        public RelationDocument DeliveryAgreement { get; set; }

        [JsonProperty("organizationIds")]
        public RelationDocument FactoringAgreement { get; set; }

        [JsonProperty("organizationIds")]
        public RelationDocument BaseDocument { get; set; }
    }

    public class RelationDocument
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public class CompanyInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("inn")]
        public string Inn { get; set; }

        [JsonProperty("kpp")]
        public string Kpp { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}