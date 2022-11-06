using System.ComponentModel.DataAnnotations;

namespace NPMS.Models
{
    public class Cart
    {
        [Key]
       public Guid OrderId { get; set; }
       public Decimal TotalAmount { get; set; }

       public string UserId { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
        public Cart()
        {
            OrderDetails = new List<OrderDetails>();
        }

    }
}
