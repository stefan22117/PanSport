using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly PanSportDbContext context;
        private readonly UserManager<AppUser> userManager;
        public NotificationsController(PanSportDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }


        [NonAction]
        public async Task<List<Notification>> GetNotificationsByUser(AppUser user)
        {
            List<Notification> notifications = new List<Notification>();
            if (user != null)
            {
                notifications = await context.Notifications
                   .Where(x => x.AppUserId == user.Id)
                   .OrderByDescending(x => x.DateTime)
                   .ToListAsync();
            }
            return notifications;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await userManager.FindByNameAsync(User?.Identity?.Name ?? "");
            List<Notification> notifications = await GetNotificationsByUser(user);

            return View(notifications);
        }

        public async Task<IActionResult> ReadNotification(int id)
        {

            Notification notification = context.Notifications.Find(id);
            if (notification != null)
            {
                notification.Read = true;
                await context.SaveChangesAsync();
            }

            //
            AppUser user = await userManager.FindByNameAsync(User?.Identity?.Name ?? "");
            List<Notification> notificationsByUser = await GetNotificationsByUser(user);

            List<Notification> notifications = notificationsByUser
                .AsQueryable()
                .Where(x => x.Read == false).ToList();





            Notification nextNotification = null;
            if (notifications.Count() >= 3)
            {
                nextNotification = notifications.Skip(2).FirstOrDefault();
            }

            return Ok(new { nextNotification , notificationsCount = notifications.Count() });
        }



        public IActionResult SetAllToUnread()
        {
            foreach (Notification notification in context.Notifications)
            {
                notification.Read = false;
            }
            context.SaveChanges();
            return Redirect("/notifications");
        }
        
        
        public async Task<IActionResult> MarkAllAsReadNot()
        {
            AppUser user = await userManager.FindByNameAsync(User?.Identity?.Name ?? "");

            foreach (Notification notification in context.Notifications.Where(x=>x.AppUserId == user.Id))
            {
                notification.Read = true;
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveAllNot()
        {
            AppUser user = await userManager.FindByNameAsync(User?.Identity?.Name ?? "");

            context.Notifications.RemoveRange(context.Notifications.Where(x=>x.AppUserId == user.Id));
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveNotification(int id)
        {

            Notification notification = context.Notifications.Find(id);
            if(notification != null)
            {
            context.Notifications.Remove(notification);
            }
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
