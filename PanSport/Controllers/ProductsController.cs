using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Controllers
{
    public class ProductsController : Controller
    {
        public PanSportDbContext context { get; set; }
        public ProductsController(PanSportDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProducts(string category, string product)
        {
            Category categoryObj = context.Categories.FirstOrDefault(x => x.Slug == category);

            if (categoryObj == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nema trazene kategorije", "danger"
                        ));
                return Redirect("/");
            }

            if (product == null)
            {
                return View("ProductsByCategory", ProductsByCategory(category));
            }
            else
            {
                //return na kategoriju ako nema producta
                Product productObj = context.Products.FirstOrDefault(x => x.Slug == product);
                if (productObj == null)
                {

                    TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Nema trazenog proizvoda", "danger"
                        ));
                    return View("ProductsByCategory", ProductsByCategory(category));
                    
                }
                else
                {
                    return View("SingleProduct", SingleProduct(product));
                }
            }
        }

         #region NonAction
        [NonAction]
        public List<Product> ProductsByCategory(string category)//lista proizvoda u kategoriji
        {
            Category categoryObj = context.Categories.FirstOrDefault(x => x.Slug == category);

            List<Product> products = context.Products
                .Include(x=>x.Category)
                .Where(x => x.CategoryId == categoryObj.Id)
                .ToList();

            ViewBag.Category = categoryObj;
            return products;
        }



        [NonAction]
        public Product SingleProduct(string product)//jedan proizvod gde se bira lista podproizvoda
        {

            Product productObj = context.Products
                .Include(x=>x.SubProducts)
                .FirstOrDefault(x => x.Slug == product);
            
            
            //staro
                
            //var packages =  productObj.SubProducts.Where(x => x.Package != null).Select(x=> new SelectListItem(x.Package, x.Package));
            //var tastes = productObj.SubProducts.Where(x => x.Taste != null).Select(x => new SelectListItem(x.Taste, x.Taste));
            //var sizes = productObj.SubProducts.Where(x => x.Size != null).Select(x => new SelectListItem(x.Size, x.Size));
            //var colors = productObj.SubProducts.Where(x => x.Color != null).Select(x => new SelectListItem(x.Color, x.Color));

            //staro


            var packages = productObj.SubProducts.Where(x => x.Package != null)
               .Select(x => x.Package.ToList().First().ToString().ToUpper() + string.Join("", x.Package.ToList().Skip(1)).ToLower())
               .Distinct()
               .Select(x => new SelectListItem(x, x)).ToList();


            var tastes = productObj.SubProducts.Where(x => x.Taste != null)
                .Select(x=>x.Taste.ToList().First().ToString().ToUpper() + string.Join("", x.Taste.ToList().Skip(1)).ToLower())
                .Distinct()
                .Select(x => new SelectListItem(x, x)).ToList();


            var sizes = productObj.SubProducts.Where(x => x.Size != null)
               .Select(x => x.Size.ToList().First().ToString().ToUpper() + string.Join("", x.Size.ToList().Skip(1)).ToLower())
               .Distinct()
               .Select(x => new SelectListItem(x, x)).ToList();

            var colors = productObj.SubProducts.Where(x => x.Color != null)
               .Select(x => x.Color.ToList().First().ToString().ToUpper() + string.Join("", x.Color.ToList().Skip(1)).ToLower())
               .Distinct()
               .Select(x => new SelectListItem(x, x)).ToList();



            ViewBag.PackageCount = packages.Count();
            packages.Add(new SelectListItem("?", ""));
            ViewBag.PackageList = packages;

            ViewBag.TasteCount = tastes.Count();
            tastes.Add(new SelectListItem("?", ""));
            ViewBag.TasteList = tastes;

            ViewBag.SizeCount = sizes.Count();
            sizes.Add(new SelectListItem("?", ""));
            ViewBag.SizeList = sizes;
            
            ViewBag.ColorCount = colors.Count();
            colors.Add(new SelectListItem("?", ""));
            ViewBag.ColorList = colors;


            return productObj;
        }
        #endregion


        





    }
}
