using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickPick.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }


        // Relation With Product 
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        // Relation With ApplicationUser
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
