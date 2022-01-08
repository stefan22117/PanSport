using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Controllers
{
    public class CartController : Controller
    {
        PanSportDbContext context { get; set; }
        UserManager<AppUser> userManager { get; set; }
        public CartController(PanSportDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpPost]
        public IActionResult ChangeProductParameters(int ProductId, string Package, string Taste, string Size, string Color)
        {
            var findSubProduct = context.SubProducts.Where(x => x.ProductId == ProductId);


            if (Package != null)
            {
                findSubProduct = findSubProduct.Where(x => x.Package.ToLower() == Package.ToLower());
            }

            if (Taste != null)
            {
                findSubProduct = findSubProduct.Where(x => x.Taste.ToLower() == Taste.ToLower());
            }

            if (Size != null)
            {
                findSubProduct = findSubProduct.Where(x => x.Size.ToLower() == Size.ToLower());
            }

            if (Color != null)
            {
                findSubProduct = findSubProduct.Where(x => x.Color.ToLower() == Color.ToLower());
            }

            return Ok(findSubProduct.FirstOrDefault());
        }


        #region NonAction

        [NonAction]
        public async Task<List<Order>> GetOrdersByUser(AppUser user)
        {
            if (user != null)
            {
                List<Order> orders = await context.Orders
                .Where(x => x.AppUserId == user.Id)
                .OrderByDescending(x => x.Id)
                .ToListAsync();


                List<OrderItem> orderItems = await context.OrderItems
                    .Include(x => x.SubProduct.Product.Category)
                    .ToListAsync();

                foreach (var order in orders)
                {
                    order.OrderItems = orderItems.Where(x => x.OrderId == order.Id).ToList();
                }

                return orders;
            }
            else
            {
                return null;
            }
        }

        #endregion
        public IActionResult AddToCart(int SubProductId, int Amount = 1)
        {

            //ciscenje sesije
            //HttpContext.Session.SetString("cartItems", "");
            //ciscenje sesije


            List<CartItem> cartItems
                = HttpContext.Session.Get<List<CartItem>>("cartItems")
                ?? new List<CartItem>()
                ;
            SubProduct subProduct = context.SubProducts

                //.Include(x => x.Product)
                .FirstOrDefault(x => x.Id == SubProductId);



            if (subProduct == null)
            {
                return Ok(new { error = "Nije nadjen izabrani podproizvod" });
            }

            if (cartItems.Any(x => x.SubProductId == subProduct.Id))
            {
                cartItems.FirstOrDefault(x => x.SubProductId == subProduct.Id).Amount += Amount;
            }
            else
            {


                CartItem ci = new CartItem(context, subProduct)
                {
                    Id = cartItems.Count + 1,
                    Amount = Amount,
                    SubProductId = subProduct.Id,

                };
                cartItems.Add(ci);
            }
            try
            {
                HttpContext.Session.Put<List<CartItem>>("cartItems", cartItems);
                //ovde baca gresku

            }
            catch (Exception e)
            {
                return Ok(new { error = e.Message });
            }

            return Ok(
                new { cartItems = cartItems }//problem je zbog anonimnog objekta
                );

        }
        public IActionResult MinusCartItem(int subProductId)
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>("cartItems") ?? new List<CartItem>();


            if (cartItems.Any(x => x.SubProductId == subProductId))
            {

                cartItems = cartItems.Select(x =>
                {
                    if (x.Amount > 1 && x.SubProductId == subProductId)
                    {
                        x.Amount--;
                    }
                    return x;
                }).ToList();


                HttpContext.Session.Put("cartItems", cartItems);
                return Ok(new { cartItems });
            }


            return Ok(new { error = "Pogresan id je prosledjen" });
        }
        public IActionResult PlusCartItem(int subProductId)
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>("cartItems") ?? new List<CartItem>();


            if (cartItems.Any(x => x.SubProductId == subProductId))
            {

                cartItems = cartItems.Select(x =>
                {
                    if (x.SubProductId == subProductId)
                    {
                        x.Amount++;
                    }
                    return x;
                }).ToList();


                HttpContext.Session.Put("cartItems", cartItems);
                return Ok(new { cartItems });
            }


            return Ok(new { error = "Pogresan id je prosledjen" });
        }
        public IActionResult RemoveCartItem(int subProductId)
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>("cartItems") ?? new List<CartItem>();


            if (cartItems.Any(x => x.SubProductId == subProductId))
            {

                cartItems = cartItems.Where(x => x.SubProductId != subProductId).ToList();


                HttpContext.Session.Put("cartItems", cartItems);
                return Ok(new { cartItems });
            }


            return Ok(new { error = "Pogresan id je prosledjen" });
        }
        public IActionResult Index()
        {
            List<CartItem> cartItems
               = HttpContext.Session.Get<List<CartItem>>("cartItems")
               ?? new List<CartItem>()
               ;
            return View(cartItems);
        }


        public async Task<IActionResult> CheckOut()
        {


            double cartTotal = HttpContext.Session.Get<List<CartItem>>("cartItems").Sum(x => x.SubProduct.Price * x.Amount);
            AppUser user = null;
            OrderInfo orderInfo = new OrderInfo();

            if (User.Identity.Name != null)
            {
                user = await userManager.FindByNameAsync(User.Identity.Name);

                orderInfo = context.OrderInfos.FirstOrDefault(x => x.AppUserId == user.Id);

            }

            return View(
                new CheckOut
                {
                    CartTotal = cartTotal,
                    User = user,
                    Login = new Login()
                    {
                        ReturnUrl = Request.Path + Request.QueryString.ToString()
                    },
                    OrderInfo = orderInfo
                }
                );
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(OrderInfo orderInfo)
        {

            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>("cartItems") ?? new List<CartItem>();

            string word = "proizvode";
            if (cartItems.Count == 0)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Vasa korpa je prazna", "danger"
                        ));

                return RedirectToAction("Index", "Cart");
            }
            else if (cartItems.Count == 1)
            {
                word = "proizvod";
            }


            //brisi sesiju, dodaj u orders...
            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
            user = await userManager.FindByNameAsync(User.Identity.Name);
            }

            Order order = new Order(cartItems, context, user);

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            orderInfo.OrderId = order.Id;
            context.OrderInfos.Add(orderInfo);
            await context.SaveChangesAsync();

            List<OrderItem> orderItems = new List<OrderItem>();


            foreach (var cartItem in cartItems)
            {
                orderItems.Add(new OrderItem(cartItem)
                {
                    OrderId = order.Id
                }
                );
            }

            await context.OrderItems.AddRangeAsync(orderItems);

            await context.SaveChangesAsync();

            HttpContext.Session.Put<List<CartItem>>("cartItems", null);//brisanje is sesije


            //brisi sesiju, dodaj u orders...


            TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Uspesno ste porucili " + word, "success"
                        ));
            if (user != null)
            {
            return RedirectToAction("Orders", new { orderId = order.Id });
            }
            else
            {
                return RedirectToAction("Index");

            }

        }


        //[Authorize(Roles ="user,admin")]//privremeno
        public async Task<IActionResult> Orders(int? orderId)
        {
            ViewBag.Order = context.Orders.Find(orderId);

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name ?? "");

            List<Order> orders = await GetOrdersByUser(user);

            if (orders != null)
            {
                //ako je null, korisnik nije ulogovan, 
                //ako je count == 0 , korisnik jos nema porudzbina, ali se prikazuje view orders
                return View("Orders", orders);
            }
            else
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                       2, "Morate imati nalog da bi videli Vase porudzbine", "danger"
                       ));
                return RedirectToAction("Index", "Home");
            }
        }


        //[Authorize]
        public async Task<IActionResult> ChangeOrder(int id)
        {

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name ?? "");

            List<Order> orders = await GetOrdersByUser(user);

            Order order = null;
            if (orders != null)
            {
                order = orders.AsQueryable().FirstOrDefault(x => x.Id == id);
            }

            if (order == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Ne postoji izabrana porudzbina", "danger"
                        ));
                return Redirect(Request.Headers["Referer"].ToString());
            }

            return View(order);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CopyToCart(int id)
        {
            if (Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }

            AppUser user = await userManager.FindByNameAsync(User.Identity.Name ?? "");

            List<Order> orders = await GetOrdersByUser(user);

            Order order = null;
            if (orders != null)
            {
                order = orders.AsQueryable().FirstOrDefault(x => x.Id == id);
            }

            if (order == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Ne postoji izabrana porudzbina", "danger"
                        ));
                return Redirect(Request.Headers["Referer"].ToString());
            }
            //
            List<CartItem> cartItems = new List<CartItem>();

            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (orderItem.SubProduct != null)
                {
                    cartItems.Add(new CartItem(context, orderItem));
                }
            }

            HttpContext.Session.Put("cartItems", cartItems);
            return Ok(new { cartItems = cartItems });
        }


        public async Task<IActionResult> DeleteOrder(int id)
        {
            Order order = context.Orders.Find(id);

            if (order != null)
            {
                context.Orders.Remove(order);

                await context.SaveChangesAsync();

                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Porudzbina je uspesno izbrisana", "success"
                        ));
            }
            else
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Ne postoji izabrana porudzbina", "danger"
                        ));
            }


            return RedirectToAction("Orders");
        }

        public async Task<IActionResult> PauseContinueOrder(int id)
        {
            Order order = context.Orders.Find(id);

            if (order == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Ne postoji izabrana porudzbina", "danger"
                        ));
            }

            order.Paused = !order.Paused;
            await context.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult EmptyCart()
        {
            HttpContext.Session.Put<List<CartItem>>("cartItems", null);
            return Ok();

        }
    }
}
