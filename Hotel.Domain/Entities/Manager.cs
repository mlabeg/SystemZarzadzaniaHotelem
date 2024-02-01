using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
	public class Manager : Employee
	{
		public Manager()
		{ }

		public Manager(int _id, string _imie, string _nazwisko, string _numerTelefonu, string _adresmail)
			: base(_id, _imie, _nazwisko, _numerTelefonu, _adresmail)
		{
			Position = "Kierownik";
		}
	}
}