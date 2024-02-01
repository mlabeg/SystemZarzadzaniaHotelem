using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain;

namespace Hotel.Application.Services
{
    internal interface IUzytkownikNieZarService
    {
        public void RejestracjaUzytkownikaUz(Domain.Entities.UserRegistered uz);

        public void ZmianaImieniaUz(Domain.Entities.UserRegistered uz);

        public void UsunKontoUz(Domain.Entities.UserRegistered uz);

        public void ZmianaTelUz(Domain.Entities.UserRegistered uz);

        public void ZmianaEmailUz(Domain.Entities.UserRegistered uz);

        public void ZmianaNazwiskaUz(Domain.Entities.UserRegistered uz);
    }
}