using System.ComponentModel.DataAnnotations;

namespace ClickPick.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
     [StringLength(100)]
        [Required]
        public string Name { get; set; }
       [StringLength(50), Required]

        public string Email { get; set; }
     // [StringLength(1000), Required]

        public string Message { get; set; }
      //  [StringLength(15), Required]

        public string PhoneNumber { get; set; }
       // [StringLength(50)]

        public string Subject { get; set; }
    }
}
