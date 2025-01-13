using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task AddReservation(Reservation reservation);

        public Task<bool> DeleteReservation(int id);

        Task<IEnumerable<Reservation>> GetAll(string? wybor);

        Task<Reservation?> GetById(int id);

        public Task<IEnumerable<Reservation>> GetByDate(DateTime dataOd, DateTime dataDo);

        public Task<List<int>>? GetRoomIdByDate(DateTime dataOd, DateTime dataDo);
    }
}