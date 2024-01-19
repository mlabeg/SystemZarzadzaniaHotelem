using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;

namespace Hotel.Infrastructure.Repositories
{
	internal class RezerwacjeRepository : Hotel.Domain.Interfaces.IRezerwacjeRepository
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

		public async Task UsunRezerwacje(int id)
		{
			var rezerwacja = _dbContext.Rezerwacje.FirstOrDefault(x => x.Id == id);

			if (rezerwacja != null)
			{
				_dbContext.Rezerwacje.Remove(rezerwacja);
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}