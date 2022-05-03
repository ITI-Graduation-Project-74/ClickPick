using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Coupon 
    {
        //Intializing Lists
        public Coupon()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; } 
        public int Percentage { get; set; }

        //Relation order with coupon
        

    }
}
