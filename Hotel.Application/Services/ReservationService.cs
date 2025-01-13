using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal class ReservationService : IReservationService
    {
        private readonly IReservationRepository _rezerwacjeRepository;

        public ReservationService(IReservationRepository rezerwacjeRepository)
        {
            _rezerwacjeRepository = rezerwacjeRepository;
        }

        public async Task AddReservationAsync(Reservation rezerwacja)
        {
            await _rezerwacjeRepository.AddReservation(rezerwacja);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            return await _rezerwacjeRepository.DeleteReservation(id);
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync(string? wybor)
        {
            var rezerwacje = await _rezerwacjeRepository.GetAll(wybor);

            return rezerwacje;
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _rezerwacjeRepository.GetById(id);
        }

        public async Task<IEnumerable<Reservation>> GetByDateAsync(DateTime dataOd, DateTime dataDo)
        {
            return await _rezerwacjeRepository.GetByDate(dataOd, dataDo);
        }

        public async Task<List<int>>? GetPokojIdByDateAsync(DateTime dataOd, DateTime dataDo)
        {
            return await _rezerwacjeRepository.GetRoomIdByDate(dataOd, dataDo);
        }
    }
}