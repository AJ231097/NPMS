using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NPMS.Models
{
    
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }

        public string EventDescription { get; set; }
        


    }
}
