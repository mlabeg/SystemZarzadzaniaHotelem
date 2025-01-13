using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class UserUnregistered : Person
    {
        public UserUnregistered()
        {
        }

        public UserUnregistered(int _id, string _imie, string _nazwisko, string _numerTelefonu, string _adresmail)
            : base(_id, _imie, _nazwisko, _numerTelefonu, _adresmail) { }
    }
}