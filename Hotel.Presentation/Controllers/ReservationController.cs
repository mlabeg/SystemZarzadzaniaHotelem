using Hotel.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Services;
using Hotel.Domain.Entities.Models;
using Hotel.Infrastructure.Presistence;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Presentation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelDbContext _dbContext;
        private readonly IRezerwacjaService _rezerwacjaService;
        private readonly IPokojService _pokojService;

        public ReservationController(ILogger<HomeController> logger,
            HotelDbContext dbContext,
            IRezerwacjaService rezerwacjaService,
            IPokojService pokojService)
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
        public async Task<IActionResult> CheckRoomsAvailability(CheckAvailabilityModel zapytanie)
        {//TODO wg jednego z postów na Stackoverflow CAŁA logika powinna być w module Application - należy stworzyć nowy serwis łączący oba serwisy i nic tutaj nie zostawiać
            if (zapytanie.DateFrom >= zapytanie.DateTo)
            {
                return View();//TODO wysłać komunikat o błędzie
            }

            if (!await _pokojService.PokojeAny())
            {
                return View(zapytanie);//TODO wysłać komunikat o błędzie
            }

            var rezerwacjeWTerminie = await _rezerwacjaService.GetByDate(zapytanie.DateFrom, zapytanie.DateTo);

            IEnumerable<Room> dostepnePokoje = new List<Room>();

            if (rezerwacjeWTerminie.IsNullOrEmpty())
            {
                dostepnePokoje = await _pokojService.ZwwrocWszystkie();
            }
            else
            {
                var zajetePokoje = rezerwacjeWTerminie.Select(r => r.RoomId).ToList();
                dostepnePokoje = await _pokojService.ZwrocDostepne(zajetePokoje, zapytanie.NumberOfGuests);
            }

            zapytanie.ListOfRooms = dostepnePokoje.ToList();

            return View(zapytanie);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReservation(int id, DateTime DataOd, DateTime DataDo, int IleOsob)
        {
            var Pokoj = await _pokojService.WyszukajPoId(id);
            var CenaZaNoc = Pokoj.Type.Price;
            int IloscDni = (int)DataDo.Subtract(DataOd).TotalDays;

            Reservation rezerwacja = new Reservation()
            {
                DateFrom = DataOd,
                DateTo = DataDo,
                NumberOfGuests = IleOsob,
                RoomId = id,
                PriceTotal = IloscDni * CenaZaNoc
            };

            return View(rezerwacja);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation rezerwacja)
        {
            if (ModelState.IsValid)
            {
                var _rezerwacja = new Reservation
                {
                    DateFrom = rezerwacja.DateFrom,
                    DateTo = rezerwacja.DateTo,

                    Person = new UserUnregistered
                    {
                        Name = rezerwacja.Person.Name,
                        Surname = rezerwacja.Person.Surname,
                        PhoneNumber = rezerwacja.Person.PhoneNumber,
                        EmailAddress = rezerwacja.Person.EmailAddress
                    },
                    NumberOfGuests = rezerwacja.NumberOfGuests,
                    PriceTotal = rezerwacja.PriceTotal,
                    RoomId = rezerwacja.RoomId,
                    Room = rezerwacja.Room
                };

                await _rezerwacjaService.AddReservation(_rezerwacja);

                return RedirectToAction("SuccessCreateReservation", new { id = _rezerwacja.Id });
            }
            else
            {
                return View(rezerwacja);
            }
        }

        public async Task<IActionResult> RoomDetails(int id)
        {
            var room = await _pokojService.WyszukajPoId(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> ReservationDetails(QueryReservationDetailsModel zapytanie)
        {
            var rezerwacja = await _rezerwacjaService.GetById(zapytanie.NumberOfReservation);

            if (rezerwacja != null)
            {
                if (string.Compare(zapytanie.EmailAddress, rezerwacja.Person.EmailAddress, true) == 0)
                {
                    return View(rezerwacja);
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