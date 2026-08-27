using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Controllers
{
    public class DonationController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return View(donation);
            }

            // If no donor name was entered,
            // treat the donation as anonymous.
            if (string.IsNullOrWhiteSpace(donation.DonorName))
            {
                donation.DonorName = "Anonymous";
            }

            donation.DonationDate = DateTime.Now;

            // Prototype:
            // We are not processing a real payment.
            // We simply display a confirmation page.
            return RedirectToAction(
                "Confirmation",
                donation);
        }

        [HttpGet]
        public IActionResult Confirmation(Donation donation)
        {
            return View(donation);
        }
    }
}