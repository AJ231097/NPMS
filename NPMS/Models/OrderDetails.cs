using System.ComponentModel.DataAnnotations;

namespace NPMS.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public string PassName { get; set; }
        public int PassPrice { get; set; }
    }
}
