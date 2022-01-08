using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class SubProductsController : Controller
    {
        PanSportDbContext context { get; set; }
        IWebHostEnvironment webHostEnvironment { get; set; }
        public SubProductsController(PanSportDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        #region Non-Action

        [NonAction]

        
        public string UploadSubProductImage(SubProduct subProduct)
        {
            if (subProduct.ImageFile == null)
            {
                return string.Empty;
            }


            string categoryPath = string.Empty;

            string productPath = string.Empty;


        string ext = Path.GetExtension(subProduct.ImageFile.FileName);

            SubProduct _subProduct = context.SubProducts
                .Include(x => x.Product.Category)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == subProduct.Id);

            Product product = context.Products.FirstOrDefault(x=>x.Id == subProduct.ProductId);
            

            if(_subProduct != null)
            {
                 categoryPath = Path.Combine(webHostEnvironment.WebRootPath, "images", _subProduct.Product?.Category?.Slug);

                 productPath = Path.Combine(categoryPath, _subProduct.Product?.Slug);


                string oldPath = Path.Combine(productPath, _subProduct.Image ?? "");

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }


            }
            else
            {
                categoryPath = Path.Combine(webHostEnvironment.WebRootPath, "images", product?.Category?.Slug);

                productPath = Path.Combine(categoryPath, product?.Slug);

                _subProduct.Id = 0;
            }



            if (!Directory.Exists(categoryPath))
            {
                Directory.CreateDirectory(categoryPath);
            }

            if (!Directory.Exists(productPath))
            {
                Directory.CreateDirectory(productPath);
            }

            


            string filePath = Path.Combine(productPath, "product_image_" + subProduct.Id.ToString() + ext);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }




            FileStream fs = new FileStream(filePath, FileMode.Create);

            subProduct.ImageFile.CopyTo(fs);

            fs.Close();

            return Path.Combine("product_image_" + subProduct.Id.ToString() + ext);

        }




        [NonAction]
        public List<SelectListItem> FillSelectCategoryProduct()
        {
            var list = new List<SelectListItem>();


            foreach (var category in context.Categories.Include(x => x.Products))
            {
                var optionGroup = new SelectListGroup() { Name = category.Title };
                foreach (var prod in category.Products)
                {
                    list.Add(new SelectListItem() { Value = prod.Id.ToString(), Text = prod.Title, Group = optionGroup });
                }
            }

            return list;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            IEnumerable<SubProduct> subProducts = await context.SubProducts
                .Include(x => x.Product.Category)
                .ToListAsync();

            return View(subProducts);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveFromProduct(SubProduct subProduct)
        {
            //ViewBag.Referer = Request.Headers["Referer"].ToString(); 
            
            
            if (ModelState.IsValid)
            {
                string Image = UploadSubProductImage(subProduct);
                if (Image != string.Empty)
                {
                    subProduct.Image = Image;
                }

                context.SubProducts.Update(subProduct);
                await context.SaveChangesAsync();

                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                       2, "Uspesno ste sacuvali podproizvod", "success"
                       ));
            }
            else
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                           2, "Doslo je do greske pri cuvanju podproizvoda", "danger"
                           ));
            }

            return RedirectToAction("Details", "Products", new { id = subProduct.ProductId });
        }





        public async Task<IActionResult> Create(int id)// id glavnog producta
        {
            Product product = await context.Products.FindAsync(id);
            ViewBag.Referer = Request.Headers["Referer"].ToString();

            SubProduct subProduct = new SubProduct
            {
                Product = product
            };

            ViewBag.ProductId = FillSelectCategoryProduct();


            return View(subProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubProduct newSubProduct, string referer)
        {
            ViewBag.ProductId = FillSelectCategoryProduct();
            //ako je uspeh, poruka i prosledi na referer, zato sto moze ili da smo kliknuli create sa
            // Indexa subProducta ili Details producta

            var subProductExists = context.SubProducts
                .Where(x => x.Package == newSubProduct.Package)
                .Where(x => x.Price == newSubProduct.Price)
                .Where(x => x.Size == newSubProduct.Size)
                .Where(x => x.Taste == newSubProduct.Taste)
                .Where(x => x.ProductId == newSubProduct.ProductId)
                //.AsNoTracking()

                //da li postoji za taj proizvod isti podproizvod koji je vec unet
                .FirstOrDefault();

            
            if (ModelState.IsValid)
            {
                if (subProductExists == null)
                {
                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                              2, "Uspesno ste dodali podproizvod", "success"
                              ));

                    //saving

                    //dodato
                    //SubProduct sp = new SubProduct
                    //{
                    //    Taste = "jagoda",
                    //    Price = 3400,
                    //    ProductId = 1
                    //};
                    //context.SubProducts.Add(sp);

                    //dodato



                    context.SubProducts.Add(newSubProduct);

                    await context.SaveChangesAsync();

                    string Image = UploadSubProductImage(newSubProduct);
                    if (Image != string.Empty)
                    {
                        newSubProduct.Image = Image;
                    }
                    context.SubProducts.Update(newSubProduct);
                    await context.SaveChangesAsync();






                    //saving
                    if (referer != null)
                    {
                    return Redirect(referer);
                    }

                    return RedirectToAction("Details", "Products", new { id = newSubProduct.ProductId });
                }
                else
                {
                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                              2, "Postoji podproizvod sa istim atributima", "danger"
                              ));
                }

            }
            return View(newSubProduct);
        }



        public async Task<IActionResult> Edit(int id)
        {
            SubProduct subProduct = await context.SubProducts
                .Include(x => x.Product.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            ViewBag.Referer = Request.Headers["Referer"].ToString();

            if (subProduct == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nismo uspeli da nadjemo podproizvod", "danger"
                        ));

                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(context.Categories, "Id", "Title", subProduct.ProductId);
            //ViewBag.ManufacturerId = new SelectList(context.Manufacturers, "Id", "Name", subProduct.ManufacturerId);
            return View(subProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubProduct newSubProduct, string referer)
        {
            ViewBag.ProductId = FillSelectCategoryProduct();
            //ako je uspeh, poruka i prosledi na referer, zato sto moze ili da smo kliknuli create sa
            // Indexa subProducta ili Details producta

            var subProductExists = context.SubProducts
               .Where(x => x.Package == newSubProduct.Package)
               .Where(x => x.Price == newSubProduct.Price)
               .Where(x => x.Size == newSubProduct.Size)
               .Where(x => x.Taste == newSubProduct.Taste)
               .Where(x => x.ProductId == newSubProduct.ProductId)
               //.AsNoTracking()

               //da li postoji za taj proizvod isti podproizvod koji je vec unet
               .FirstOrDefault();


            if (ModelState.IsValid)
            {
                if (subProductExists == null)
                {
                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                              2, "Uspesno ste sacuvali podproizvod", "success"
                              ));

                    //saving

                    context.SubProducts.Update(newSubProduct);

                    await context.SaveChangesAsync();

                    string Image = UploadSubProductImage(newSubProduct);
                    if (Image != string.Empty)
                    {
                        newSubProduct.Image = Image;
                    }
                    context.SubProducts.Update(newSubProduct);
                    await context.SaveChangesAsync();






                    //saving
                    if (referer != null)
                    {
                        return Redirect(referer);
                    }

                    return RedirectToAction("Details", "Products", new { id = newSubProduct.ProductId });
                }
                else
                {
                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                              2, "Postoji podproizvod sa istim atributima", "danger"
                              ));
                }

            }
            return View(newSubProduct);

        }
    }
}
