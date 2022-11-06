using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NPMS.Models
{
    public class Parks
    {
        [Key]
        [Required]
        public int ParkId { get; set; }
        [Required]
        public string ParkName { get; set; }
        [Required]
        public string ParkDescription { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name ="Park")]
        public string ParkImageUrl { get; set; }
    }
}
