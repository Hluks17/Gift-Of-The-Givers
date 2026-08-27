using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Display(Name = "Donor Name")]
        public string? DonorName { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? DonorEmail { get; set; }

        [Required]
        [Range(1, 100000000)]
        [Display(Name = "Donation Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public string Currency { get; set; } = "ZAR";

        [Required]
        [Display(Name = "Donation Type")]
        public string DonationType { get; set; } = "One-Time";

        public DateTime DonationDate { get; set; } = DateTime.Now;
    }
}