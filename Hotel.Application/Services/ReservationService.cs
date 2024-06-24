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

        public async Task AddReservation(Reservation rezerwacja)
        {
            await _rezerwacjeRepository.AddReservation(rezerwacja);
        }

        public async Task<bool> DeleteReservation(int id)
        {
            return await _rezerwacjeRepository.DeleteReservation(id);
        }

        public async Task<IEnumerable<Reservation>> GetAll(string? wybor)
        {
            var rezerwacje = await _rezerwacjeRepository.GetAll(wybor);

            return rezerwacje;
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _rezerwacjeRepository.GetById(id);
        }

        public async Task<IEnumerable<Reservation>> GetByDate(DateTime dataOd, DateTime dataDo)
        {
            return await _rezerwacjeRepository.GetByDate(dataOd, dataDo);
        }

        public async Task<List<int>>? GetPokojIdByDate(DateTime dataOd, DateTime dataDo)
        {
            return await _rezerwacjeRepository.GetRoomIdByDate(dataOd, dataDo);
        }
    }
}