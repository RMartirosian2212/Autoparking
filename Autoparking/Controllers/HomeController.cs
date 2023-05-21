
using Autoparking_DataAccess.Repository.IRepository;
using Autoparking_Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Autoparking_Utility;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Autoparking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IReservationDetailsRepository _reservationsRepository;
        public HomeController(ICarRepository carRepository, IReservationDetailsRepository reservationDetailsRepository)
        {
            _carRepository = carRepository;
            _reservationsRepository = reservationDetailsRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Car> car = _carRepository.GetAll();
            return View(car);
        }
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Car car = _carRepository.Get(id);
            return View(car);
        }
        [HttpGet]
        public IActionResult Reservation(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }
            Car car = _carRepository.Get(id);
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> Reservation(DateTime startDate, DateTime endDate, string recipient, int CarId, int totalPrice)
        {
            Car car = _carRepository.Get(CarId);
            ReservationDetails reservation = new ReservationDetails() {CarName = car.Name, Price = totalPrice, Email = recipient, startDate = startDate, endDate = endDate};
            _reservationsRepository.Add(reservation);
            _reservationsRepository.Save();

            var apiKey = "YOUR API KEY";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("rmartirosian001@gmail.com", "Example Sernder");
            var subject = "Your reservation details";
            var to = new EmailAddress(recipient, "Example Recipient");
            var plainTextContent = $"Your id number of reservation:{reservation.Id}, final price is {reservation.Price} Kč for dates {startDate.ToShortDateString()} -- {endDate.ToShortDateString()}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, plainTextContent);
            var response = await client.SendEmailAsync(msg);
            return RedirectToAction(nameof(Summary));
        }
        [HttpGet]
        public ActionResult Summary()
        {
            return View();
        }
    }
}