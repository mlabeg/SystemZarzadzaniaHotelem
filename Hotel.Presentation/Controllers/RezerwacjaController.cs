using Hotel.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Services;

namespace Hotel.Presentation.Controllers
{
	public class RezerwacjaController : Controller
	{
		private readonly IRezerwacjaService _rezerwacjaService;

		public RezerwacjaController(IRezerwacjaService rezerwacjaService)
		{
			_rezerwacjaService = rezerwacjaService;
		}

		public ActionResult UtworzRezerwacje1()

		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UtworzRezerwacje1(Rezerwacja rezerwacja)
		{
			await _rezerwacjaService.DodajRezerwacje(rezerwacja);
			return RedirectToAction(nameof(Index));
			//TODO dodawać nową rezerwację przez tą metodę
		}
	}
}