using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain.Entities.Models
{
    public class CheckAvailabilityModel
    {
        [Required(ErrorMessage = "Podaj datę początkową")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Podaj datę końcową")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        [Required(ErrorMessage = "Podaj liczbę osób")]
        [Range(1, 8, ErrorMessage = "Podaj wartość między 1 a 8")]
        public int NumberOfGuests { get; set; }

        public IList<Room> ListOfRooms { get; set; } = new List<Room>();
    }
}