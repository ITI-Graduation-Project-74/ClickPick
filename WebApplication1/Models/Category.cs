using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Category
    {
        //Intializing Lists
        public Category()
        {
            Products = new List<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }

        //Relation products with category
        public virtual List<Product> Products { get; set; }


    }
}
