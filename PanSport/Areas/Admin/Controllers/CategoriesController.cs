using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PanSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        PanSportDbContext context { get; set; }
        IWebHostEnvironment webHostEnvironment { get; set; }
        public CategoriesController(PanSportDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await context.Categories.ToListAsync();
            return View(categories);
        }
        #endregion

        #region Create - GET
        public async Task<object> Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title");
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name");

            return View();



        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title");
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name");


            if (ModelState.IsValid)
            {
                category.Slug = category.Title.ToLower().Replace(" ", "-");

                if (!context.Categories.Any(x => x.Slug == category.Slug))
                {
                    await context.Categories.AddAsync(category);
                    await context.SaveChangesAsync();

                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Uspesno ste dodali kategoriju", "success"
                        ));

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Title", "Kategorija sa ovim imenom postoji");
                }



            }


            return View();
        }
        #endregion

        #region Edit - GET
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await context.Categories.FindAsync(id);

            if (category == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nije moguce naci kategoriju sa ID-jem: " + id, "danger"
                        ));

                return RedirectToAction("Index");
            }

            return View(category);
        }

        #endregion

        #region Edit - POST 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Title.ToLower().Replace(" ", "-");

                if (!context.Categories.Any(x => x.Slug == category.Slug && x.Id != category.Id))
                {
                    context.Categories.Update(category);
                    await context.SaveChangesAsync();

                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Uspesno ste izmenili kategoriju", "success"
                        ));

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Title", "Kategorija sa ovim imenom postoji");
                }
            }

            return View(category);
        }

        #endregion

        #region Details - GET 
        public async Task<IActionResult> Details(int id)
        {

            ViewBag.CategoryId = new SelectList(context.Categories, "Id", "Title");
            ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name");

            Category category = await context.Categories.Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nije moguće naći kategoriju sa ID-jem: " + id, "danger"
                        ));

                return RedirectToAction("Index");
            }

            ViewBag.Host = Request.Host.Value.ToString();
            return View(category);
            return View("Proba",  category); //proba
        }
        #endregion


        #region Delete - GET
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await context.Categories.Include(x => x.Products).FirstAsync(x => x.Id == id);



            if (category == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nije moguće naći kategoriju sa ID-jem: " + id, "danger"
                        ));

                return RedirectToAction("Index");
            }

            return View(category);

        }
        #endregion

        #region Delete - POST 
        [HttpPost]
        public async Task<object> Delete(Category category, string deleteOstaloSerialized)
        {
            category = context.Categories.Find(category.Id);
            if (category == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                       2, "Ne postoji izabrana kategorija", "danger"
                       ));
                return RedirectToAction("Index");
            }


            var deleteOstaloIds = JsonConvert.DeserializeObject<ExpandoObject>(deleteOstaloSerialized)
                as IDictionary<string, object>;

            IDictionary<string, Object> flag = new ExpandoObject() as IDictionary<string, object>;

            flag["delete"] = false;
            flag["ostalo"] = false;


            foreach (var id in deleteOstaloIds)
            {
                Product product = await context.Products.FirstOrDefaultAsync(x => id.Key.Contains(x.Slug));

                if (id.Value.ToString() == "delete")
                {
                    flag["delete"] = true;
                    context.Products.Remove(product);
                    //ovde brisemo foldere proizvoda
                    string productPath2 = Path.Combine(webHostEnvironment.WebRootPath, "images",
                    product?.Category?.Slug, product?.Slug);


                    if (Directory.Exists(productPath2))
                    {
                        foreach (var imagePath in Directory.EnumerateFiles(productPath2))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        Directory.Delete(productPath2);
                    }




                }
                else if (id.Value.ToString() == "ostalo")
                {
                    flag["ostalo"] = true;
                    Category categoryOstalo = await context.Categories.FirstOrDefaultAsync(x => x.Slug == "ostalo");

                    product.CategoryId = categoryOstalo?.Id ?? 0;
                }

                await context.SaveChangesAsync();
                //removing directory 
                //ovde brisemo direktorijum ako je prazan,
                //posto smo neke proizvode smestili u ostalo

                string categoryPath = Path.Combine(webHostEnvironment.WebRootPath, "images",
                    product?.Category?.Slug);


                if (Directory.Exists(categoryPath) && Directory.GetFiles(categoryPath).Length == 0)
                {
                    Directory.Delete(categoryPath);
                }

                //removing directory


            }
            var a = (bool)flag["delete"];
            string message = string.Empty;

            if ((bool)flag["delete"])
                message = "Uspešno ste obrisali kategoriju \"" + category.Title + "\" i njene proizvode";

            if ((bool)flag["ostalo"]) message = "Uspešno ste obrisali kategoriju \"" + category.Title +
                    "\" i smestili njene proizvode u kategoriju \"Ostalo\"";

            if ((bool)flag["delete"] && (bool)flag["ostalo"]) message = "Uspešno ste obrisali kategoriju \"" + category.Title +
                   "\", obrisali neke proizvode " +
                   " i smestili neke proizvode u kategoriju \"Ostalo\"";

            if (!(bool)flag["delete"] && !(bool)flag["ostalo"]) message = "Uspešno ste obrisali kategoriju \"" + category.Title + "\"";

            TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, message, "success"
                        ));

            return RedirectToAction("Index");
        }

        #endregion
    }
}
