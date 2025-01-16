using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Notification
    {
        public int Id{ get; set; }
        public int GoscId { get; set; }
        public string TypPowiadomienia { get; set; }
        public string Tresc { get; set; }
        public DateTime DataWyslania { get; set; }
        public Client? Client { get; set; }
    }
}
