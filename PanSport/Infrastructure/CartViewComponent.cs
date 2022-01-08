using Microsoft.AspNetCore.Mvc;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PanSport.Infrastructure
{
    public class CartViewComponent : ViewComponent
    {
        IEnumerable<CartItem> cartItems { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<CartItem> cartItems
                = HttpContext.Session.Get<IEnumerable<CartItem>>("cartItems")
                ?? new List<CartItem>()
                ;

            return View(cartItems);
        }
    }
}
