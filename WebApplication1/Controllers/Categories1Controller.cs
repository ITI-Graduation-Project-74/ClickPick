using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Ecommerce.CustomModels;

namespace Ecommerce.Controllers
{
    public class Categories1Controller : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public Categories1Controller(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;

        }

        // GET: Catagories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catagories.ToListAsync());

        }

        // GET: Catagories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        // GET: Catagories/Create
        public IActionResult Create(int? id)
        {

            CategoryViewModel C = new CategoryViewModel();
            return View(C);
        }

        // POST: Catagories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //public ActionResult Create(CategoryViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            string uniqueFileName = UploadedFile(model);

        //            Catagory catagory = new Catagory
        //            {
        //                CategoryName = model.CategoryName,

        //                ImgUrl = uniqueFileName,
        //            };
        //            _context.Add(catagory);
        //             _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));

        //            //if (model.Id >= 1)
        //            //{
        //            //    _context.Update(model);
        //            //    _context.SaveChangesAsync();
        //            //    // return View();
        //            //    return RedirectToAction(nameof(Index));

        //            //    //return Json(true, System.Web.Mvc.JsonRequestBehavior.AllowGet);

        //            //}
        //            //else
        //            //{
        //            //    Catagory c = new Catagory()
        //            //    {
        //            //        CategoryName = model.CategoryName,
        //            //        ImgUrl = uniqueFileName,
        //            //    };
        //            //    _context.Add(c);
        //            //    _context.SaveChangesAsync();
        //            //}


        //        }
        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (Exception e)
        //    {
        //        return RedirectToAction(nameof(Index));

        //    }



        //}
        [HttpPost]

        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Category employee = new Category
                {
                    CategoryName = model.CategoryName,
                    ImgUrl = "/Imgs/" + uniqueFileName,
                };

                Random R = new Random();
                employee.Id = R.Next();
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private string UploadedFile(CategoryViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Imgs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        //edit action
        [HttpGet]
        public async Task<IActionResult> EditTest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories.FindAsync(id);


            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }

        [HttpPost]
        public async Task<IActionResult> EditTest(int id, Category catagory, IFormFile ImgUrl)
        {
            if (id != catagory.Id)
            {
                return NotFound();
            }

            if (ImgUrl == null)
            {
                Category employee = new Category
                {
                    Id = catagory.Id,
                    CategoryName = catagory.CategoryName,
                    ImgUrl = catagory.ImgUrl
                };
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                CategoryViewModel C = new CategoryViewModel();
                C.CategoryName = catagory.CategoryName;
                C.ProfileImage = ImgUrl;
                C.Id = catagory.Id;

                string uniqueFileName = UploadedFile(C);

                Category employee = new Category
                {
                    Id = catagory.Id,
                    CategoryName = catagory.CategoryName,
                    ImgUrl = uniqueFileName
                };
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }


        // GET: Catagories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories.FindAsync(id);
            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,CategoryName,ImgUrl")] Category catagory)
        {
            if (id != catagory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catagory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatagoryExists(catagory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catagory);
        }

        // GET: Catagories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catagory = await _context.Catagories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catagory == null)
            {
                return NotFound();
            }

            return View(catagory);
        }

        // POST: Catagories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catagory = await _context.Catagories.FindAsync(id);
            _context.Catagories.Remove(catagory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatagoryExists(int id)
        {
            return _context.Catagories.Any(e => e.Id == id);
        }




    }
}
