using Hotel.Application.Services;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Hotel.Presentation.Models;
using Hotel.Presentation.Models.Rezerwacja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using Hotel.Application.Services.Rezerwacja;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Hotel.Presentation.Controllers
{
	public class HomeController : Controller
	{//TODO ujednolicić nazwy wszystkich funkcji
	 //TODO przenieść wsztskie akcje kontrolera do RezerwacjaController

		private readonly ILogger<HomeController> _logger;
		private readonly HotelDbContext _dbContext;
		private readonly IRezerwacjaService _rezerwacjaService;
		private readonly IPokojService _pokojService;

		//private readonly IAnulujRezerwacje _anulujRezerwacje;

		public HomeController(ILogger<HomeController> logger,
			HotelDbContext dbContext,
			IRezerwacjaService rezerwacjaService,
			IPokojService pokojService/*,
			IAnulujRezerwacje anulujRezerwacje*/)
		{
			_dbContext = dbContext;
			_rezerwacjaService = rezerwacjaService;
			_pokojService = pokojService;
			//_anulujRezerwacje = anulujRezerwacje;
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Sukces(int id)
		{
			return View(id);
		}

		[HttpGet]
		public IActionResult SprawdzDostepnosc()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SprawdzDostepnosc(SprawdzDostepnoscModel zapytanie)
		{//TODO przenieść logikę sprawdź dostęnosć do Hotel.Application

			//TODO chyba nie jest to potrzebne, bo jest zapewnniane przez requesty w definicji klasy SprawdzDostepnoscModel
			/*if (zapytanie.DataOd == null || zapytanie.DataDo == null || zapytanie.IleOsob <= 0 || zapytanie.IleOsob == null)
			{
				return View();//TODO wysłać komunikat o błędzie
			}*/

			if (zapytanie.DataOd >= zapytanie.DataDo)
			{
				return View();//TODO wysłać komunikat o błędzie
			}

			if (!await _pokojService.PokojeAny())
			{
				return View(zapytanie);//TODO wysłać komunikat o błędzie
			}

			var rezerwacje = await _rezerwacjaService.WyszukajWTermminie(zapytanie.DataOd, zapytanie.DataDo);

			List<Pokoj> dostepnePokoje = new List<Pokoj>();

			if (rezerwacje.IsNullOrEmpty())
			{
				dostepnePokoje = _dbContext.Pokoje.ToList();
			}
			else
			{//w IPokojService pobierz pokoje wg poniższego, ale z już odfltrowaną ilością osób
				dostepnePokoje = _dbContext.Pokoje.Where(r => !rezerwacje.Any(b => b.Id == r.Id)).ToList();
			}

			foreach (var pokoj in dostepnePokoje)
			{
				if (pokoj.LiczbaMiejsc >= zapytanie.IleOsob)
				{
					zapytanie.ListaPokoi.Add(pokoj);
				}
			}

			return View(zapytanie);
		}

		[HttpGet]
		public async Task<IActionResult> UtworzRezerwacje(int id, DateTime DataOd, DateTime DataDo, int IleOsob)
		{
			var Pokoj = await _pokojService.WyszukajPoId(id);
			var CenaZaNoc = Pokoj.CenaZaNoc;
			int IloscDni = (int)DataDo.Subtract(DataOd).TotalDays;

			Rezerwacja rezerwacja = new Rezerwacja()
			{
				DataOd = DataOd,
				DataDo = DataDo,
				IloscOsob = IleOsob,
				PokojId = id
			};

			rezerwacja.CenaCalkowita = IloscDni * CenaZaNoc;

			return View(rezerwacja);
		}

		[HttpPost]
		public async Task<IActionResult> UtworzRezerwacje(Rezerwacja rezerwacja)
		{
			if (ModelState.IsValid)
			{
				var _rezerwacja = new Rezerwacja
				{
					DataOd = rezerwacja.DataOd,
					DataDo = rezerwacja.DataDo,

					Osoba = new UzytkownikNiezarejestrowany
					{
						Imie = rezerwacja.Osoba.Imie,
						Nazwisko = rezerwacja.Osoba.Nazwisko,
						NumerTelefonu = rezerwacja.Osoba.NumerTelefonu,
						AdresEmail = rezerwacja.Osoba.AdresEmail
					},
					IloscOsob = rezerwacja.IloscOsob,
					CenaCalkowita = rezerwacja.CenaCalkowita,
					PokojId = rezerwacja.PokojId,
					Pokoj = rezerwacja.Pokoj
				};

				await _rezerwacjaService.DodajRezerwacje(_rezerwacja);

				return RedirectToAction("Sukces", new { id = _rezerwacja.Id });
			}
			else
			{
				return View(rezerwacja);
			}
		}

		public async Task<IActionResult> SzczegolyPokoju(int id)
		{
			var room = await _pokojService.WyszukajPoId(id);

			if (room == null)
			{
				return NotFound();
			}

			return View(room);
		}

		[HttpPost]
		public async Task<IActionResult> SzczegolyRezerwacji(ZapytanieOSzczegolyRezerwacjiModel zapytanie)
		{
			var rezerwacja = await _rezerwacjaService.WyszukajPoId(zapytanie.NumerRezerwacji);

			if (rezerwacja != null)
			{
				if (string.Compare(zapytanie.AdresEmail, rezerwacja.Osoba.AdresEmail, true) == 0)
				{
					return View(rezerwacja);
				}
			}

			return View();//TODO zwracać informację o błędzie
						  //w projekcie CarWorkshop jest dodana klasa ControllerExtensions, sprawdzić
		}

		[HttpGet]
		public IActionResult SzczegolyRezerwacji()
		{
			return View();
		}

		[HttpGet]
		public IActionResult AnulujRezerwacje(int id)
		{
			return View(id);
		}

		//TODO przenieść wykonywanie AnulujRezerwację do Hotel.Applicationa
		[HttpPost]
		public IActionResult AnulujRezerwacje(bool potwierdzenie, int rezerwacjaId)
		{
			if (potwierdzenie)
			{
				//_anulujRezerwacje.AnulowanieRezerwacji(rezerwacjaId);
				return Json(new { success = true, message = "Rezerwacja została anulowana" });
			}

			return RedirectToAction(nameof(SzczegolyRezerwacji));
			//TODO sprawdz czy nie usuwa dwóch pozycji rezerwacji TEST?
			//sprawdziłem i nic takiego nie widzę, może tylko sie pomyliłem
		}

		[HttpGet]
		public async Task<IActionResult> PulpitRezerwacji()
		{
			var rezerwacje = await _rezerwacjaService.PokazWszystkieRezerwacje();

			return View(rezerwacje);
		}
	}
}