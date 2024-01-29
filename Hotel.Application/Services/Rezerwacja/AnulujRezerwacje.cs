using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Rezerwacja
{
	//TODO ANULOWANIE zammień na to, żeby to nie usuwało wpisu w BD, ale zmieniało status na "Anulowane"

	internal class AnulujRezerwacje : IAnulujRezerwacje
	{
		private readonly IRezerwacjeRepository _rezerwacjeRepository;

		public AnulujRezerwacje(IRezerwacjeRepository rezerwacjeRepository)
		{
			_rezerwacjeRepository = rezerwacjeRepository;
		}

		public Task AnulowanieRezerwacji(int id)
		{
			_rezerwacjeRepository.UsunRezerwacje(id);
			return Task.CompletedTask;
		}
	}
}