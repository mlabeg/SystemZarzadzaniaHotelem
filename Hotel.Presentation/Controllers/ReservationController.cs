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
        {
            if (zapytanie.DataOd >= zapytanie.DataDo)
            {
                return View();//TODO wysłać komunikat o błędzie
            }

            if (!await _pokojService.PokojeAny())
            {
                return View(zapytanie);//TODO wysłać komunikat o błędzie
            }

            //TODO sprawzić czy nie wyrzuci błędu przy pustej bazie rezerwacji
            var rezerwacjeWTerminie = await _rezerwacjaService.ZwrocRezerwacjeWTermminie(zapytanie.DataOd, zapytanie.DataDo);

            IEnumerable<Pokoj> dostepnePokoje = new List<Pokoj>();

            if (rezerwacjeWTerminie.IsNullOrEmpty())
            {
                dostepnePokoje = await _pokojService.ZwwrocWszystkie();
            }
            else
            {
                var zajetePokoje = rezerwacjeWTerminie.Select(r => r.PokojId).ToList();
                dostepnePokoje = await _pokojService.ZwrocDostepne(zajetePokoje, zapytanie.IleOsob);
            }

            zapytanie.ListaPokoi = dostepnePokoje.ToList();

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
                PokojId = id,
                CenaCalkowita = IloscDni * CenaZaNoc
            };

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

            return View();//TODO wysłać komunikat o błędzie
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

        [HttpPost]
        public async Task<IActionResult> AnulujRezerwacje(bool potwierdzenie, int rezerwacjaId)
        {
            if (potwierdzenie)
            {
                if (await _rezerwacjaService.DeleteReservation(rezerwacjaId))
                {
                    return RedirectToAction("SukcesAnulujRezerwacje", new { id = rezerwacjaId });
                }
            }

            return RedirectToAction(nameof(SzczegolyRezerwacji));
        }

        [HttpGet]
        public async Task<IActionResult> PulpitRezerwacji()
        {
            var rezerwacje = await _rezerwacjaService.ZwrocWszystkie("DataOd");

            return View(rezerwacje);
        }

        [HttpPost]
        public async Task<IActionResult> PulpitRezerwacji(string sortowanie)
        {
            var rezerwacje = await _rezerwacjaService.ZwrocWszystkie(sortowanie);

            return View(rezerwacje);
        }

        public IActionResult SukcesAnulujRezerwacje(int id)
        {
            return View(id);
        }
    }
}