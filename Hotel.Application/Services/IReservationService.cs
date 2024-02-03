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
		public Task AddReservation(Domain.Entities.Reservation rezerwacja);

		public Task<bool> DeleteReservation(int id);

		public Task<IEnumerable<Domain.Entities.Reservation>> GetAll(string? wybor);

		public Task<Domain.Entities.Reservation?> GetById(int id);

		public Task<IEnumerable<Domain.Entities.Reservation>> GetByDate(DateTime dataOd, DateTime dataDo);

		public Task<List<int>>? GetPokojIdByDate(DateTime dataOd, DateTime dataDo);

		//TODO dodać poniższe
		//public List<Hotel.Domain.Entities.Rezerwacja> PokazHistorieRezerwacji();
		//public List<Hotel.Domain.Entities.Rezerwacja> PokazAktualneRezerwacje();
	}
}