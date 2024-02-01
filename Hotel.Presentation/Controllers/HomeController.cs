using Hotel.Application.Services;
using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Models;
using Hotel.Infrastructure.Presistence;
using Hotel.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Hotel.Presentation.Controllers
{
    public class HomeController : Controller
    {//TODO ujednolicić nazwy wszystkich funkcji

        private readonly ILogger<HomeController> _logger;
        private readonly HotelDbContext _dbContext;
        private readonly IRezerwacjaService _rezerwacjaService;
        private readonly IPokojService _pokojService;

        public HomeController(ILogger<HomeController> logger,
            HotelDbContext dbContext,
            IRezerwacjaService rezerwacjaService,
            IPokojService pokojService)
        {
            _dbContext = dbContext;
            _rezerwacjaService = rezerwacjaService;
            _pokojService = pokojService;
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

    }
}