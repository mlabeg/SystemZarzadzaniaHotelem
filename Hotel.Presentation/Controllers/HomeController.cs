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
        public HomeController(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ILogger<HomeController> _logger;
        private readonly HotelDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger)
        {
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
    }
}