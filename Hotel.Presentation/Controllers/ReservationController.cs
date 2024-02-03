using Hotel.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Services;
using Hotel.Domain.Entities.Models;
using Hotel.Infrastructure.Presistence;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace Hotel.Presentation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelDbContext _dbContext;
        private readonly IReservationService _rezerwacjaService;
        private readonly IRoomService _pokojService;

        public ReservationController(ILogger<HomeController> logger,
            HotelDbContext dbContext,
            IReservationService rezerwacjaService,
            IRoomService pokojService)
        {
            _dbContext = dbContext;
            _rezerwacjaService = rezerwacjaService;
            _pokojService = pokojService;
            _logger = logger;
        }

        public IActionResult SuccessCreateReservation(int id)
        {
            return View(id);
        }

        [HttpGet]
        public IActionResult CheckRoomsAvailability()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckRoomsAvailability(CheckAvailabilityModel query)
        {//TODO wg jednego z postów na Stackoverflow CAŁA logika powinna być w module Application - należy stworzyć nowy serwis łączący oba serwisy i nic tutaj nie zostawiać
            if (query.DateFrom >= query.DateTo)
            {
                return View();//TODO wysłać komunikat o błędzie
            }

            if (!await _pokojService.AnyRooms())
            {
                return View(query);//TODO wysłać komunikat o błędzie
            }

            var rezerwacjeWTerminie = await _rezerwacjaService.GetByDate(query.DateFrom, query.DateTo);

            IEnumerable<Room> dostepnePokoje = new List<Room>();

            if (rezerwacjeWTerminie.IsNullOrEmpty())
            {
                dostepnePokoje = await _pokojService.GetAll();
            }
            else
            {
                var zajetePokoje = rezerwacjeWTerminie.Select(r => r.RoomId).ToList();
                dostepnePokoje = await _pokojService.GetAvailable(zajetePokoje, query.NumberOfGuests);
            }

            query.ListOfRooms = dostepnePokoje.ToList();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReservation(int id, DateTime DateFrom, DateTime DateTo, int GuestsCount)
        {
            var room = await _pokojService.GetById(id);
            int days = (int)DateTo.Subtract(DateFrom).TotalDays;

            Reservation rezerwacja = new Reservation()
            {
                DateFrom = DateFrom,
                DateTo = DateTo,
                NumberOfGuests = GuestsCount,
                RoomId = id,
                PriceTotal = days * room.Type.Price,
                Person = new UserUnregistered()
            };

            return View(rezerwacja);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var _rezerwacja = new Reservation
                {
                    DateFrom = reservation.DateFrom,
                    DateTo = reservation.DateTo,

                    Person = new UserUnregistered
                    {
                        Name = reservation.Person.Name,
                        Surname = reservation.Person.Surname,
                        PhoneNumber = reservation.Person.PhoneNumber,
                        EmailAddress = reservation.Person.EmailAddress
                    },
                    NumberOfGuests = reservation.NumberOfGuests,
                    PriceTotal = reservation.PriceTotal,
                    RoomId = reservation.RoomId,
                    Room = reservation.Room
                };

                await _rezerwacjaService.AddReservation(_rezerwacja);

                return RedirectToAction("SuccessCreateReservation", new { id = _rezerwacja.Id });
            }
            else
            {
                return View(reservation);
            }
        }

        public async Task<IActionResult> RoomDetails(int id)
        {
            var room = await _pokojService.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> ReservationDetails(QueryReservationDetailsModel query)
        {
            var reservation = await _rezerwacjaService.GetById(query.NumberOfReservation);

            if (reservation != null)
            {
                if (string.Compare(query.EmailAddress, reservation.Person.EmailAddress, true) == 0)
                {
                    return View(reservation);
                }
            }

            return View();//TODO wysłać komunikat o błędzie
                          //w projekcie CarWorkshop jest dodana klasa ControllerExtensions, sprawdzić
        }

        [HttpGet]
        public IActionResult ReservationDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CancelReservation(int id)
        {
            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> CancelReservation(bool potwierdzenie, int rezerwacjaId)
        {
            if (potwierdzenie)
            {
                if (await _rezerwacjaService.DeleteReservation(rezerwacjaId))
                {
                    return RedirectToAction("SuccessCancelReservation", new { id = rezerwacjaId });
                }
            }

            return RedirectToAction(nameof(ReservationDetails));
        }

        [HttpGet]
        public async Task<IActionResult> ReservationManagementBoard()
        {
            var rezerwacje = await _rezerwacjaService.GetAll("DataOd");

            return View(rezerwacje);
        }

        [HttpPost]
        public async Task<IActionResult> ReservationManagementBoard(string sort)
        {
            var rezerwacje = await _rezerwacjaService.GetAll(sort);

            return View(rezerwacje);
        }

        public IActionResult SuccessCancelReservation(int id)
        {
            return View(id);
        }
    }
}