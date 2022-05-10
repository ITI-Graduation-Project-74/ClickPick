using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class OrderDetails
    {
        public OrderDetails()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }

        //Relation with OrderHeader

        [ForeignKey("OrderHeaderId")]
        public int OrderHeaderId { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }


        //Relation with product
       
        public virtual List<Product> Products { get; set; }

        //Relation with copoun
        public int? CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        //Relation with payment
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
    }

}
