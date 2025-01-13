using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
	internal interface IOsobaService
	{
		Task AddPerson(Person osoba);

		public void ZmianaImienia();

		public void ZmianaNazwiskoa();

		public void ZmianaEmail();

		public void ZmianaTel();

		public void ZmianaHasla();

		public void UsunKonto();

		public void Logowanie();
	}
}