using Hotel.IdAuthentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hotel.Authentication.Internals
{
	internal class IdAuthenticationHandler : SignInAuthenticationHandler<IdAuthenticationOptions>
	{
		public IdAuthenticationHandler(IOptionsMonitor<IdAuthenticationOptions> options
			, ILoggerFactory logger
			, UrlEncoder encoder
			, ISystemClock clock) : base(options, logger, encoder, clock)
		{
		}

		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			if (Request.Cookies.TryGetValue(Options.CookieName, out var cookieValue))
			{
				var dataModel = ReadCookie(cookieValue);

				if (dataModel == null)
				{
					return Task.FromResult(AuthenticateResult.NoResult());
				}

				if (dataModel.ExpiresTimeStamp < DateTimeOffset.UtcNow)
				{
					return Task.FromResult(AuthenticateResult.Fail("Cookie expired"));
				}
				var cp = GetPrincipalFromCookie(dataModel);

				var ticket = new AuthenticationTicket(cp, Scheme.Name);
				return Task.FromResult(AuthenticateResult.Success(ticket));
			}
			else
			{
				return Task.FromResult(AuthenticateResult.NoResult());
			}
		}

		protected override Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties? properties)
		{
			var model = new CookieDataModel
			{
				ExpiresTimeStamp = GetSessionExpiration(properties),
				SchemeName = Scheme.Name,
				UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value,
				Username = user.FindFirst(ClaimTypes.Name)?.Value
			};

			var cookieValue = WriteCookie(model);
			Response.Cookies.Append(Options.CookieName, cookieValue, new Microsoft.AspNetCore.Http.CookieOptions
			{
				Expires = model.ExpiresTimeStamp,
				HttpOnly = true,
				Secure = true
			});

			return Task.CompletedTask;
		}

		private string WriteCookie(CookieDataModel model)
		{
			return JsonSerializer.Serialize(model);
		}

		protected override Task HandleSignOutAsync(AuthenticationProperties? properties)
		{
			Response.Cookies.Delete(Options.CookieName);
			return Task.FromResult(AuthenticateResult.Success);
		}

		private CookieDataModel? ReadCookie(string cookieValue)
		{
			try
			{
				var data = JsonSerializer.Deserialize<CookieDataModel>(cookieValue);
				if (data?.SchemeName == Scheme.Name)
					return data;
				else
					return null;
			}
			catch
			{
				return null;
			}
		}

		private ClaimsPrincipal GetPrincipalFromCookie(CookieDataModel data)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name,data.Username)/*,
                new Claim(ClaimTypes.NameIdentifier, data.UserId)*/
            };

			var identity = new ClaimsIdentity(claims, Scheme.Name);
			return new ClaimsPrincipal(identity);
		}

		private DateTimeOffset GetSessionExpiration(AuthenticationProperties? props)
		{
			var result = DateTimeOffset.Now.AddHours(1);

			if (props != null && props.ExpiresUtc.HasValue)
			{
				result = props.ExpiresUtc.Value;
			}
			return result;
		}
	}
}