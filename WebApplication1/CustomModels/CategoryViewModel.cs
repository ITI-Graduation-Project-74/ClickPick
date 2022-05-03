using Ecommerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.CustomModels
{
    public class CategoryViewModel
    {
        
      

         public int Id { get; set; }
        public string CategoryName { get; set; }
        public IFormFile ProfileImage { get; set; }

      

    }
}
