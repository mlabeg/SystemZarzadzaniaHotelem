using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Authentication.Internals
{
	internal class CookieDataModel
	{
		public string SchemeName { get; set; }
		public string UserId { get; set; }
		public string Username { get; set; }
		public DateTimeOffset ExpiresTimeStamp { get; set; }
	}
}