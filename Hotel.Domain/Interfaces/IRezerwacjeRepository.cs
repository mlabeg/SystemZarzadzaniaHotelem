using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
	public interface IRezerwacjeRepository
	{
		Task DodajRezerwacje(Rezerwacja rezerwacja);

		Task UsunRezerwacje(int id);

		Task<IEnumerable<Rezerwacja>> PokazWszystkieRezerwacje();
	}
}