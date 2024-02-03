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
    internal class RezerwacjaService : IReservationService
    {
        private readonly IRezerwacjeRepository _rezerwacjeRepository;

        public RezerwacjaService(IRezerwacjeRepository rezerwacjeRepository)
        {
            _rezerwacjeRepository = rezerwacjeRepository;
        }

        public async Task AddReservation(Reservation rezerwacja)
        {
            await _rezerwacjeRepository.DodajRezerwacje(rezerwacja);
        }

        public async Task<bool> DeleteReservation(int id)
        {
            return await _rezerwacjeRepository.UsunRezerwacje(id);
        }

        public async Task<IEnumerable<Reservation>> GetAll(string? wybor)
        {
            var rezerwacje = await _rezerwacjeRepository.ZwrocWszystkie(wybor);

            return rezerwacje;
        }

        public async Task<Reservation?> GetById(int id)
        {
            return await _rezerwacjeRepository.WyszukajPoId(id);
        }

        public async Task<IEnumerable<Reservation>> GetByDate(DateTime dataOd, DateTime dataDo)
        {
            return await _rezerwacjeRepository.WyszukajWTermminie(dataOd, dataDo);
        }

        public async Task<List<int>>? GetPokojIdByDate(DateTime dataOd, DateTime dataDo)
        {
            return await _rezerwacjeRepository.WyszukajPokojIdWTermminie(dataOd, dataDo);
        }
    }
}