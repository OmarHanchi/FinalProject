using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DreamParadise.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DreamParadise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        //*================ Home  view  action =============
        public IActionResult Index()
        {
            return View();
        }

        //*================ About  view  action =============
        public IActionResult About()
        {
            return View();
        }

        //*================ Rooms  view  action =============
        public IActionResult Rooms()
        {
            return View();
        }

        //*================ Book now view  action =============
        [SessionCheck]
        public IActionResult Booking()
        {
            return View();
        }

        //*================ Contact Us view  action =============
        public IActionResult ContactUs()
        {
            return View();
        }

        //*================ Reservations view  action =============
        [SessionCheck]
        public IActionResult Reservations()
        {
            var reservations = _context.Reservations.ToList();
            return View(reservations);
        }

        [HttpPost("Reservations/new")]
        public IActionResult CreateReservation(Reservation newReservation)
        {
            if (ModelState.IsValid)
            {
                // Determine the room price based on room type
                switch (newReservation.RoomType)
                {
                    case "Single Room":
                        newReservation.RoomPrice = 100;
                        if (newReservation.AdultsCount + newReservation.ChildCount > 2)
                        {
                            ModelState.AddModelError("", "A Single Room can accommodate only up to 2 people.");
                            return View("Booking", newReservation);
                        }
                        break;
                    case "Family Room":
                        newReservation.RoomPrice = 170;
                        break;
                    case "Suite":
                        newReservation.RoomPrice = 210;
                        break;
                    default:
                        ModelState.AddModelError("", "Invalid room type.");
                        return View("Booking", newReservation);
                }

                // Calculate the total price
                int additionalChildFee = newReservation.ChildCount * 50;
                newReservation.TotalPrice = newReservation.RoomPrice + additionalChildFee;

                _context.Add(newReservation);
                _context.SaveChanges();
                return RedirectToAction("Reservations");
            }
            else
            {
                return View("Booking", newReservation);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //*================ Session check attribute  =============
        public class SessionCheckAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                int? userId = context.HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {
                    context.Result = new RedirectToActionResult("LogReg", "LogReg", null);
                }
            }
        }
    }
}
