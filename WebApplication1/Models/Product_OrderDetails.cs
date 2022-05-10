using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Product_OrderDetails
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        [ForeignKey("OrderDetails")]
        public int OrderDetailsId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }

   
    }
}
