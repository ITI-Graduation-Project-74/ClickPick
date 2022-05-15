using ClickPick.Models;
using Ecommerce.Data;
using Ecommerce.Models.Services;

namespace Ecommerce.Models.Repositories.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ApplicationUsers = new BaseRepository<ApplicationUser>(context);
            
            Categories       = new BaseRepository<Category>(context);
            Coupons          = new BaseRepository<Coupon>(context);
            Payments         = new BaseRepository<Payment>(context);
            Products         = new BaseRepository<Product>(context);
            ShoppingCarts    = new BaseRepository<ShoppingCart>(context);
            ProductImgs      = new BaseRepository<ProductImg>(context);
            OrderHeaders = new BaseRepository<OrderHeader>(context);
            OrderDetails = new BaseRepository<OrderDetails>(context);

            Product_OrderDetails = new BaseRepository<Product_OrderDetails> (context);

            Reviews = new BaseRepository<Review>(context);

            WishLists = new BaseRepository<WishList>(context);



            
            Brands = new BaseRepository<Brand>(context);

            ShoppingCartServices = new ShoppingCartService(context);


        }

        public IBaseRepository<ApplicationUser> ApplicationUsers { get;private set; }
        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<Coupon> Coupons { get; private set; }
        public IBaseRepository<Payment> Payments { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<ShoppingCart> ShoppingCarts { get; private set; }
        public IBaseRepository<ProductImg> ProductImgs { get; private set; }
        public IShoppingCartService  ShoppingCartServices { get; private set; }

        public IBaseRepository<OrderHeader> OrderHeaders { get; private set; }
        public IBaseRepository<OrderDetails> OrderDetails { get; private set; }
        public IBaseRepository<WishList> WishLists { get; private set; }

        public IBaseRepository<Product_OrderDetails> Product_OrderDetails { get; }



        public IBaseRepository<Review> Reviews { get; private set; }

        public IBaseRepository<Brand> Brands { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
