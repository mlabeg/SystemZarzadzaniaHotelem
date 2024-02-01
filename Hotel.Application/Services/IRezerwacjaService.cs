using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public interface IRezerwacjaService
    {
        public Task AddReservation(Domain.Entities.Rezerwacja rezerwacja);

        public Task<bool> DeleteReservation(int id);

        public Task<IEnumerable<Domain.Entities.Rezerwacja>> GetAll(string? wybor);

        public Task<Domain.Entities.Rezerwacja?> GetById(int id);

        public Task<IEnumerable<Domain.Entities.Rezerwacja>> GetByDate(DateTime dataOd, DateTime dataDo);

        public Task<List<int>>? GetPokojIdByDate(DateTime dataOd, DateTime dataDo);

        //TODO dodać poniższe
        //public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji();
        //public List<Hotel.Domain.Entities.Rezerwacja> PokazAktualneRezerwacje();
    }
}