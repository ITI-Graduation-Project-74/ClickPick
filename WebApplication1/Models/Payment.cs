using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string Method { get; set; }


        //Relation order with payment
        



    }
}
