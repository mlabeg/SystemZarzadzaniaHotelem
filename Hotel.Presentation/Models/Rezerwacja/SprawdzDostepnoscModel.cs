using Hotel.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Presentation.Models.Rezerwacja
{
    public class SprawdzDostepnoscModel
    {
        [Required(ErrorMessage = "Podaj datę początkową")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataOd { get; set; } = null;

        [Required(ErrorMessage = "Podaj datę końcową")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDo { get; set; } = null;

        [Required(ErrorMessage = "Podaj liczbę osób")]
        [Range(1, 8, ErrorMessage = "Podaj wartość między 1 a 8")]
        public int? IleOsob { get; set; }

        public IList<Pokoj> ListaPokoi { get; set; } = new List<Pokoj>();
    }
}