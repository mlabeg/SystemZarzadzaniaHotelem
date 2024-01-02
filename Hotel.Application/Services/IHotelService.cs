using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    internal interface IHotelService
    {
        public List<Pokoj> GetWolnePokojeList();
    }
}