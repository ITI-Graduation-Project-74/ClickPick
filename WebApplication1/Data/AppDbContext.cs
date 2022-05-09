using ClickPick.Models;
using Ecommerce.Migrations;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
   
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private object modelBuilder;

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
 




        //Set Primary Key of Ternary Relation
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<UsersWithorder>(
                 eb =>
                 {
                     eb.HasNoKey();
                     eb.ToView("View_UsersWithorder");
                     eb.Property(v => v.FirstName).HasColumnName("FirstName");
                 });


        }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Category> Catagories { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<ProductImg> ProductImgs { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<VendorRequest> VendorRequest { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }

        // OrderHeader And Order Details 

        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetials { get; set; }

        //users with order details

        public DbSet<UsersWithorder> UsersWithorders { get; set; }




    }
}
