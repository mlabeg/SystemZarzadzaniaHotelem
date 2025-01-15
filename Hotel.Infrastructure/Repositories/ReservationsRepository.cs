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
    internal class ReservationsRepository : Domain.Interfaces.IReservationRepository
    {
        private readonly HotelDbContext _dbContext;

        public ReservationsRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddReservation(Reservation reservation)
        {
            _dbContext.Add(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAll(string? sort)
        {
            IQueryable<Reservation> reservations = _dbContext.Reservations
                .Include(p => p.Room)
                .Include(p => p.Room.Type)
                .Include(o => o.Client);

            switch (sort)
            {
                case "DataOd":
                    reservations = reservations.OrderBy(r => r.DateFrom);
                    break;

                case "DataDo":
                    reservations = reservations.OrderBy(r => r.DateTo);
                    break;

                case "Id":
                    reservations = reservations.OrderBy(r => r.Id);
                    break;

                case "Ststus":
                    reservations = reservations.OrderBy(r => r.Status);
                    break;

                default:
                    reservations = reservations.OrderBy(r => r.DateFrom);
                    break;
            }
            return await reservations.ToListAsync();
        }

        public async Task<bool> DeleteReservation(int id)
        {
            var reservation = await _dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservation == null)
            {
                return false;
            }

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _dbContext.Reservations
                .Include(o => o.Client)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetByDate(DateTime dataOd, DateTime dataDo)
        {
            var rezerwacje = await _dbContext.Reservations.Where(r =>
                (r.DateFrom <= dataOd && r.DateTo >= dataOd) ||
                (r.DateFrom <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo <= dataOd && r.DateTo >= dataOd && r.DateTo <= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo)).ToListAsync();

            return rezerwacje;
        }

        public async Task<List<int>>? GetRoomIdByDate(DateTime dataOd, DateTime dataDo)
        {
            var reservations = await _dbContext.Reservations.Where(r =>
                (r.DateFrom <= dataOd && r.DateTo >= dataOd) ||
                (r.DateFrom <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo && r.DateTo >= dataDo) ||
                (r.DateTo <= dataOd && r.DateTo >= dataOd && r.DateTo <= dataDo) ||
                (r.DateTo >= dataOd && r.DateTo <= dataDo)).ToListAsync();

            List<int> pokojeId = new List<int>();

            if (!reservations.IsNullOrEmpty())
            {
                pokojeId = reservations.Select(p => p.RoomId).ToList();
            }

            return pokojeId;
        }
    }
}