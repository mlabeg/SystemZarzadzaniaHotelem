using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Hotel.Presentation.Models;
using Hotel.Presentation.Models.Rezerwacja;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hotel.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, HotelDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Sukces(int id)
        {
            return View(id);
        }

        [HttpGet]
        public IActionResult ZapytanieODostepnosc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ZapytanieODostepnosc(ZapytanieODostepnoscModel zapytanie)
        {
            if (zapytanie.DataOd == null || zapytanie.DataDo == null || zapytanie.IleOsob <= 0 || zapytanie.IleOsob == null)
            {
                return View();
            }

            if (zapytanie.DataOd >= zapytanie.DataDo)
            {
                return View();
            }

            var pokojeZajete = from p in _dbContext.Rezerwacje
                               where
                               ((zapytanie.DataOd >= p.DataOd) && (zapytanie.DataOd <= p.DataDo)) ||
                               ((zapytanie.DataDo >= p.DataOd) && (zapytanie.DataDo <= p.DataDo)) ||
                               ((zapytanie.DataOd <= p.DataDo) && (zapytanie.DataDo >= p.DataDo) && (zapytanie.DataDo <= p.DataDo)) ||
                               ((zapytanie.DataOd >= p.DataDo) && (zapytanie.DataOd <= p.DataDo) && (zapytanie.DataDo >= p.DataDo)) ||
                               ((zapytanie.DataOd <= p.DataDo) && (zapytanie.DataDo >= p.DataDo))
                               select p;

            var dostepnePokoje = _dbContext.Pokoje.Where(r => !pokojeZajete.Any(b => b.Id == r.Id)).ToList();

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
        public IActionResult UtworzRezerwacje(int id, DateTime DataOd, DateTime DataDo, int IleOsob)
        {
            var Pokoj = _dbContext.Pokoje.Single(p => p.Id == id);
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
        public IActionResult UtworzRezerwacje(Rezerwacja rezerwacja)
        {//nie mam pojęcia dlaczego Id rezerwacji zmienia się na 1 przy przekazaniu do funkcji - dlatego muszę tutaj utworzyć nowy obiekt Rezerwacja i go przekazać do BD
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
                    PokojId = rezerwacja.PokojId
                };

                _dbContext.Rezerwacje.Add(_rezerwacja);
                _dbContext.SaveChanges();

                return RedirectToAction("Sukces", new { id = _rezerwacja.Id });
            }
            else
            {
                return View(rezerwacja);
            }
        }

        public async Task<IActionResult> SzczegolyPokoju(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _dbContext.Pokoje
                .FirstOrDefaultAsync(m => m.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
    }
}