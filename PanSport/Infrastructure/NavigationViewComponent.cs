using Microsoft.AspNetCore.Mvc;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Infrastructure
{
    public class NavigationObject
    {
        public NavigationObject(string title, string controller, string action = "Index", List<string> catPro = null)
        {
            this.Title = title;
            this.Controller = controller;
            this.Action = action;

            if (catPro == null)
            {
                catPro = new List<string>();
            }

            this.Category = catPro.Count > 0 ? catPro[0] : null;
            this.Product = catPro.Count > 1 ? catPro[1] : null;


        }
        List<string> catPro = new List<string>();
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Category { get; set; }
        public string Product { get; set; }


    }
    public class NavigationViewComponent : ViewComponent
    {

        public List<NavigationObject> navigationObjects;
        public PanSportDbContext context { get; set; }

        public NavigationViewComponent(PanSportDbContext context)
        {
            this.context = context;
            navigationObjects = new List<NavigationObject>() { };
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string controller = ViewContext.RouteData.Values["controller"].ToString();
            string action = ViewContext.RouteData.Values["action"].ToString();


            string product = ViewContext.RouteData.Values["product"]?.ToString();
            string category = ViewContext.RouteData.Values["category"]?.ToString();


            navigationObjects.Add(new NavigationObject("Početna", "Home", "Index"));
            if (controller == "Home" && action == "Index")
            {
                return View(navigationObjects);
            }

            if (controller == "Cart" && action == "Index")
            {
                navigationObjects.Add(new NavigationObject("Korpa", "Cart", "Index"));
                return View(navigationObjects);
            }

            if (controller == "Notifications" && action == "Index")
            {
                navigationObjects.Add(new NavigationObject("Obaveštenja", "Notifications", "Index"));
                return View(navigationObjects);
            }

            //ovde dodavati nove putanje




            //ovde dodavati nove putanje


            navigationObjects.Add(new NavigationObject("Kategorije", "Categories", "Index"));
            if (controller == "Categories" && action == "Index")
            {
                return View(navigationObjects);
            }


            if (controller == "Products" && action == "GetProducts")
            {
                if (category != null)
                {
                    Category categoryObj = context.Categories.FirstOrDefault(x => x.Slug == category);
                    navigationObjects.Add(new NavigationObject(categoryObj?.Title ?? category, "Products", "GetProducts",
                        new List<string>() { category }));

                }

                if (product != null)
                {
                    Product productObj = context.Products.FirstOrDefault(x => x.Slug == product);
                    navigationObjects.Add(new NavigationObject(productObj?.Title ?? product, "Products", "GetProducts",
                        new List<string>() { category, product }));

                }

                return View(navigationObjects);
            }





            return View(navigationObjects);



        }
    }
}
