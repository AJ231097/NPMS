using System.ComponentModel.DataAnnotations;

namespace NPMS.Models
{
    public class Reservations
    {
        [Key]
        public Guid Rid { get; set; }
        [Required]
        public string ReservationName{ get; set; }
        [Required]
        public string TypeOfEvent { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string ReservationEmail { get; set; }
        [Required]

        [DataType(DataType.Date)]
        public DateTime? ReservationDate { get; set; }
        [Required]

        public string ParkName { get; set; }

    }
}
