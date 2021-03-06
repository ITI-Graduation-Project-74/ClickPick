using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.Models;
using System.IO;
using System.Web;
using Grpc.Core;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {

            var appDbContext = _context.Products.Include(p => p.ApplicationUser).Include(p => p.Catagory).Include(p => p.ProductImgs);

            return View(await appDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ApplicationUser)
                .Include(p => p.Catagory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Images(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productimg = _context.ProductImgs.Where(m => m.Id == id).ToList();
            if (productimg == null)
            {
                return NotFound();
            }

            return View(productimg);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "CategoryName");


            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, List<IFormFile> ProductImgs)
        {
            if (ModelState.IsValid)
            {
                Random R = new Random();

                Product employee = new Product
                {
                    CatagoryId = product.CatagoryId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Size = product.Size,
                    Discount = product.Discount,
                    ImgUrl = product.ImgUrl,
                    Catagory = product.Catagory,
                    UserId = product.UserId,
                    IsApproved = true,
                    Id = R.Next(),
                    BrandId = product.BrandId
                };

                employee.Id = R.Next();
                _context.Add(employee);
                await _context.SaveChangesAsync();
                var id = employee.Id;



                foreach (IFormFile file in ProductImgs)
                {
                    if (file == null || file.Length == 0)
                        return Content("file not selected");
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);

                        var categoryId = employee.CatagoryId;
                        var categoryName = _context.Catagories.Where(a => a.Id == categoryId).FirstOrDefault().CategoryName;

                        //var ServerSavePath = Path.Combine(Server.MapPath("~/imgs/") + InputFileName);
                        var paths = new string[] { "wwwroot/", "Imgs/", "Categories/", categoryName + '/' };

                        //var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", InputFileName);
                        var fullPath = Path.Combine(paths);

                        var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), fullPath, InputFileName);

                        using (var stream = new FileStream(ServerSavePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Random R2 = new Random();
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = ProductImgs.Count().ToString() + " files uploaded successfully.";
                        ProductImg P = new ProductImg();
                        P.ProductId = id;
                        P.ImgUrl = file.FileName;
                        P.Id = R2.Next();

                        //var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", InputFileName);
                        var paths2 = new string[] { "/Imgs/", "Categories/", categoryName + '/' };

                        var fullPath2 = Path.Combine(paths2);

                        var ServerSavePath2 = Path.Combine(fullPath2, InputFileName);

                        P.ImgUrl = ServerSavePath2;

                        employee.ImgUrl = ServerSavePath2;
                        _context.Update(employee);
                        _context.ProductImgs.Add(P);



                        await _context.SaveChangesAsync();
                    }
                    //return RedirectToAction(nameof(Index));
                }
                ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
                ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "Id", product.CatagoryId);
                //return View(product);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }
        // GET: Products/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Include(p => p.ProductImgs).Where(x => x.Id == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "CategoryName");


            return View(product);
        }



        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile[] ProductImgs)

        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product2 = await _context.Products.FindAsync(product.Id);
                var p = product2.ProductImgs.Find(p => p.ProductId == product.Id);

                //if (product.ProductImgs.Count == 0)
                //{
                //var product2 = await _context.Products.FindAsync(product.Id);
                //var p = product2.ProductImgs.Find(p => p.ProductId == product.Id);
                _context.ProductImgs.Update(p);
                _context.ChangeTracker.Clear();
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                //}

                if (ProductImgs != null)
                {
                    foreach (IFormFile file in ProductImgs)
                    {

                        //Checking file is available to save.  
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var categoryName = product.Catagory.CategoryName;
                            //var ServerSavePath = Path.Combine(Server.MapPath("~/imgs/") + InputFileName);
                            var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", InputFileName);

                            using (var stream = new FileStream(ServerSavePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }


                            //assigning file uploaded status to ViewBag for showing message to user.  
                            // ViewBag.UploadStatus = ProductImgs.Count().ToString() + " files uploaded successfully.";

                            //var product2 = await _context.Products.FindAsync(product.Id);
                            //var p = product2.ProductImgs.Find(p => p.ProductId == product.Id);


                            ProductImg Pr = new ProductImg();
                            Pr.ProductId = id;
                            Pr.ImgUrl = file.FileName;
                            Pr.Id = p.Id;


                            _context.ProductImgs.Update(Pr);
                            await _context.SaveChangesAsync();



                        }

                    }

                }


                //_context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ApplicationUser)
                .Include(p => p.Catagory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }


        //get VendorRequest
        // GET: Products/VendorRequest
        public IActionResult VendorRequest()
        {

            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "CategoryName");

            return View();
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> VendorRequest(Product product, List<IFormFile> ProductImgs)
        {
            if (ModelState.IsValid)
            {
                Random R = new Random();

                Product employee = new Product
                {
                    CatagoryId = product.CatagoryId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Size = product.Size,
                    Discount = product.Discount,
                    ImgUrl = product.ImgUrl,
                    Catagory = product.Catagory,
                    UserId = _context.Users.SingleOrDefault(x => x.UserName.ToLower() == User.Identity.Name.ToLower()).Id,
                    IsApproved = false,

                    Id = R.Next()
                };

                employee.Id = R.Next();
                _context.Add(employee);
                await _context.SaveChangesAsync();
                var id = employee.Id;



                foreach (IFormFile file in ProductImgs)
                {
                    if (file == null || file.Length == 0)
                        return Content("file not selected");
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var categoryId = employee.CatagoryId;
                        var categoryName = _context.Catagories.Where(a => a.Id == categoryId).FirstOrDefault().CategoryName;

                        //var ServerSavePath = Path.Combine(Server.MapPath("~/imgs/") + InputFileName);
                        var paths = new string[] { "wwwroot/", "Imgs/", "Categories/", categoryName + '/' };


                        //var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", InputFileName);

                        var fullPath = Path.Combine(paths);

                        var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), fullPath, InputFileName);

                        using (var stream = new FileStream(ServerSavePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        Random R2 = new Random();
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = ProductImgs.Count().ToString() + " files uploaded successfully.";
                        ProductImg P = new ProductImg();
                        P.ProductId = id;
                        P.ImgUrl = file.FileName;
                        P.Id = R2.Next();
                        _context.ProductImgs.Add(P);
                        //var ServerSavePath = Path.Combine(Server.MapPath("~/imgs/") + InputFileName);
                        var paths2 = new string[] { "/Imgs/", "Categories/", categoryName + '/' };


                        //var ServerSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", InputFileName);

                        var fullPath2 = Path.Combine(paths2);

                        var ServerSavePath2 = Path.Combine(fullPath2, InputFileName);

                        employee.ImgUrl = ServerSavePath2;
                        _context.Products.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                    //return RedirectToAction(nameof(Index));
                }
                //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
                //ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "Id", product.CatagoryId);

                ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
                ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "CategoryName");
                //return View(product);
                //return RedirectToAction(nameof(Index));
                ViewBag.msg = "Your Request Is Send";
                return View(product);

                //  return View("Send");
            }
            //return RedirectToAction(nameof(Index));
            // return View("Send");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            ViewData["CatagoryId"] = new SelectList(_context.Catagories, "Id", "CategoryName");
            return View(product);


        }

        public async Task<IActionResult> MyProducts(string id)
        {
            if (id != null)
            {
                var idUser = _context.Users.Where(a => a.UserName == id).FirstOrDefault();
                var product = _context.Products.Where(a => a.ApplicationUser == idUser).Where(a => a.IsApproved == true).ToList();
                return View(product);
            }
            string idUser2 = Convert.ToString(TempData["idUserFinally"]);
            var idUser3 = _context.Users.Where(a => a.Id == idUser2).FirstOrDefault();
            var product2 = _context.Products.Where(a => a.ApplicationUser == idUser3).Where(a => a.IsApproved == true).ToList();
            return View(product2);
        }
        public async Task<IActionResult> deleteVendor(int id)
        {
            var idUser = _context.Products.Where(a => a.Id == id).FirstOrDefault().UserId;
            var product = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            TempData["idUserFinally"] = idUser;
            _context.Products.Remove(product);
            _context.SaveChanges();
            await _context.SaveChangesAsync();

            return RedirectToAction("MyProducts");
        }

    }
}
