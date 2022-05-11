using ClickPick.Models;
using Ecommerce.Models.Services;

namespace Ecommerce.Models.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public  IBaseRepository<ApplicationUser>     ApplicationUsers { get;}
   
        public  IBaseRepository<Category>            Categories { get; }
        public  IBaseRepository<Coupon>              Coupons { get; }
        public IBaseRepository<Payment>              Payments { get; }
        public  IBaseRepository<Product>             Products { get; }
        public  IBaseRepository<ShoppingCart>        ShoppingCarts { get; }

        public IBaseRepository<ProductImg>           ProductImgs { get; }
        public  IShoppingCartService ShoppingCartServices { get; }

        public IBaseRepository<OrderHeader> OrderHeaders { get; }

        public IBaseRepository<OrderDetails> OrderDetails { get; }

        public IBaseRepository<WishList> WishLists { get; }

        public IBaseRepository<Brand> Brands { get; }

        public IBaseRepository<Product_OrderDetails> Product_OrderDetails { get; }

        int Complete();
    }
}
