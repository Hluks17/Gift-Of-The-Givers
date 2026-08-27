using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class ContactMessage
    {
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = "";

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; } = "";

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; } = "";
    }
}