using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Rezerwacja
{
    internal class AnulowanieRezerwacji : IAnulowanieRezerwacji
    {
        public AnulowanieRezerwacji()
        {
        }

        public Task anulowanieRezerwacji()
        {
            return Task.CompletedTask;
        }
    }
}