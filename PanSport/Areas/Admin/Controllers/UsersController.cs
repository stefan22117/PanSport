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

namespace PanSport.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly PanSportDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public UsersController(PanSportDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager
            )
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            List<User> users = await userManager.Users
                
                .Where(x=>x.UserName != User.Identity.Name)
                .Select(x => new User(x, userManager)).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> AddToRole(string id, string role)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, role);

            TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Korisniku " + user.UserName + " je dodata uloga: " + role, "success"
                        ));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromRole(string id, string role)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            
            await userManager.RemoveFromRoleAsync(user, role);

            List<string> roles = new List<string>(await userManager.GetRolesAsync(user));

            if (roles.Count == 0)
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Korisnik "+ user.UserName + " nije u ni jednoj ulozi", "danger"
                        ));
            }
            else
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Korisnik " + user.UserName + " ima uloge: " + String.Join(", ", roles), "warning"
                        ));

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveUser (string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);

            if(user != null)
            {
                await userManager.DeleteAsync(user);
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Korisnik " + user.UserName + " je obrisan", "success"
                        ));
            }
            else
            {
                TempData.Put<UserMessage>("UserMessage", new UserMessage(
                        2, "Izabrali ste nepostojeceg korisnika", "danger"
                        ));
            }
            return RedirectToAction("Index");
        }
    }
}
