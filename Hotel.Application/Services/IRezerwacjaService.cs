using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
	public interface IRezerwacjaService
	{
		Task DodajRezerwacje(Hotel.Domain.Entities.Rezerwacja rezerwacja);

		public Task UsunRezerwacje(int id);

		public void SprawdzenieSzczegolowRezerwacji();

		public void ZmianaDanychRezerwacjiUz();

		public Task<IEnumerable<Hotel.Domain.Entities.Rezerwacja>> PokazWszystkieRezerwacje();

		//TODO dodać poniższe
		//public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji();
		//public List<Hotel.Domain.Entities.Rezerwacja> PokazAktualneRezerwacje();
	}
}