using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Controllers
{
    public class EmployeeController : Controller
    {
        // ==============================
        // EMPLOYEE LOGIN
        // ==============================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        // ==============================
        // EMPLOYEE LOGIN SUBMISSION
        // ==============================

        [HttpPost]
        public IActionResult Login(EmployeeLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // ==========================================
            // PROTOTYPE LOGIN
            // ==========================================
            // These credentials are temporary.
            // We will replace them with database
            // authentication later.

            if (model.Email == "employee@giftofthegivers.org"
                && model.Password == "Employee123")
            {
                return RedirectToAction("Dashboard");
            }

            ModelState.AddModelError(
                "",
                "Invalid employee email or password."
            );

            return View(model);
        }


        // ==============================
        // EMPLOYEE DASHBOARD
        // ==============================

        public IActionResult Dashboard()
        {
            return View();
        }


        // ==============================
        // MANAGE DONATIONS
        // ==============================

        public IActionResult Donations()
        {
            return View();
        }


        // ==============================
        // MANAGE VOLUNTEERS
        // ==============================

        public IActionResult Volunteers()
        {
            return View();
        }


        // ==============================
        // RELIEF REQUESTS
        // ==============================

        public IActionResult ReliefRequests()
        {
            return View();
        }


        // ==============================
        // MANAGE USERS
        // ==============================

        public IActionResult Users()
        {
            return View();
        }


        // ==============================
        // EMPLOYEE LOGOUT
        // ==============================

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}