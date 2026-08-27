using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Controllers
{
    public class AccountController : Controller
    {
        // LOGIN PAGE
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN SUBMISSION
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Prototype login
            // Authentication will be connected to the database later.
            return RedirectToAction("Dashboard");
        }

        // REGISTER PAGE
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // REGISTER SUBMISSION
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("RegistrationSuccess");
        }

        // PROTOTYPE DASHBOARD
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        // REGISTRATION SUCCESS
        [HttpGet]
        public IActionResult RegistrationSuccess()
        {
            return View();
        }

        // LOGOUT PROTOTYPE
        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}