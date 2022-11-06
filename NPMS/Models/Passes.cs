using System.ComponentModel.DataAnnotations;

namespace NPMS.Models
{
    public class Passes
    {
        [Key]
        public int Id { get; set; }
        public string PassName { get; set; }
        public int PassPrice { get; set; }

    }
}
