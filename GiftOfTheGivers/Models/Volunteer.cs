using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = "";

        [Required]
        [Display(Name = "Skills")]
        public string Skills { get; set; } = "";

        [Required]
        [Display(Name = "Availability")]
        public string Availability { get; set; } = "";

        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}