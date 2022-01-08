using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Infrastructure
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly PanSportDbContext context;
        private readonly UserManager<AppUser> userManager;
        public NotificationViewComponent(PanSportDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = await userManager.FindByNameAsync(User?.Identity?.Name ?? "");
            List<Notification> notifications = new List<Notification>();
            if (user != null)
            {
                notifications = await context.Notifications
                   .Where(x => x.Read == false && x.AppUserId == user.Id)
                   .OrderByDescending(x => x.DateTime)
                .ToListAsync();
            }


            return View(notifications);
        }
    }
}
