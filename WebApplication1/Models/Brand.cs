using Ecommerce.Models;

namespace ClickPick.Models
{
    public class Brand
    {
        public Brand()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ImgUrl { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
