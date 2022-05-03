using Ecommerce.Models;

namespace Ecommerce.CustomModels
{
    public class CtegoryViewModel_Category
    {
        public CtegoryViewModel_Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile ProfileImg { get; set; }


        //Relation products with category
        public virtual List<Product> Products { get; set; }
    }
}
