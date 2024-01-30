using Microsoft.Identity.Client.AuthScheme.PoP;
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
	public class PokojeRepository : Domain.Interfaces.IPokojeRepository
	{
		private readonly HotelDbContext _dbContext;

		public PokojeRepository(HotelDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task DodajPokoj(Pokoj pokoj)
		{
			_dbContext.Add(pokoj);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> PokojeAny()
		{
			return await _dbContext.Pokoje.AnyAsync();
		}

		public async Task<Pokoj?> WyszukajPoId(int id)
		{
			return await _dbContext.Pokoje
				.Include(t => t.PokojTyp)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<Pokoj>> ZwrocWszystkie()
		{
			return await _dbContext.Pokoje.ToListAsync();
		}

		public async Task<IEnumerable<Pokoj>> ZwrocDostepne(IEnumerable<Rezerwacja> rezerwacje, int iloscOsob)
		{
			var pokojePoIlosc = _dbContext.Pokoje.Where(p => p.LiczbaMiejsc >= iloscOsob).AsAsyncEnumerable();

			var dostepnePokoje = await pokojePoIlosc.Where(p => !rezerwacje.Any(r => r.PokojId == p.Id)).ToListAsync();

			return dostepnePokoje;
		}

		public async Task<IEnumerable<Pokoj>> ZwrocDostepne(List<int> zarezerwowanePokojId, int iloscOsob)
		{
			return await _dbContext.Pokoje
				.Where(p => p.LiczbaMiejsc >= iloscOsob)
				.Where(p => !zarezerwowanePokojId.Any(r => r.Equals(p.Id)))
				.ToListAsync();
		}
	}
}