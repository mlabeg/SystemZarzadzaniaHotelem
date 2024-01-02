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
        public void RejestracjaUzytkownikaUz(Domain.Entities.UzytkownikZarejestrowany uz);

        public void ZmianaImieniaUz(Domain.Entities.UzytkownikZarejestrowany uz);

        public void UsunKontoUz(Domain.Entities.UzytkownikZarejestrowany uz);

        public void ZmianaTelUz(Domain.Entities.UzytkownikZarejestrowany uz);

        public void ZmianaEmailUz(Domain.Entities.UzytkownikZarejestrowany uz);

        public void ZmianaNazwiskaUz(Domain.Entities.UzytkownikZarejestrowany uz);
    }
}