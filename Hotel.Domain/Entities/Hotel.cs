using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string NazwaHotelu { get; set; }
        public string LokalizacjaHotelu { get; set; }
        public int LiczbaPokoi { get; set; }
        public string Kategoria { get; set; }
        public ICollection<Room> Pokoje { get; set; }
        public ICollection<Employee> Personel { get; set; }
        public ICollection<JobTask> Zadania { get; set; }
    }
}
