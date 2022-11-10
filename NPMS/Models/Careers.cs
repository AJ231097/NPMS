using System.ComponentModel.DataAnnotations;

namespace NPMS.Models
{
    public class Careers
    {
        [Key]
        public Guid CareerId { get; set; }
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public string CareerRecruiter { get; set; }
        public string CareerPlace { get; set; }
    }
}
