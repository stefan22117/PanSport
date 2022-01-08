using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        PanSportDbContext context { get; set; }
        IWebHostEnvironment webHostEnvironment { get; set; }
        public ProductsController(PanSportDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            IEnumerable<Product> products = context.Products.Include(x => x.Category);

            products = products.ToList();

            return View(products);
        }

        



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveFromCategory(Product product)
        {


            if (ModelState.IsValid)
            {

                context.Products.Update(product);
                await context.SaveChangesAsync();

                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                       2, "Uspesno ste sacuvali proizvod", "success"
                       ));
            }
            else
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                           2, "Doslo je do greske pri cuvanju proizvoda", "danger"
                           ));
            }

            return RedirectToAction("Details", "Categories", new { id = product.CategoryId });
        }




        #region Create - GET 
        public async Task<IActionResult> Create(int id) // id kategorije
        {
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title");
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name");
            ViewBag.Referer = Request.Headers["Referer"].ToString();


            Category category = await context.Categories.FindAsync(id);
            ViewBag.Referer = Request.Headers["Referer"].ToString();

            Product product = new Product
            {
                Category = category
            };


            return View(product);
        }

        #endregion

        #region Create - POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product newProduct)
        {
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title", newProduct.CategoryId);
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name", newProduct.ManufacturerId);
            if (ModelState.IsValid)
            {
                newProduct.Slug = newProduct.Title.ToLower().Replace(" ", "-");

                if (!context.Products.Any(x => x.Slug == newProduct.Slug))
                {
                    await context.Products.AddAsync(newProduct);
                    await context.SaveChangesAsync();

                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Uspesno ste dodali proizvod", "success"
                        ));

                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("Title", "Postoji proizvod sa ovim naslovom");
                }
            }



            return View(newProduct);
        }

        #endregion



        #region Edit - GET 
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await context.Products
                .Include(x => x.SubProducts)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nismo uspeli da nadjemo proizvod", "danger"
                        ));

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        #endregion

        #region Edit - POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name", product.ManufacturerId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Title.ToLower().Replace(" ", "-");

                if (!context.Products.Any(x => x.Slug == product.Slug && x.Id != product.Id))
                {
                    context.Products.Update(product);
                    await context.SaveChangesAsync();

                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Uspesno ste izmenili proizvod", "success"
                        ));

                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("Title", "Postoji proizvod sa ovim naslovom");
                }
            }
            return View(product);
        }

        #endregion


        #region Details - GET

        public async Task<IActionResult> Details(int id)
        {
            Product product = await context.Products
                .Include(x => x.Category)
                .Include(x => x.SubProducts)
                .FirstOrDefaultAsync(x => x.Id == id);


            if (product == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nismo uspeli da nadjemo proizvod", "danger"
                        ));

                return RedirectToAction("Index");
            }

            return View(product);
        }

        #endregion



        #region Delete - GET
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nismo uspeli da nadjemo proizvod", "danger"
                        ));

                return RedirectToAction("Index");
            }

            return View(product);
        }


        #endregion


        #region Delete - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product product)
        {
            Product _product = await context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == product.Id);

            if (_product == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nismo uspeli da nadjemo proizvod", "danger"
                        ));

            }
            else
            {
                //deleting...
                context.Products.Remove(_product);
                await context.SaveChangesAsync();

                //brisanje direktorijuma sa ovim navivom za proizvod i svih slika u njemu
                string productPath = Path.Combine(webHostEnvironment.WebRootPath, "images",
                    _product?.Category?.Slug, _product?.Slug);


                if (Directory.Exists(productPath))
                {
                    foreach (var imagePath in Directory.EnumerateFiles(productPath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    Directory.Delete(productPath);
                }
                
                //brisanje direktorijuma sa ovim navivom za proizvod i svih slika u njemu




                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2,
                        "Uspesno ste obrisali proizvod \"" + _product.Title + "\""
                        , "success"
                        ));
            }

            return RedirectToAction("Index");
        }


        #endregion
    }
}
