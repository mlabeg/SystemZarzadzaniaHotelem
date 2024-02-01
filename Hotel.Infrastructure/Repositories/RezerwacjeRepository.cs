using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Entities;
using Hotel.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<IEnumerable<Rezerwacja>> ZwrocWszystkie(string? sortowanie)
        {
            IQueryable<Rezerwacja> rezerwacje = _dbContext.Rezerwacje
                .Include(p => p.Pokoj)
                .Include(p => p.Pokoj.Type)
                .Include(o => o.Osoba);

            switch (sortowanie)
            {
                case "DataOd":
                    rezerwacje = rezerwacje.OrderBy(r => r.DataOd);
                    break;

                case "DataDo":
                    rezerwacje = rezerwacje.OrderBy(r => r.DataDo);
                    break;

                case "Id":
                    rezerwacje = rezerwacje.OrderBy(r => r.Id);
                    break;

                case "Ststus":
                    rezerwacje = rezerwacje.OrderBy(r => r.Status);
                    break;

                default:
                    rezerwacje = rezerwacje.OrderBy(r => r.DataOd);
                    break;
            }
            return await rezerwacje.ToListAsync();
        }

        public async Task<bool> UsunRezerwacje(int id)
        {
            var rezerwacja = await _dbContext.Rezerwacje.FirstOrDefaultAsync(x => x.Id == id);

            if (rezerwacja == null)
            {
                return false;
            }

            _dbContext.Rezerwacje.Remove(rezerwacja);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Rezerwacja?> WyszukajPoId(int id)
        {
            return await _dbContext.Rezerwacje
                .Include(o => o.Osoba)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Rezerwacja>> WyszukajWTermminie(DateTime dataOd, DateTime dataDo)
        {
            var rezerwacje = await _dbContext.Rezerwacje.Where(r =>
                (r.DataOd <= dataOd && r.DataDo >= dataOd) ||
                (r.DataOd <= dataDo && r.DataDo >= dataDo) ||
                (r.DataDo >= dataOd && r.DataDo <= dataDo && r.DataDo >= dataDo) ||
                (r.DataDo <= dataOd && r.DataDo >= dataOd && r.DataDo <= dataDo) ||
                (r.DataDo >= dataOd && r.DataDo <= dataDo)).ToListAsync();

            return rezerwacje;
        }

        public async Task<List<int>>? WyszukajPokojIdWTermminie(DateTime dataOd, DateTime dataDo)
        {
            var rezerwacje = await _dbContext.Rezerwacje.Where(r =>
                (r.DataOd <= dataOd && r.DataDo >= dataOd) ||
                (r.DataOd <= dataDo && r.DataDo >= dataDo) ||
                (r.DataDo >= dataOd && r.DataDo <= dataDo && r.DataDo >= dataDo) ||
                (r.DataDo <= dataOd && r.DataDo >= dataOd && r.DataDo <= dataDo) ||
                (r.DataDo >= dataOd && r.DataDo <= dataDo)).ToListAsync();

            List<int> pokojeId = new List<int>();

            if (!rezerwacje.IsNullOrEmpty())
            {
                pokojeId = rezerwacje.Select(p => p.PokojId).ToList();
            }

            return pokojeId;
        }
    }
}