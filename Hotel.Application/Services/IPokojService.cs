using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal interface IPokojService
    {
        Task DodajPokoj(Pokoj pokoj);

        //public bool CzyWolnyWTerminie(DateTime dataOd, DateTime dataDo);

        public void ZmienStatus();

        public Pokoj GetPokojByNumber(int number);
    }
}