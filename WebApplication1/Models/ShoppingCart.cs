using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        
        [Range(1,20,ErrorMessage="Please enter a Value between 1 To 20")]
        public int Count { get; set; }

        // Relation With Product 
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        // Relation With ApplicationUser
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]       
        public virtual ApplicationUser ApplicationUser { get; set; }

        // Price But Not Mapped in Database

        [NotMapped]
        public  double Price { get; set; }

        ////order details relation
        //[ForeignKey("OrderDetailsID")]

        //public int? OrderDetailsID { get; set; }
        //public virtual OrderDetails OrderDetails { get; set; }  

    }
}
