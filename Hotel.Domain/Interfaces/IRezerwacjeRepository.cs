using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interefaces
{
    public interface IRezerwacjeRepository
    {
        Task UtworzRezerwacje(Rezerwacja rezerwacja);
    }
}