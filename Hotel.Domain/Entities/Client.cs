using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
	public class Client
	{
		public int Id { get; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
        public string? Preferences { get; set; }
        public ICollection< Notification>? Notification{ get; set; }

        public Client()
		{
		}

		public Client(int _id, string _name, string _surname, string _phone, string _email)
		{
			Id = _id;
			Name = _name;
			Surname = _surname;
			PhoneNumber = _phone;
			EmailAddress = _email;
		}
	}
}