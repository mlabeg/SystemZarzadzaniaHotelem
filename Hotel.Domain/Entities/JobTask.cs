using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class JobTask
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Status { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string Priorytet { get; set; }
        public int? PersonelId { get; set; }
        public int HotelId { get; set; }
        public Employee Personel { get; set; }
        public Hotel Hotel { get; set; }
    }
}
