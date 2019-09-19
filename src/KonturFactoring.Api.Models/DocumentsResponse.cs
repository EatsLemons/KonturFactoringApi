using System;
using KonturFactoring.Api.Models.JsonConverters;
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
        [JsonConverterAttribute(typeof(CustomDateTimeConverter), "dd.MM.yyyy")]
        public DateTime? Date { get; set; }
        
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
        public decimal? Amount { get; set; }

        [JsonProperty("delayStartDate")]
        [JsonConverterAttribute(typeof(CustomDateTimeConverter), "dd.MM.yyyy")]
        public DateTime? DelayStartDate { get; set; }
    }

    public class Relations
    {
        [JsonProperty("deliveryAgreement")]
        public RelationDocument DeliveryAgreement { get; set; }

        [JsonProperty("factoringAgreement")]
        public RelationDocument FactoringAgreement { get; set; }

        [JsonProperty("baseDocument")]
        public RelationDocument BaseDocument { get; set; }
    }

    public class RelationDocument
    {
        [JsonProperty("date")]
        [JsonConverterAttribute(typeof(CustomDateTimeConverter), "dd.MM.yyyy")]
        public DateTime? Date { get; set; }

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