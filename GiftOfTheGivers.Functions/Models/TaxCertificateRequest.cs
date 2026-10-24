using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Functions.Models
{
    public class TaxCertificateRequest
    {
        [Required]
        [StringLength(150)]
        public string DonorName { get; set; } = string.Empty;

        [Range(0.01, 999999999.99)]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression(
            "^[A-Z]{3}$",
            ErrorMessage = "Currency must be a 3-letter uppercase code, e.g. ZAR."
        )]
        public string Currency { get; set; } = string.Empty;

        [Range(1, long.MaxValue)]
        public long DonationId { get; set; }
    }
}