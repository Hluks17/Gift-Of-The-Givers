using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Controllers
{
    public class VolunteerController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Volunteer volunteer)
        {
            if (!ModelState.IsValid)
            {
                return View(volunteer);
            }

            volunteer.DateRegistered = DateTime.Now;

            return RedirectToAction("Success", volunteer);
        }

        [HttpGet]
        public IActionResult Success(Volunteer volunteer)
        {
            return View(volunteer);
        }
    }
}