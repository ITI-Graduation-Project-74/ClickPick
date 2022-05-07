
using Ecommerce.Models;

namespace Ecommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Categories

                if (!context.Catagories.Any())
                {
                    context.Catagories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Id = 1,
                            CategoryName = "Men's",
                            ImgUrl = "/Imgs/Categories/CategoryHead/C1.jpg",
                        },

                       new Category()
                        {
                            Id = 2,
                            CategoryName = "Kid's",
                            ImgUrl = "/Imgs/Categories/CategoryHead/C2.jpg",
                        },
                       new Category()
                        {
                            Id = 3,
                            CategoryName = "Mobile",

                            ImgUrl = "/Imgs/Categories/CategoryHead/C3.jpg",

                        },
                       new Category()
                        {
                            Id = 4,
                            CategoryName = "Laptop",

                            ImgUrl = "/Imgs/Categories/CategoryHead/C4.jpg",

                        },
                       new Category()
                        {
                            Id = 5,
                            CategoryName = "Shoes",

                            ImgUrl = "/Imgs/Categories/CategoryHead/C5.jpg",

                        },
                       new Category()
                        {
                            Id = 6,
                            CategoryName = "Women's",

                            ImgUrl = "/Imgs/Categories/CategoryHead/C6.jpg",

                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Coupons.Any())
                {
                    //Coupons
                    context.Coupons.AddRange(new List<Coupon>()
                    {
                       new Coupon()
                        {
                            
                            Name = "Valid10",

                            ValidFrom = new DateTime(2022,5,1),
                            ValidTo = new DateTime(2022,5,30),
                            Percentage=10

                        },
                       new Coupon()
                        {

                            Name = "Valid5",

                            ValidFrom = new DateTime(2022,5,1),
                            ValidTo = new DateTime(2022,5,30),
                            Percentage=5
                        },
                       new Coupon()
                        {

                            Name = "expired",

                            ValidFrom = new DateTime(2022,4,1),
                            ValidTo = new DateTime(2022,4,30),
                            Percentage=5

                        },
                    });
                context.SaveChanges();
            }

            // Products


            if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Id=1,
                            Name ="Apple iPhone 11 128giga",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/1/a.jpg",


                            CatagoryId=3,


                        },
                         new Product()
                        {
                            Id=2,
                            Name ="Iphone 13 128giga",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/2/a.jpg",

                            CatagoryId=3,


                        },
                        new Product()
                        {
                            Id=3,
                            Name ="Ihpone 13 Pink",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/3/a.jpg",

                            CatagoryId=3,


                        },
                        new Product()
                        {   Id=4,
                            Name ="Nokia G20 Dual sim",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/4/a.jpg",

                            CatagoryId=3,


                        },

                         new Product()
                        {
                             Id=5,
                            Name ="oppo A55 64giga",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/5/a.jpg",

                            CatagoryId=3,


                        },
                          new Product()
                        {
                              Id =6,
                            Name ="Realme Gt master",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/6/a.jpg",

                            CatagoryId=3,


                        },

                           new Product()
                        {
                            Id=7,
                            Name ="Samsung Galaxy s21",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/7/a.jpg",

                            CatagoryId=3,
                        },

                            new Product()
                        {
                             Id=8,
                            Name ="Samsung Galaxy s21 64giga",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/8/a.jpg",

                            CatagoryId=3,
                        },
                             new Product()
                        {
                            Id=9,
                            Name ="Samsung Galaxy Z filp",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/9/a.jpg",

                            CatagoryId=3,


                        },
                             new Product()
                        {
                            Id=10,
                            Name ="Spigen Ultra Hybrid",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/10/a.jpg",

                            CatagoryId=3,


                        },
                             new Product()
                        {
                            Id=11,
                            Name ="Xiaomi Redmi Note 10S",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/11/a.jpg",

                            CatagoryId=3,


                        },
                           new Product()
                        {
                            Id=12,
                            Name ="Xiaomi Redmi Note 9 pro",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/mobiles/12/a.jpg",

                            CatagoryId=3,


                        },



                           //shoes
                             new Product()
                        {
                            Id=13,
                            Name ="Active Blue Black",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/1/a.jpg",

                            CatagoryId=5,


                        },
                           new Product()
                        {
                               Id =14,
                            Name ="Active white Black",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/2/a.jpg",

                            CatagoryId=5,


                        },
                               new Product()
                        {
                               Id=15,
                            Name ="Active white men's shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/3/a.jpg",

                            CatagoryId=5,


                        },
                            new Product()
                        {
                            Id=16,
                            Name ="Active white men's shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/4/a.jpg",

                            CatagoryId=5,


                        },
                             new Product()
                        {
                            Id=17,
                            Name ="Active women's shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/5/a.jpg",

                            CatagoryId=5,
                        },
                             new Product()
                        {
                                Id=18,
                            Name ="Adidas black shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/6/a.jpg",

                            CatagoryId=5,
                        },
                             new Product()
                        {
                                Id=19,
                            Name ="Black sappoh with high heels",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/7/a.jpg",

                            CatagoryId=5,
                        },
                            new Product()
                        {
                                Id=20,
                            Name ="Blue sport men's shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/8/a.jpg",

                            CatagoryId=5,
                        },
                            new Product()
                        {
                                Id=21,
                            Name ="Dawara Casual Shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/9/a.jpg",

                            CatagoryId=5,
                        },
                            new Product()
                        {
                                Id=22,
                            Name ="Grinta Women",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/10/a.jpg",

                            CatagoryId=5,
                        },
                            new Product()
                        {
                                Id=23,
                            Name ="Skippy Blue Shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/11/a.jpg",

                            CatagoryId=5,
                        },
                            new Product()
                        {
                                Id=24,
                            Name ="Men's Tennis Shoes",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/shoese/12/a.jpg",

                            CatagoryId=5,
                        },





                            //laptop
                            new Product()
                        {
                                Id=25,
                            Name ="Alienware m15 Ryzen™ Edition R5 Gaming Laptop",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/1/a.jpg",

                            CatagoryId=4,
                        },
                             new Product()
                        {
                                Id=26,
                            Name ="Dell G15 15-5510 Gaming laptop - 10th Intel Core i5",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/2/a.jpg",

                            CatagoryId=4,
                        },
                             new Product()
                        {
                                Id=27,
                            Name ="Dell Inspiron 7306 2-in-1 x360 laptop - 11th Intel Core i5",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/3/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=28,
                            Name ="Dell Vostro 3510 laptop - 11th Gen Intel core i7",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/4/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=29,
                            Name ="DELL Vostro 3515 Laptop - Ryzen 5 3450U, 8GB RAM, 512GB SSD",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/5/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=30,
                            Name ="HP 15-dy2091wm Laptop - 11th Gen Intel Core i3",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/6/a.jpg",

                            CatagoryId=4,
                        },

                           new Product()
                        {
                                Id=31,
                            Name ="HP Laptop 15-dw3023ne(11th Gen Intel core i5",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/7/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=32,
                            Name ="HP Pavilion x360 Convertible 2n1 14-dy0142ne laptop",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/8/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=33,
                            Name ="HP Victus 16-d0023dx Gaming Laptop Latest Model - 11th",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/9/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=34,
                            Name ="Lenovo IdeaPad 3 15ALC6 Laptop - Ryzen 5 5500U 6 Cores",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/10/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=35,
                            Name ="Lenovo Legion 5 Gaming Laptop - Ryzen 7 5800H 8-Core",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/11/a.jpg",

                            CatagoryId=4,
                        },
                           new Product()
                        {
                                Id=36,
                            Name ="Lenovo v15 4GB Ram",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Laptop/12/a.jpg",

                            CatagoryId=4,
                        },





                           //kids
                              new Product()
                        {
                                Id=37,
                            Name ="Black Pants",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/1/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=38,
                            Name ="Gray sweet-shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/2/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=39,
                            Name ="Blue short",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/3/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=40,
                            Name ="Red Sweet-shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/4/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=41,
                            Name ="Black Sweet-shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/5/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=42,
                            Name ="Blue pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/6/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=43,
                            Name ="Yellow salopit",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/7/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=44,
                            Name ="Black T-shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/8/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=45,
                            Name ="Blue Salopit",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/9/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=46,
                            Name ="Pink Sweet-shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/10/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=47,
                            Name ="Blue and Gray pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/11/a.jpg",

                            CatagoryId=2,
                        },
                              new Product()
                        {
                                Id=48,
                            Name ="Dark green pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Kids/12/a.jpg",

                            CatagoryId=2,
                        },






                           //men
                              new Product()
                        {
                                Id=49,
                            Name ="Red pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/Men/1/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=50,
                            Name ="Black pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/2/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=51,
                            Name ="Blue pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/3/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=52,
                            Name ="Gray t-shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/4/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=53,
                            Name ="Black Sweet-Pants",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/5/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=54,
                            Name ="Black and cafee pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/6/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=55,
                            Name ="white and gray pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/7/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=56,
                            Name ="Red Sweet-Shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/8/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=57,
                            Name ="Black Sweet-Shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/9/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=58,
                            Name ="Gray Sweet-Pants",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/10/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=59,
                            Name ="Green Shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/11/a.jpg",

                            CatagoryId=1,
                        },
                              new Product()
                        {
                                Id=60,
                            Name ="Cofee Shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/men/12/a.jpg",

                            CatagoryId=1,
                        },



                          //women
                              new Product()
                        {
                                Id=61,
                            Name ="Red Flowered Dress",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/1/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=62,
                            Name ="Blue-Black Flowered Blouse",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/2/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=63,
                            Name ="Yellow Shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/3/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=64,
                            Name ="Blue Black Shirt",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/4/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=65,
                            Name ="Red pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/5/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=66,
                            Name ="Gray Pyjama",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/6/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=67,
                            Name ="Red Blouse",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/7/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=68,
                            Name ="Dark Red Vest",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/8/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=69,
                            Name ="Baby Blue suit",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/9/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=70,
                            Name ="Black suit",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/10/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=71,
                            Name ="Gray vest",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/11/a.jpg",

                            CatagoryId=6,
                        },
                              new Product()
                        {
                                Id=72,
                            Name ="Red blouse",
                            Description="The Product Description",
                            Price =2000,
                            Discount ="10%",
                            ImgUrl="/Imgs/Categories/women/12/a.jpg",

                            CatagoryId=6,
                        },

                    });
                    context.SaveChanges();

                }
                //productImgs

                if (!context.ProductImgs.Any())
                {
                    context.ProductImgs.AddRange(new List<ProductImg>()
                    {
                        //1
                        new ProductImg()
                        {
                            Id = 1,
                            ImgUrl="/Imgs/Categories/mobiles/1/b.jpg",
                            ProductId=1,

                        },
                        new ProductImg()
                        {
                            Id = 2,
                            ImgUrl="/Imgs/Categories/mobiles/1/c.jpg",
                            ProductId=1,

                        },new ProductImg()
                        {
                            Id = 3,
                            ImgUrl="/Imgs/Categories/mobiles/1/d.jpg",
                            ProductId=1,

                        },

                        //2
                        new ProductImg()
                        {
                            Id = 4,
                            ImgUrl="/Imgs/Categories/mobiles/2/b.jpg",
                            ProductId=2,

                        },
                        new ProductImg()
                        {
                            Id = 5,
                            ImgUrl="/Imgs/Categories/mobiles/2/c.jpg",
                            ProductId=2,

                        },new ProductImg()
                        {
                            Id = 6,
                            ImgUrl="/Imgs/Categories/mobiles/2/d.jpg",
                            ProductId=2,

                        },

                        //3
                        new ProductImg()
                        {
                            Id = 7,
                            ImgUrl="/Imgs/Categories/mobiles/3/b.jpg",
                            ProductId=3,

                        },
                        new ProductImg()
                        {
                            Id = 8,
                            ImgUrl="/Imgs/Categories/mobiles/3/c.jpg",
                            ProductId=3,

                        },new ProductImg()
                        {
                            Id = 9,
                            ImgUrl="/Imgs/Categories/mobiles/3/d.jpg",
                            ProductId=3,

                        },


                        //4
                        new ProductImg()
                        {
                            Id = 10,
                            ImgUrl="/Imgs/Categories/mobiles/4/b.jpg",
                            ProductId=4,

                        },
                        new ProductImg()
                        {
                            Id =11,
                            ImgUrl="/Imgs/Categories/mobiles/4/c.jpg",
                            ProductId=4,

                        },new ProductImg()
                        {
                            Id = 12,
                            ImgUrl="/Imgs/Categories/mobiles/4/d.jpg",
                            ProductId=4,

                        },


                        //5
                        new ProductImg()
                        {
                            Id = 13,
                            ImgUrl="/Imgs/Categories/mobiles/5/b.jpg",
                            ProductId=5,

                        },
                        new ProductImg()
                        {
                            Id = 14,
                            ImgUrl="/Imgs/Categories/mobiles/5/c.jpg",
                            ProductId=5,

                        },new ProductImg()
                        {
                            Id = 15,
                            ImgUrl="/Imgs/Categories/mobiles/5/d.jpg",
                            ProductId=5,

                        },


                        //6
                        new ProductImg()
                        {
                            Id = 16,
                            ImgUrl="/Imgs/Categories/mobiles/6/b.jpg",
                            ProductId=6,

                        },
                        new ProductImg()
                        {
                            Id = 17,
                            ImgUrl="/Imgs/Categories/mobiles/6/c.jpg",
                            ProductId=6,

                        },new ProductImg()
                        {
                            Id = 18,
                            ImgUrl="/Imgs/Categories/mobiles/6/d.jpg",
                            ProductId=6,

                        },


                        //7
                        new ProductImg()
                        {
                            Id = 19,
                            ImgUrl="/Imgs/Categories/mobiles/7/b.jpg",
                            ProductId=7,

                        },
                        new ProductImg()
                        {
                            Id = 20,
                            ImgUrl="/Imgs/Categories/mobiles/7/c.jpg",
                            ProductId=7,

                        },new ProductImg()
                        {
                            Id = 21,
                            ImgUrl="/Imgs/Categories/mobiles/7/d.jpg",
                            ProductId=7,

                        },


                        //8
                        new ProductImg()
                        {
                            Id = 22,
                            ImgUrl="/Imgs/Categories/mobiles/8/b.jpg",
                            ProductId=8,

                        },
                        new ProductImg()
                        {
                            Id = 23,
                            ImgUrl="/Imgs/Categories/mobiles/8/c.jpg",
                            ProductId=8,

                        },new ProductImg()
                        {
                            Id = 24,
                            ImgUrl="/Imgs/Categories/mobiles/8/d.jpg",
                            ProductId=8,

                        },


                        //9
                        new ProductImg()
                        {
                            Id = 25,
                            ImgUrl="/Imgs/Categories/mobiles/9/b.jpg",
                            ProductId=9,

                        },
                        new ProductImg()
                        {
                            Id = 26,
                            ImgUrl="/Imgs/Categories/mobiles/9/c.jpg",
                            ProductId=9,

                        },new ProductImg()
                        {
                            Id = 27,
                            ImgUrl="/Imgs/Categories/mobiles/9/d.jpg",
                            ProductId=9,

                        },


                        //10
                        new ProductImg()
                        {
                            Id = 28,
                            ImgUrl="/Imgs/Categories/mobiles/10/b.jpg",
                            ProductId=10,

                        },
                        new ProductImg()
                        {
                            Id = 29,
                            ImgUrl="/Imgs/Categories/mobiles/10/c.jpg",
                            ProductId=10,

                        },new ProductImg()
                        {
                            Id = 30,
                            ImgUrl="/Imgs/Categories/mobiles/10/d.jpg",
                            ProductId=10,

                        },


                        //11
                        new ProductImg()
                        {
                            Id = 31,
                            ImgUrl="/Imgs/Categories/mobiles/11/b.jpg",
                            ProductId=11,

                        },
                        new ProductImg()
                        {
                            Id = 32,
                            ImgUrl="/Imgs/Categories/mobiles/11/c.jpg",
                            ProductId=11,

                        },new ProductImg()
                        {
                            Id = 33,
                            ImgUrl="/Imgs/Categories/mobiles/11/d.jpg",
                            ProductId=11,

                        },


                        //12
                        new ProductImg()
                        {
                            Id = 34,
                            ImgUrl="/Imgs/Categories/mobiles/12/b.jpg",
                            ProductId=12,

                        },
                        new ProductImg()
                        {
                            Id = 35,
                            ImgUrl="/Imgs/Categories/mobiles/12/c.jpg",
                            ProductId=12,

                        },new ProductImg()
                        {
                            Id = 36,
                            ImgUrl="/Imgs/Categories/mobiles/12/d.jpg",
                            ProductId=12,

                        },


                        //  shoes  13
                        new ProductImg()
                        {
                            Id = 37,
                            ImgUrl="/Imgs/Categories/shoese/1/b.jpg",
                            ProductId=13,

                        },
                        new ProductImg()
                        {
                            Id = 38,
                            ImgUrl="/Imgs/Categories/shoese/1/c.jpg",
                            ProductId=13,

                        },
                        new ProductImg()
                        {
                            Id = 39,
                            ImgUrl="/Imgs/Categories/shoese/1/d.jpg",
                            ProductId=13,

                        },


                        //14
                        new ProductImg()
                        {
                            Id = 40,
                            ImgUrl="/Imgs/Categories/shoese/2/b.jpg",
                            ProductId=14,

                        },
                        new ProductImg()
                        {
                            Id = 41,
                            ImgUrl="/Imgs/Categories/shoese/2/c.jpg",
                            ProductId=14,

                        },
                        new ProductImg()
                        {
                            Id = 42,
                            ImgUrl="/Imgs/Categories/shoese/2/d.jpg",
                            ProductId=14,

                        },


                        //15
                        new ProductImg()
                        {
                            Id = 43,
                            ImgUrl="/Imgs/Categories/shoese/3/b.jpg",
                            ProductId=15,

                        },
                        new ProductImg()
                        {
                            Id = 44,
                            ImgUrl="/Imgs/Categories/shoese/3/c.jpg",
                            ProductId=15,

                        },
                        new ProductImg()
                        {
                            Id = 45,
                            ImgUrl="/Imgs/Categories/shoese/3/d.jpg",
                            ProductId=15,

                        },


                        //16
                        new ProductImg()
                        {
                            Id = 46,
                            ImgUrl="/Imgs/Categories/shoese/4/b.jpg",
                            ProductId=16,

                        },
                        new ProductImg()
                        {
                            Id = 47,
                            ImgUrl="/Imgs/Categories/shoese/4/c.jpg",
                            ProductId=16,

                        },
                        new ProductImg()
                        {
                            Id = 48,
                            ImgUrl="/Imgs/Categories/shoese/4/d.jpg",
                            ProductId=16,

                        },



                        //17
                        new ProductImg()
                        {
                            Id = 49,
                            ImgUrl="/Imgs/Categories/shoese/5/b.jpg",
                            ProductId=17,

                        },
                        new ProductImg()
                        {
                            Id = 50,
                            ImgUrl="/Imgs/Categories/shoese/5/c.jpg",
                            ProductId=17,

                        },
                        new ProductImg()
                        {
                            Id = 51,
                            ImgUrl="/Imgs/Categories/shoese/5/d.jpg",
                            ProductId=17,

                        },


                        //18
                        new ProductImg()
                        {
                            Id = 52,
                            ImgUrl="/Imgs/Categories/shoese/6/b.jpg",
                            ProductId=18,

                        },
                        new ProductImg()
                        {
                            Id = 53,
                            ImgUrl="/Imgs/Categories/shoese/6/c.jpg",
                            ProductId=18,

                        },
                        new ProductImg()
                        {
                            Id = 54,
                            ImgUrl="/Imgs/Categories/shoese/6/d.jpg",
                            ProductId=18,

                        },


                        //19
                        new ProductImg()
                        {
                            Id = 55,
                            ImgUrl="/Imgs/Categories/shoese/7/b.jpg",
                            ProductId=19,

                        },
                        new ProductImg()
                        {
                            Id = 56,
                            ImgUrl="/Imgs/Categories/shoese/7/c.jpg",
                            ProductId=19,

                        },
                        new ProductImg()
                        {
                            Id = 57,
                            ImgUrl="/Imgs/Categories/shoese/7/d.jpg",
                            ProductId=19,

                        },


                        //20
                        new ProductImg()
                        {
                            Id = 58,
                            ImgUrl="/Imgs/Categories/shoese/8/b.jpg",
                            ProductId=20,

                        },
                        new ProductImg()
                        {
                            Id = 59,
                            ImgUrl="/Imgs/Categories/shoese/8/c.jpg",
                            ProductId=20,

                        },
                        new ProductImg()
                        {
                            Id = 60,
                            ImgUrl="/Imgs/Categories/shoese/8/d.jpg",
                            ProductId=20,

                        },


                        //21
                        new ProductImg()
                        {
                            Id = 61,
                            ImgUrl="/Imgs/Categories/shoese/9/b.jpg",
                            ProductId=21,

                        },
                        new ProductImg()
                        {
                            Id = 62,
                            ImgUrl="/Imgs/Categories/shoese/9/c.jpg",
                            ProductId=21,

                        },
                        new ProductImg()
                        {
                            Id = 63,
                            ImgUrl="/Imgs/Categories/shoese/9/d.jpg",
                            ProductId=21,

                        },


                        //22
                        new ProductImg()
                        {
                            Id = 64,
                            ImgUrl="/Imgs/Categories/shoese/10/b.jpg",
                            ProductId=22,

                        },
                        new ProductImg()
                        {
                            Id = 65,
                            ImgUrl="/Imgs/Categories/shoese/10/c.jpg",
                            ProductId=22,

                        },
                        new ProductImg()
                        {
                            Id = 66,
                            ImgUrl="/Imgs/Categories/shoese/10/d.jpg",
                            ProductId=22,

                        },


                        //23
                        new ProductImg()
                        {
                            Id = 67,
                            ImgUrl="/Imgs/Categories/shoese/11/b.jpg",
                            ProductId=23,

                        },
                        new ProductImg()
                        {
                            Id = 68,
                            ImgUrl="/Imgs/Categories/shoese/11/c.jpg",
                            ProductId=23,

                        },
                        new ProductImg()
                        {
                            Id = 69,
                            ImgUrl="/Imgs/Categories/shoese/11/d.jpg",
                            ProductId=23,

                        },


                        //24
                        new ProductImg()
                        {
                            Id = 70,
                            ImgUrl="/Imgs/Categories/shoese/12/b.jpg",
                            ProductId=24,

                        },
                        new ProductImg()
                        {
                            Id = 71,
                            ImgUrl="/Imgs/Categories/shoese/12/c.jpg",
                            ProductId=24,

                        },
                        new ProductImg()
                        {
                            Id = 72,
                            ImgUrl="/Imgs/Categories/shoese/12/d.jpg",
                            ProductId=24,

                        },



                        //25 Laptop  
                        new ProductImg()
                        {
                            Id = 73,
                            ImgUrl="/Imgs/Categories/Laptop/1/b.jpg",
                            ProductId=25,

                        },
                        new ProductImg()
                        {
                            Id = 74,
                            ImgUrl="/Imgs/Categories/Laptop/1/c.jpg",
                            ProductId=25,

                        },
                        new ProductImg()
                        {
                            Id = 75,
                            ImgUrl="/Imgs/Categories/Laptop/1/d.jpg",
                            ProductId=25,

                        },


                        //26 
                        new ProductImg()
                        {
                            Id = 76,
                            ImgUrl="/Imgs/Categories/Laptop/2/b.jpg",
                            ProductId=26,

                        },
                        new ProductImg()
                        {
                            Id = 77,
                            ImgUrl="/Imgs/Categories/Laptop/2/c.jpg",
                            ProductId=26,

                        },
                        new ProductImg()
                        {
                            Id = 78,
                            ImgUrl="/Imgs/Categories/Laptop/2/d.jpg",
                            ProductId=26,

                        },


                        //27 
                        new ProductImg()
                        {
                            Id = 79,
                            ImgUrl="/Imgs/Categories/Laptop/3/b.jpg",
                            ProductId=27,

                        },
                        new ProductImg()
                        {
                            Id = 80,
                            ImgUrl="/Imgs/Categories/Laptop/3/c.jpg",
                            ProductId=27,

                        },
                        new ProductImg()
                        {
                            Id = 81,
                            ImgUrl="/Imgs/Categories/Laptop/3/d.jpg",
                            ProductId=27,

                        },


                        //28 
                        new ProductImg()
                        {
                            Id = 82,
                            ImgUrl="/Imgs/Categories/Laptop/4/b.jpg",
                            ProductId=28,

                        },
                        new ProductImg()
                        {
                            Id = 83,
                            ImgUrl="/Imgs/Categories/Laptop/4/c.jpg",
                            ProductId=28,

                        },
                        new ProductImg()
                        {
                            Id = 84,
                            ImgUrl="/Imgs/Categories/Laptop/4/d.jpg",
                            ProductId=28,

                        },


                        //29 
                        new ProductImg()
                        {
                            Id = 85,
                            ImgUrl="/Imgs/Categories/Laptop/5/b.jpg",
                            ProductId=29,

                        },
                        new ProductImg()
                        {
                            Id = 86,
                            ImgUrl="/Imgs/Categories/Laptop/5/c.jpg",
                            ProductId=29,

                        },
                        new ProductImg()
                        {
                            Id = 87,
                            ImgUrl="/Imgs/Categories/Laptop/5/d.jpg",
                            ProductId=29,

                        },


                        //30
                        new ProductImg()
                        {
                            Id = 88,
                            ImgUrl="/Imgs/Categories/Laptop/6/b.jpg",
                            ProductId=30,

                        },
                        new ProductImg()
                        {
                            Id = 89,
                            ImgUrl="/Imgs/Categories/Laptop/6/c.jpg",
                            ProductId=30,

                        },
                        new ProductImg()
                        {
                            Id = 90,
                            ImgUrl="/Imgs/Categories/Laptop/6/d.jpg",
                            ProductId=30,

                        },


                        //31
                        new ProductImg()
                        {
                            Id = 91,
                            ImgUrl="/Imgs/Categories/Laptop/7/b.jpg",
                            ProductId=31,

                        },
                        new ProductImg()
                        {
                            Id = 92,
                            ImgUrl="/Imgs/Categories/Laptop/7/c.jpg",
                            ProductId=31,

                        },
                        new ProductImg()
                        {
                            Id = 93,
                            ImgUrl="/Imgs/Categories/Laptop/7/d.jpg",
                            ProductId=31,

                        },


                        //32
                        new ProductImg()
                        {
                            Id = 94,
                            ImgUrl="/Imgs/Categories/Laptop/8/b.jpg",
                            ProductId=32,

                        },
                        new ProductImg()
                        {
                            Id = 95,
                            ImgUrl="/Imgs/Categories/Laptop/8/c.jpg",
                            ProductId=32,

                        },
                        new ProductImg()
                        {
                            Id = 96,
                            ImgUrl="/Imgs/Categories/Laptop/8/d.jpg",
                            ProductId=32,

                        },


                        //33 
                        new ProductImg()
                        {
                            Id = 97,
                            ImgUrl="/Imgs/Categories/Laptop/9/b.jpg",
                            ProductId=33,

                        },
                        new ProductImg()
                        {
                            Id = 98,
                            ImgUrl="/Imgs/Categories/Laptop/9/c.jpg",
                            ProductId=33,

                        },
                        new ProductImg()
                        {
                            Id = 99,
                            ImgUrl="/Imgs/Categories/Laptop/9/d.jpg",
                            ProductId=33,

                        },


                        //34 
                        new ProductImg()
                        {
                            Id = 100,
                            ImgUrl="/Imgs/Categories/Laptop/10/b.jpg",
                            ProductId=34,

                        },
                        new ProductImg()
                        {
                            Id = 101,
                            ImgUrl="/Imgs/Categories/Laptop/10/c.jpg",
                            ProductId=34,

                        },
                        new ProductImg()
                        {
                            Id = 102,
                            ImgUrl="/Imgs/Categories/Laptop/10/d.jpg",
                            ProductId=34,

                        },


                        //35
                        new ProductImg()
                        {
                            Id = 103,
                            ImgUrl="/Imgs/Categories/Laptop/11/b.jpg",
                            ProductId=35,

                        },
                        new ProductImg()
                        {
                            Id = 104,
                            ImgUrl="/Imgs/Categories/Laptop/11/c.jpg",
                            ProductId=35,

                        },
                        new ProductImg()
                        {
                            Id = 105,
                            ImgUrl="/Imgs/Categories/Laptop/11/d.jpg",
                            ProductId=35,

                        },


                        //36 
                        new ProductImg()
                        {
                            Id = 106,
                            ImgUrl="/Imgs/Categories/Laptop/12/b.jpg",
                            ProductId=36,

                        },
                        new ProductImg()
                        {
                            Id = 107,
                            ImgUrl="/Imgs/Categories/Laptop/12/c.jpg",
                            ProductId=36,

                        },
                        new ProductImg()
                        {
                            Id = 108,
                            ImgUrl="/Imgs/Categories/Laptop/12/d.jpg",
                            ProductId=36,

                        },



                        //37 Kids  
                        new ProductImg()
                        {
                            Id = 109,
                            ImgUrl="/Imgs/Categories/Kids/1/b.jpg",
                            ProductId=37,

                        },
                        new ProductImg()
                        {
                            Id = 110,
                            ImgUrl="/Imgs/Categories/Kids/1/c.jpg",
                            ProductId=37,

                        },
                        new ProductImg()
                        {
                            Id = 111,
                            ImgUrl="/Imgs/Categories/Kids/1/d.jpg",
                            ProductId=37,

                        },


                        //38
                        new ProductImg()
                        {
                            Id = 112,
                            ImgUrl="/Imgs/Categories/Kids/2/b.jpg",
                            ProductId=38,

                        },
                        new ProductImg()
                        {
                            Id = 113,
                            ImgUrl="/Imgs/Categories/Kids/2/c.jpg",
                            ProductId=38,

                        },
                        new ProductImg()
                        {
                            Id = 114,
                            ImgUrl="/Imgs/Categories/Kids/2/d.jpg",
                            ProductId=38,

                        },

                        //39
                        new ProductImg()
                        {
                            Id = 115,
                            ImgUrl="/Imgs/Categories/Kids/3/b.jpg",
                            ProductId=39,

                        },
                        new ProductImg()
                        {
                            Id = 116,
                            ImgUrl="/Imgs/Categories/Kids/3/c.jpg",
                            ProductId=39,

                        },
                        new ProductImg()
                        {
                            Id = 117,
                            ImgUrl="/Imgs/Categories/Kids/3/d.jpg",
                            ProductId=39,

                        },

                        //40
                        new ProductImg()
                        {
                            Id = 118,
                            ImgUrl="/Imgs/Categories/Kids/4/b.jpg",
                            ProductId=40,

                        },
                        new ProductImg()
                        {
                            Id = 119,
                            ImgUrl="/Imgs/Categories/Kids/4/c.jpg",
                            ProductId=40,

                        },
                        new ProductImg()
                        {
                            Id = 120,
                            ImgUrl="/Imgs/Categories/Kids/4/d.jpg",
                            ProductId=40,

                        },

                        //41
                        new ProductImg()
                        {
                            Id = 121,
                            ImgUrl="/Imgs/Categories/Kids/5/b.jpg",
                            ProductId=41,

                        },
                        new ProductImg()
                        {
                            Id = 122,
                            ImgUrl="/Imgs/Categories/Kids/5/c.jpg",
                            ProductId=41,

                        },
                        new ProductImg()
                        {
                            Id = 123,
                            ImgUrl="/Imgs/Categories/Kids/5/d.jpg",
                            ProductId=41,

                        },

                        //42
                        new ProductImg()
                        {
                            Id = 124,
                            ImgUrl="/Imgs/Categories/Kids/6/b.jpg",
                            ProductId=42,

                        },
                        new ProductImg()
                        {
                            Id = 125,
                            ImgUrl="/Imgs/Categories/Kids/6/c.jpg",
                            ProductId=42,

                        },
                        new ProductImg()
                        {
                            Id = 126,
                            ImgUrl="/Imgs/Categories/Kids/6/d.jpg",
                            ProductId=42,

                        },

                        //43
                        new ProductImg()
                        {
                            Id = 127,
                            ImgUrl="/Imgs/Categories/Kids/7/b.jpg",
                            ProductId=43,

                        },
                        new ProductImg()
                        {
                            Id = 128,
                            ImgUrl="/Imgs/Categories/Kids/7/c.jpg",
                            ProductId=43,

                        },
                        new ProductImg()
                        {
                            Id = 129,
                            ImgUrl="/Imgs/Categories/Kids/7/d.jpg",
                            ProductId=43,

                        },

                        //44
                        new ProductImg()
                        {
                            Id = 130,
                            ImgUrl="/Imgs/Categories/Kids/8/b.jpg",
                            ProductId=44,

                        },
                        new ProductImg()
                        {
                            Id = 131,
                            ImgUrl="/Imgs/Categories/Kids/8/c.jpg",
                            ProductId=44,

                        },
                        new ProductImg()
                        {
                            Id = 132,
                            ImgUrl="/Imgs/Categories/Kids/8/d.jpg",
                            ProductId=44,

                        },

                        //45
                        new ProductImg()
                        {
                            Id = 133,
                            ImgUrl="/Imgs/Categories/Kids/9/b.jpg",
                            ProductId=45,

                        },
                        new ProductImg()
                        {
                            Id = 134,
                            ImgUrl="/Imgs/Categories/Kids/9/c.jpg",
                            ProductId=45,

                        },
                        new ProductImg()
                        {
                            Id = 135,
                            ImgUrl="/Imgs/Categories/Kids/9/d.jpg",
                            ProductId=45,

                        },

                        //46
                        new ProductImg()
                        {
                            Id = 136,
                            ImgUrl="/Imgs/Categories/Kids/10/b.jpg",
                            ProductId=46,

                        },
                        new ProductImg()
                        {
                            Id = 137,
                            ImgUrl="/Imgs/Categories/Kids/10/c.jpg",
                            ProductId=46,

                        },
                        new ProductImg()
                        {
                            Id = 138,
                            ImgUrl="/Imgs/Categories/Kids/10/d.jpg",
                            ProductId=46,

                        },

                        //47
                        new ProductImg()
                        {
                            Id = 139,
                            ImgUrl="/Imgs/Categories/Kids/11/b.jpg",
                            ProductId=47,

                        },
                        new ProductImg()
                        {
                            Id = 140,
                            ImgUrl="/Imgs/Categories/Kids/11/c.jpg",
                            ProductId=47,

                        },
                        new ProductImg()
                        {
                            Id = 141,
                            ImgUrl="/Imgs/Categories/Kids/11/d.jpg",
                            ProductId=47,

                        },

                        //48
                        new ProductImg()
                        {
                            Id = 142,
                            ImgUrl="/Imgs/Categories/Kids/12/b.jpg",
                            ProductId=48,

                        },
                        new ProductImg()
                        {
                            Id = 143,
                            ImgUrl="/Imgs/Categories/Kids/12/c.jpg",
                            ProductId=48,

                        },
                        new ProductImg()
                        {
                            Id = 144,
                            ImgUrl="/Imgs/Categories/Kids/12/d.jpg",
                            ProductId=48,

                        },




                        //49 Men
                        new ProductImg()
                        {
                            Id = 145,
                            ImgUrl="/Imgs/Categories/men/1/b.jpg",
                            ProductId=49,

                        },
                        new ProductImg()
                        {
                            Id = 146,
                            ImgUrl="/Imgs/Categories/men/1/c.jpg",
                            ProductId=49,

                        },
                        new ProductImg()
                        {
                            Id = 147,
                            ImgUrl="/Imgs/Categories/men/1/d.jpg",
                            ProductId=49,

                        },

                        //50
                        new ProductImg()
                        {
                            Id = 148,
                            ImgUrl="/Imgs/Categories/men/2/b.jpg",
                            ProductId=50,

                        },
                        new ProductImg()
                        {
                            Id = 149,
                            ImgUrl="/Imgs/Categories/men/2/c.jpg",
                            ProductId=50,

                        },
                        new ProductImg()
                        {
                            Id = 150,
                            ImgUrl="/Imgs/Categories/men/2/d.jpg",
                            ProductId=50,

                        },

                        //51
                        new ProductImg()
                        {
                            Id = 151,
                            ImgUrl="/Imgs/Categories/men/3/b.jpg",
                            ProductId=51,

                        },
                        new ProductImg()
                        {
                            Id = 152,
                            ImgUrl="/Imgs/Categories/men/3/c.jpg",
                            ProductId=51,

                        },
                        new ProductImg()
                        {
                            Id = 153,
                            ImgUrl="/Imgs/Categories/men/3/d.jpg",
                            ProductId=51,

                        },

                        //52
                        new ProductImg()
                        {
                            Id = 154,
                            ImgUrl="/Imgs/Categories/men/4/b.jpg",
                            ProductId=52,

                        },
                        new ProductImg()
                        {
                            Id = 155,
                            ImgUrl="/Imgs/Categories/men/4/c.jpg",
                            ProductId=52,

                        },
                        new ProductImg()
                        {
                            Id = 156,
                            ImgUrl="/Imgs/Categories/men/4/d.jpg",
                            ProductId=52,

                        },

                        //53
                        new ProductImg()
                        {
                            Id = 157,
                            ImgUrl="/Imgs/Categories/men/5/b.jpg",
                            ProductId=53,

                        },
                        new ProductImg()
                        {
                            Id = 158,
                            ImgUrl="/Imgs/Categories/men/5/c.jpg",
                            ProductId=53,

                        },
                        new ProductImg()
                        {
                            Id = 159,
                            ImgUrl="/Imgs/Categories/men/5/d.jpg",
                            ProductId=53,

                        },

                        //54
                        new ProductImg()
                        {
                            Id = 160,
                            ImgUrl="/Imgs/Categories/men/6/b.jpg",
                            ProductId=54,

                        },
                        new ProductImg()
                        {
                            Id = 161,
                            ImgUrl="/Imgs/Categories/men/6/c.jpg",
                            ProductId=54,

                        },
                        new ProductImg()
                        {
                            Id = 162,
                            ImgUrl="/Imgs/Categories/men/6/d.jpg",
                            ProductId=54,

                        },

                        //55
                        new ProductImg()
                        {
                            Id = 163,
                            ImgUrl="/Imgs/Categories/men/7/b.jpg",
                            ProductId=55,

                        },
                        new ProductImg()
                        {
                            Id = 164,
                            ImgUrl="/Imgs/Categories/men/7/c.jpg",
                            ProductId=55,

                        },
                        new ProductImg()
                        {
                            Id = 165,
                            ImgUrl="/Imgs/Categories/men/7/d.jpg",
                            ProductId=55,

                        },

                        //56
                        new ProductImg()
                        {
                            Id = 166,
                            ImgUrl="/Imgs/Categories/men/8/b.jpg",
                            ProductId=56,

                        },
                        new ProductImg()
                        {
                            Id = 167,
                            ImgUrl="/Imgs/Categories/men/8/c.jpg",
                            ProductId=56,

                        },
                        new ProductImg()
                        {
                            Id = 168,
                            ImgUrl="/Imgs/Categories/men/8/d.jpg",
                            ProductId=56,

                        },

                        //57
                        new ProductImg()
                        {
                            Id = 169,
                            ImgUrl="/Imgs/Categories/men/9/b.jpg",
                            ProductId=57,

                        },
                        new ProductImg()
                        {
                            Id = 170,
                            ImgUrl="/Imgs/Categories/men/9/c.jpg",
                            ProductId=57,

                        },
                        new ProductImg()
                        {
                            Id = 171,
                            ImgUrl="/Imgs/Categories/men/9/d.jpg",
                            ProductId=57,

                        },

                        //58
                        new ProductImg()
                        {
                            Id = 172,
                            ImgUrl="/Imgs/Categories/men/10/b.jpg",
                            ProductId=58,

                        },
                        new ProductImg()
                        {
                            Id = 173,
                            ImgUrl="/Imgs/Categories/men/10/c.jpg",
                            ProductId=58,

                        },
                        new ProductImg()
                        {
                            Id = 174,
                            ImgUrl="/Imgs/Categories/men/10/d.jpg",
                            ProductId=58,

                        },

                        //59
                        new ProductImg()
                        {
                            Id = 175,
                            ImgUrl="/Imgs/Categories/men/11/b.jpg",
                            ProductId=59,

                        },
                        new ProductImg()
                        {
                            Id = 176,
                            ImgUrl="/Imgs/Categories/men/11/c.jpg",
                            ProductId=59,

                        },
                        new ProductImg()
                        {
                            Id = 177,
                            ImgUrl="/Imgs/Categories/men/11/d.jpg",
                            ProductId=59,

                        },

                        //60
                        new ProductImg()
                        {
                            Id = 178,
                            ImgUrl="/Imgs/Categories/men/12/b.jpg",
                            ProductId=60,

                        },
                        new ProductImg()
                        {
                            Id = 179,
                            ImgUrl="/Imgs/Categories/men/12/c.jpg",
                            ProductId=60,

                        },
                        new ProductImg()
                        {
                            Id = 180,
                            ImgUrl="/Imgs/Categories/men/12/d.jpg",
                            ProductId=60,

                        },




                        //61 women
                        new ProductImg()
                        {
                            Id = 181,
                            ImgUrl="/Imgs/Categories/women/1/b.jpg",
                            ProductId=61,

                        },
                        new ProductImg()
                        {
                            Id = 182,
                            ImgUrl="/Imgs/Categories/women/1/c.jpg",
                            ProductId=61,

                        },
                        new ProductImg()
                        {
                            Id = 183,
                            ImgUrl="/Imgs/Categories/women/1/d.jpg",
                            ProductId=61,

                        },

                        //62
                        new ProductImg()
                        {
                            Id = 184,
                            ImgUrl="/Imgs/Categories/women/2/b.jpg",
                            ProductId=62,

                        },
                        new ProductImg()
                        {
                            Id = 185,
                            ImgUrl="/Imgs/Categories/women/2/c.jpg",
                            ProductId=62,

                        },
                        new ProductImg()
                        {
                            Id = 186,
                            ImgUrl="/Imgs/Categories/women/2/d.jpg",
                            ProductId=62,

                        },


                        //63
                        new ProductImg()
                        {
                            Id = 187,
                            ImgUrl="/Imgs/Categories/women/3/b.jpg",
                            ProductId=63,

                        },
                        new ProductImg()
                        {
                            Id = 188,
                            ImgUrl="/Imgs/Categories/women/3/c.jpg",
                            ProductId=63,

                        },
                        new ProductImg()
                        {
                            Id = 189,
                            ImgUrl="/Imgs/Categories/women/3/d.jpg",
                            ProductId=63,

                        },

                        //64
                        new ProductImg()
                        {
                            Id = 190,
                            ImgUrl="/Imgs/Categories/women/4/b.jpg",
                            ProductId=64,

                        },
                        new ProductImg()
                        {
                            Id = 191,
                            ImgUrl="/Imgs/Categories/women/4/c.jpg",
                            ProductId=64,

                        },
                        new ProductImg()
                        {
                            Id = 192,
                            ImgUrl="/Imgs/Categories/women/4/d.jpg",
                            ProductId=64,

                        },

                        //65
                        new ProductImg()
                        {
                            Id = 193,
                            ImgUrl="/Imgs/Categories/women/5/b.jpg",
                            ProductId=65,

                        },
                        new ProductImg()
                        {
                            Id = 194,
                            ImgUrl="/Imgs/Categories/women/5/c.jpg",
                            ProductId=65,

                        },
                        new ProductImg()
                        {
                            Id = 195,
                            ImgUrl="/Imgs/Categories/women/5/d.jpg",
                            ProductId=65,

                        },

                        //66
                        new ProductImg()
                        {
                            Id = 196,
                            ImgUrl="/Imgs/Categories/women/6/b.jpg",
                            ProductId=66,

                        },
                        new ProductImg()
                        {
                            Id = 197,
                            ImgUrl="/Imgs/Categories/women/6/c.jpg",
                            ProductId=67,

                        },
                        new ProductImg()
                        {
                            Id = 198,
                            ImgUrl="/Imgs/Categories/women/6/d.jpg",
                            ProductId=67,

                        },

                        //67
                        new ProductImg()
                        {
                            Id = 199,
                            ImgUrl="/Imgs/Categories/women/7/b.jpg",
                            ProductId=67,

                        },
                        new ProductImg()
                        {
                            Id = 200,
                            ImgUrl="/Imgs/Categories/women/7/c.jpg",
                            ProductId=67,

                        },
                        new ProductImg()
                        {
                            Id = 201,
                            ImgUrl="/Imgs/Categories/women/7/d.jpg",
                            ProductId=67,

                        },

                        //68
                        new ProductImg()
                        {
                            Id = 202,
                            ImgUrl="/Imgs/Categories/women/8/b.jpg",
                            ProductId=68,

                        },
                        new ProductImg()
                        {
                            Id = 203,
                            ImgUrl="/Imgs/Categories/women/8/c.jpg",
                            ProductId=68,

                        },
                        new ProductImg()
                        {
                            Id = 204,
                            ImgUrl="/Imgs/Categories/women/8/d.jpg",
                            ProductId=68,

                        },

                        //69
                        new ProductImg()
                        {
                            Id = 205,
                            ImgUrl="/Imgs/Categories/women/9/b.jpg",
                            ProductId=69,

                        },
                        new ProductImg()
                        {
                            Id = 206,
                            ImgUrl="/Imgs/Categories/women/9/c.jpg",
                            ProductId=69,

                        },
                        new ProductImg()
                        {
                            Id = 207,
                            ImgUrl="/Imgs/Categories/women/9/d.jpg",
                            ProductId=69,

                        },

                        //70
                        new ProductImg()
                        {
                            Id = 208,
                            ImgUrl="/Imgs/Categories/women/10/b.jpg",
                            ProductId=70,

                        },
                        new ProductImg()
                        {
                            Id = 209,
                            ImgUrl="/Imgs/Categories/women/10/c.jpg",
                            ProductId=70,

                        },
                        new ProductImg()
                        {
                            Id = 210,
                            ImgUrl="/Imgs/Categories/women/10/d.jpg",
                            ProductId=70,

                        },

                        //71
                        new ProductImg()
                        {
                            Id = 211,
                            ImgUrl="/Imgs/Categories/women/11/b.jpg",
                            ProductId=71,

                        },
                        new ProductImg()
                        {
                            Id = 212,
                            ImgUrl="/Imgs/Categories/women/11/c.jpg",
                            ProductId=71,

                        },
                        new ProductImg()
                        {
                            Id = 213,
                            ImgUrl="/Imgs/Categories/women/11/d.jpg",
                            ProductId=71,

                        },

                        //72
                        new ProductImg()
                        {
                            Id = 214,
                            ImgUrl="/Imgs/Categories/women/12/b.jpg",
                            ProductId=72,

                        },
                        new ProductImg()
                        {
                            Id = 215,
                            ImgUrl="/Imgs/Categories/women/12/c.jpg",
                            ProductId=72,

                        },
                        new ProductImg()
                        {
                            Id = 216,
                            ImgUrl="/Imgs/Categories/women/12/d.jpg",
                            ProductId=72,

                        },



                    });


                    context.SaveChanges();
                }

            }
        }
    }
}

