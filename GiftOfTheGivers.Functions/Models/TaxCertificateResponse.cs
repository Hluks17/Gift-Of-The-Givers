namespace GiftOfTheGivers.Functions.Models
{
    public class TaxCertificateResponse
    {
        public bool Success { get; set; }

        public string CertificateNumber { get; set; } = string.Empty;

        public long DonationId { get; set; }

        public string DonorName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string Currency { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}