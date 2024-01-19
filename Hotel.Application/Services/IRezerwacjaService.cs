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
        Task DodajRezerwacje(Hotel.Domain.Entities.Rezerwacja rezerwacja);

        public Task UsunRezerwacje(int id);

        public void SprawdzenieSzczegolowRezerwacji();

        public void ZmianaDanychRezerwacjiUz();

        public List<Hotel.Domain.Entities.Rezerwacja> PokazAktualneRezerwacje();

        public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji();
    }
}