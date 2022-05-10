using Ecommerce.Models;

namespace ClickPick.CustomModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public FilterViewModel Filter { get; set; }
    }
}
