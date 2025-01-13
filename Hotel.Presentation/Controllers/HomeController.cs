using Hotel.Application.Services;
using Hotel.Domain.Entities;
using Hotel.Domain.Entities.Models;
using Hotel.Infrastructure.Presistence;
using Hotel.Presentation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Hotel.Presentation.Controllers
{
	public class HomeController : Controller
	{
		private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;

		public HomeController(IAuthenticationSchemeProvider authenticationSchemeProvider)
		{
			_authenticationSchemeProvider = authenticationSchemeProvider;
		}

		[BindProperty]
		public LoginViewModel LoginData { get; set; } = new LoginViewModel();

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private bool ValidateCredentials()
		{
			return LoginData.UserName == "admin" && LoginData.Password == "admin";
		}

		[HttpPost]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync();

			return View();
		}
	}
}