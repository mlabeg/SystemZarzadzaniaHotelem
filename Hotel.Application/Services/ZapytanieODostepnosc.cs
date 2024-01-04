using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal class ZapytanieODostepnosc : IZapytanieODostepnosc
    {
        public ZapytanieODostepnosc(Hotel dbContext)
        {
        }

        public List<Pokoj> DostepnePokoje(DateTime dataOd, DateTime dataDo, int iloscOsob)
        {
        }
    }
}