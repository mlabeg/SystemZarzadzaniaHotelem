using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal interface IKierownikService
    {
        public void DodajPracownika();

        public void UsunPracowanika();

        public void ZmienStanowsko();
    }
}