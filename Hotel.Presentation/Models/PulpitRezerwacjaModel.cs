using Hotel.Domain.Entities;
using Microsoft.Identity.Client;

namespace Hotel.Presentation.Models
{
    public class PulpitRezerwacjaModel
    {
        public int Id { get; set; }

        public DateTime DataOd { get; set; }

        public DateTime DataDo { get; set; }

        public int PokojNumer { get; set; }

        public string PokojTyp { get; set; }

        public string ImieINazwisko { get; set; }

        public string Status { get; set; }
    }
}