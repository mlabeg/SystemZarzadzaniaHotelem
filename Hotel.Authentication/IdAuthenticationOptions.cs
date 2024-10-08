using Hotel.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace Hotel.IdAuthentication
{
	public class IdAuthenticationOptions : AuthenticationSchemeOptions
	{
		public string CookieName { get; set; } = IdAuthenticationDefaults.CookieName;
	}
}