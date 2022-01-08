using PanSport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KorpaZaKupovinu.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public RolesController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager
            )
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([MinLength(2), Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    TempData["Success"] = "Uspesno ste dodali rolu";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Failure"] = "Doslo je do greske pri dodavanju role";
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    
                }
            }

            return View("Create", name);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(x=>x.Id == id);
            
            
            RoleEdit roleEdit = new RoleEdit(role, userManager, roleManager);
            return View(roleEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEdit roleEdit)
        {
            if(roleEdit.AddIds == null)
            {

            }


            foreach (var addId in roleEdit.AddIds)
            {
                AppUser user = await userManager.FindByIdAsync(addId);
                await userManager.AddToRoleAsync(user, roleEdit.RoleName);
            }
            
            foreach (var deleteId in roleEdit.DeleteIds)
            {
                AppUser user = await userManager.FindByIdAsync(deleteId);
                await userManager.RemoveFromRoleAsync(user, roleEdit.RoleName);
            }

            TempData["Success"] = "Uspesno ste izmenili korisnike u roli";
            return Redirect(Request.Headers["Referer"].ToString());
        }


        public async Task<IActionResult> AddToRole(string id, string roleId)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            var user = await userManager.FindByIdAsync(id);

            IdentityResult result = await userManager.AddToRoleAsync(user, role.Name);
            RoleEdit roleEdit = null;
            if (result.Succeeded)
            {
                role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
                roleEdit = new RoleEdit(role, userManager, roleManager);

                TempData["Success"] = "Uspesno ste dodali korisniku "
                    + user.UserName
                    + " rolu: " + role.Name;
            }
            else
            {

                TempData["Failure"] = "Doslo je do greske pri dodavanju role";

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

           

            return View("Edit", roleEdit);
        }

        public async Task<IActionResult> RemoveFromRole(string id, string roleId)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            var user = await userManager.FindByIdAsync(id);

            IdentityResult result = await userManager.RemoveFromRoleAsync(user, role.Name);
            RoleEdit roleEdit = null;
            if (result.Succeeded)
            {
                role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
                roleEdit = new RoleEdit(role, userManager, roleManager);

                TempData["Success"] = "Uspesno ste obrisali korisnika "
                    + user.UserName
                    + " iz role: " + role.Name;
            }
            else
            {

                TempData["Failure"] = "Doslo je do greske pri oduzimanju role";

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }



            return View("Edit", roleEdit);
        }
        //addToRole //removeFromRole
    }

}
