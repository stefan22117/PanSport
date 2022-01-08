using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class OrdersController : Controller
    {
        private readonly PanSportDbContext context;
        public OrdersController(PanSportDbContext context)
        {
            this.context = context;
        }

        #region NonAction
        [NonAction]
        public async Task<List<Order>> GetOrders()
        {
                List<Order> orders = await context.Orders
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
        #endregion

        public async  Task<IActionResult> Index()
        {
            List<Order> orders = await GetOrders();
            return View(orders);
        }

        public async Task<IActionResult> ChangeOrder(int id)
        {
            List<Order> orders = await GetOrders();

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

        public async Task<IActionResult> Send(int id)
        {

            Order order = context.Orders.Find(id);
            if (order == null)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Ne postoji izabrana porudzbina", "danger"
                        ));

                return Redirect(Request.Headers["Referer"].ToString());
            }
            order.Sent = true;
            await context.SaveChangesAsync();

            TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Uspesno ste promenili status porudzbine u: poslata", "success"
                        ));

            return RedirectToAction("ChangeOrder", new { id = id });

        }
    }
}
