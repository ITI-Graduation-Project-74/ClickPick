
using ClickPick.Models;
using Ecommerce.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name ="Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public double Price { get; set; }
        public Size? Size { get; set; }
        public bool? IsApproved { get; set; }


        public string Discount { get; set; }

        [Display(Name = "Quantity")]
        public string ImgUrl { get; set; }


        //Relation products with catagory

        
        public virtual Brand Brand { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }


        [ForeignKey("CatagoryId")]
        public virtual Category Catagory { get; set; }
        public int CatagoryId { get; set; }

  
        //Relation with User as Vendor

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //Relation With Product Imgs

        public virtual List<ProductImg> ProductImgs { get; set; }

        // Relation With OrderDetails 
        public virtual List <Product_OrderDetails> Product_OrderDetails { get; set; }


    }
}
