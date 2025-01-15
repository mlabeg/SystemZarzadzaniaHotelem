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
		private readonly IReservationService _reservationService;
		private readonly IRoomService _roomService;
		private readonly IRoomReservationService _roomReservationService;

		public ReservationController(ILogger<HomeController> logger,
			HotelDbContext dbContext,
			IReservationService rezerwacjaService,
			IRoomService pokojService,
			IRoomReservationService roomReservationService)
		{
			_dbContext = dbContext;
			_logger = logger;

			_reservationService = rezerwacjaService;
			_roomService = pokojService;
			_roomReservationService = roomReservationService;
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
		{
			if (query.DateFrom >= query.DateTo)
			{
				TempData["Message"] = $"Data zakończenia pobytu nie może być wcześniej niż data rozpoczęcia!";
				return View();
			}

			query.DictionayRooms = await _roomReservationService.CheckRoomsAvailabilityAsync(query);

			return View(query);
		}

		[HttpGet]
		public async Task<IActionResult> CreateReservation(int Id, DateTime DateFrom, DateTime DateTo, int NumberOfGuests)
		{
			var room = await _roomService.GetByIdAsync(Id);
			if (room == null)
			{
                TempData["Message"] = $"Wewnętrzny błąd bazy danych!/n" +
					$"_roomService error";
                return RedirectToAction(nameof(CheckRoomsAvailability));
			}
			int days = (int)DateTo.Subtract(DateFrom).TotalDays;

			Reservation reservation = new Reservation()
			{
				DateFrom = DateFrom,
				DateTo = DateTo,
				NumberOfGuests = NumberOfGuests,
				RoomId = Id,
				PriceTotal = days * room.Type.Price,
				Client = new UserUnregistered()
			};

			return View(reservation);
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

					Client = new UserUnregistered
					{
						Name = reservation.Client.Name,
						Surname = reservation.Client.Surname,
						PhoneNumber = reservation.Client.PhoneNumber,
						EmailAddress = reservation.Client.EmailAddress
					},
					NumberOfGuests = reservation.NumberOfGuests,
					PriceTotal = reservation.PriceTotal,
					RoomId = reservation.RoomId,
					Room = reservation.Room
				};

				await _reservationService.AddReservationAsync(_rezerwacja);

				return RedirectToAction("SuccessCreateReservation", new { id = _rezerwacja.Id });
			}
			else
			{
				TempData["Message"] = $"Wewnętrzny błąd !/n" +
					$"RESERVATION ModelState.IsValid == false";

                return View(reservation);
			}
		}

		public async Task<IActionResult> RoomDetails(int id)
		{
			var room = await _roomService.GetByIdAsync(id);

			if (room == null)
			{
				return NotFound();
			}

			return View(room);
		}

		[HttpPost]
		public async Task<IActionResult> ReservationDetails(QueryReservationDetailsModel query)
		{
			var reservation = await _reservationService.GetByIdAsync(query.NumberOfReservation);

			if (reservation == null)
			{
				TempData["Message"] = $"Brak rezerwacji w systemie";
                return View();
			}

			if (string.Compare(query.EmailAddress, reservation.Client.EmailAddress, true) == 0)
			{
				return View(reservation);
			}

            TempData["Message"] = $"Brak rezerwacji w systemie";
            return View();
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
				if (await _reservationService.DeleteReservationAsync(rezerwacjaId))
				{
					return RedirectToAction("SuccessCancelReservation", new { id = rezerwacjaId });
				}
			}

			return RedirectToAction(nameof(ReservationDetails));
		}

		[HttpGet]
		public async Task<IActionResult> ReservationManagementBoard()
		{
			var rezerwacje = await _reservationService.GetAllAsync("DataOd");

			return View(rezerwacje);
		}

		[HttpPost]
		public async Task<IActionResult> ReservationManagementBoard(string sort)
		{
			var rezerwacje = await _reservationService.GetAllAsync(sort);

			return View(rezerwacje);
		}

		public IActionResult SuccessCancelReservation(int id)
		{
			return View(id);
		}
	}
}