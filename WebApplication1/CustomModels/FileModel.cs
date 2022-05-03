using System.ComponentModel.DataAnnotations;
using System.Web;
namespace Ecommerce.CustomModels

{
    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public IFormFile[] files { get; set; }

    }
}
