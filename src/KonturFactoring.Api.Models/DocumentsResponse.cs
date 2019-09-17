using System;

namespace KonturFactoring.Api.Models
{
    /// <summary>
    /// note: парсить ответ следует как List<DocumentsResponse>
    /// </summary>
    public class DocumentsResponse
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Type { get; set; }

        public string Number { get; set; }

        public DateTime Date { get; set; }
        
        public decimal TotalSumWithVat { get; set; }
        
        public string Status { get; set; }

        public CompanyInfo Seller { get; set; }

        public CompanyInfo Buyer { get; set; }

        public Relations Relations { get; set; }

        public bool MustBeConfirmed { get; set; }

        public ConfirmationInfo ConfirmationInfo { get; set; }

        public long AfterKey { get; set; }
    }

    public class ConfirmationInfo
    {
        public bool Confirmed { get; set; }

        public int Amount { get; set; }

        public DateTime DelayStartDate { get; set; }
    }

    public class Relations
    {
        public RelationDocument DeliveryAgreement { get; set; }

        public RelationDocument FactoringAgreement { get; set; }

        public RelationDocument BaseDocument { get; set; }
    }

    public class RelationDocument
    {
        public string Type { get; set; }

        public string Number { get; set; }
    }

    public class CompanyInfo
    {
        public int Id { get; set; }

        public string Inn { get; set; }

        public string Kpp { get; set; }

        public string Name { get; set; }
    }
}