using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
	public class Pokoj
	{
		public int Id { get; set; }
		public int Numer { get; set; }
		public int LiczbaMiejsc { get; set; }
		public int CenaZaNoc { get; set; }
		public string Opis { get; set; }
		public PokojTyp PokojTyp { get; set; }
		public int PokojTypId { get; set; }

		//public bool CzyWolny { get; set; }//jak się usunie to nie działa BD

		public Pokoj()
		{
			Opis = "";
			//CzyWolny = true;
		}
	}
}