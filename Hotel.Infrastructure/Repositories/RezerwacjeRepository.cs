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

        public async Task DodajRezerwacje(Reservation rezerwacja)
        {
            _dbContext.Add(rezerwacja);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> ZwrocWszystkie(string? sortowanie)
        {
            IQueryable<Reservation> rezerwacje = _dbContext.Reservations
                .Include(p => p.Room)
                .Include(p => p.Room.Type)
                .Include(o => o.Person);

            switch (sortowanie)
            {
                case "DataOd":
                    rezerwacje = rezerwacje.OrderBy(r => r.DateFrom);
                    break;

                case "DataDo":
                    rezerwacje = rezerwacje.OrderBy(r => r.DateTo);
                    break;

                case "Id":
                    rezerwacje = rezerwacje.OrderBy(r => r.Id);
                    break;

                case "Ststus":
                    rezerwacje = rezerwacje.OrderBy(r => r.Status);
                    break;

                default:
                    rezerwacje = rezerwacje.OrderBy(r => r.DateFrom);
                    break;
            }
            return await rezerwacje.ToListAsync();
        }

        public async Task<bool> UsunRezerwacje(int id)
        {
            var rezerwacja = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (rezerwacja == null)
            {
                return false;
            }

            _dbContext.Reservations.Remove(rezerwacja);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Reservation?> WyszukajPoId(int id)
        {
            return await _dbContext.Reservations
                .Include(o => o.Person)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> WyszukajWTermminie(DateTime dataOd, DateTime dataDo)
        {
            var rezerwacje = await _dbContext.Reservations.Where(r =>
                (r.DateFrom <= dataOd && r.DateTo >= dataOd) ||
                (r.DateFrom <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo <= dataOd && r.DateTo >= dataOd && r.DateTo <= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo)).ToListAsync();

            return rezerwacje;
        }

        public async Task<List<int>>? WyszukajPokojIdWTermminie(DateTime dataOd, DateTime dataDo)
        {
            var rezerwacje = await _dbContext.Reservations.Where(r =>
                (r.DateFrom <= dataOd && r.DateTo >= dataOd) ||
                (r.DateFrom <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo <= dataOd && r.DateTo >= dataOd && r.DateTo <= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo)).ToListAsync();

            List<int> pokojeId = new List<int>();

            if (!rezerwacje.IsNullOrEmpty())
            {
                pokojeId = rezerwacje.Select(p => p.RoomId).ToList();
            }

            return pokojeId;
        }
    }
}