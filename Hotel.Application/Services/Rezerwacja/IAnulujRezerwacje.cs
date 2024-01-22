using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Rezerwacja
{
	public interface IAnulujRezerwacje
	{
		public Task AnulowanieRezerwacji(int id);
	}
}