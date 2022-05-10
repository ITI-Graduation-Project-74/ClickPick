using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    
    public class OrderHeader
    {

        public OrderHeader()
        {
            OrderDetails = new List<OrderDetails>();
        }
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Shipping { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string? Note { get; set; }

        public string? BillingAddress { get; set; }

        // Stripe Id
        public string? SessionId { get; set; }

        public string? PaymentStripeId { get; set; }

 
        // Relation With ApplicationUser
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        //Relation With OrderDetails 
        public virtual List<OrderDetails> OrderDetails { get; set; }



    }
}
