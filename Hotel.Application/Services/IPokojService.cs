using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
	public interface IPokojService
	{
		Task DodajPokoj(Pokoj pokoj);

		public void ZmienStatus();

		public Task<Pokoj?> WyszukajPoId(int number);

		//TODO zmień nazwę tej metody:
		public Task<bool> PokojeAny();
	}
}