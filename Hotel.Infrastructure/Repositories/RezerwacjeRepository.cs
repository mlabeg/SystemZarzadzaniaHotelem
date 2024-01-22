using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Repositories
{
	internal class RezerwacjeRepository : Domain.Interfaces.IRezerwacjeRepository
	{
		private readonly HotelDbContext _dbContext;

		public RezerwacjeRepository(HotelDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task DodajRezerwacje(Rezerwacja rezerwacja)
		{
			_dbContext.Add(rezerwacja);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Rezerwacja>> PokazWszystkieRezerwacje()
			=> await _dbContext.Rezerwacje
			.Include(p => p.Pokoj)
			.Include(o => o.Osoba)
			.ToListAsync();

		/*{
			/*List<Rezerwacja> listaRezerwacji = new List<Rezerwacja>();

			if (_dbContext.Rezerwacje.Any(r=>r.Id))
			{
				listaRezerwacji = _dbContext.Rezerwacje
					.Include(p => p.Pokoj)
					.Include(o => o.Osoba)
					.ToList();
			}
			return await _dbContext.Rezerwacje.ToListAsync();
		}*/

		public async Task UsunRezerwacje(int id)
		{//TODO zmiana usuwania rezerwacji na zmianę jej statusu
			var rezerwacja = _dbContext.Rezerwacje.FirstOrDefault(x => x.Id == id);

			if (rezerwacja != null)
			{
				_dbContext.Rezerwacje.Remove(rezerwacja);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}