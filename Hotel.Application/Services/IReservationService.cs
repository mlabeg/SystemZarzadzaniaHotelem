using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public interface IReservationService
    {
        public Task AddReservationAsync(Domain.Entities.Reservation rezerwacja);

        public Task<bool> DeleteReservationAsync(int id);

        public Task<IEnumerable<Domain.Entities.Reservation>> GetAllAsync(string? wybor);

        public Task<Domain.Entities.Reservation?> GetByIdAsync(int id);

        public Task<IEnumerable<Domain.Entities.Reservation>> GetByDateAsync(DateTime dataOd, DateTime dataDo);

        public Task<List<int>>? GetPokojIdByDateAsync(DateTime dataOd, DateTime dataDo);
    }
}