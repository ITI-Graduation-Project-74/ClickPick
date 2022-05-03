using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class ApplicationUser : IdentityUser
    {

        //Intializing Lists

        public ApplicationUser()
        {
            Products = new List<Product>();
        }

        //As Regular User
        public string  Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //As Vendor
        public string StoreName { get; set; }

        // Relation With OrderHeader
        public virtual List<OrderHeader> OrderHeaders { get; set; }

        //Relation With Product as Vendor
        public virtual List<Product> Products { get; set; }

        





    }
}
