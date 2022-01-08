using PanSport.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PanSport.Infrastructure;

namespace KorpaZaKupovinu.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly PanSportDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(
            PanSportDbContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
            this.roleManager = roleManager;
            this.context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Register");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email = user.Email
                };
                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    if(userManager.Users.Count() == 1)
                    {
                        //var u = await userManager.FindByNameAsync(appUser.UserName);
                        //await userManager.AddToRoleAsync(u, "admin");

                        await userManager.AddToRoleAsync(appUser, "admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(appUser, "user");
                    }

                    Login login = new Login
                    {
                        Email = user.Email,
                        Password = user.Password
                    };

                    //return RedirectToAction("Login", new { login = login });

                    await signInManager
                        .PasswordSignInAsync(appUser, login.Password, false, false);
                    return Redirect("/");

                }
                else
                {
                    foreach (IdentityError identityError in result.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            Login login = new Login
            {
                ReturnUrl = ReturnUrl
            };//mislim da je bolje resenje u temp-data

            return View(login);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        string url = login.ReturnUrl ?? "/";
                        return Redirect(url);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Pogresni kredencijali!");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Korisni ne postoji!");
                }

            }

            return View();
        }


        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Put<List<CartItem>>("cartItems", null);//brisanje is sesije
            return Redirect("/");
        }

        public async Task<IActionResult> Edit()
        {
            AppUser appUser = await userManager.FindByNameAsync(this.User.Identity.Name);

            UserEdit userEdit = new UserEdit(appUser);
            return View(userEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEdit userEdit)
        {
            AppUser appUser = await userManager.FindByNameAsync(this.User.Identity.Name);

            if (ModelState.IsValid)
            {
                appUser.Email = userEdit.Email;
                if (userEdit.Password != null)
                {

                    appUser.PasswordHash = passwordHasher
                        .HashPassword(appUser, userEdit.Password);
                }

                if (userEdit.Email != appUser.Email)
                {
                    appUser.Email = userEdit.Email;
                    appUser.EmailConfirmed = false;
                }
                IdentityResult result = await userManager.UpdateAsync(appUser);

                if (result.Succeeded)
                {
                    TempData["Success"] = "Uspesno ste izmenili svoje podatke";
                    return Redirect("/");

                }
            }

            TempData["Failure"] = "Podaci nisu validni";
            return View(userEdit);
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return RedirectToAction("Login", new { ReturnUrl });
        }

        [AllowAnonymous]
        public async Task<IActionResult> EditOrderInfo()
        {
            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
            OrderInfo orderInfo = context.OrderInfos.FirstOrDefault(x => x.AppUserId == appUser.Id);
            return View("EditOrderInfo", orderInfo);
            return RedirectToAction("EditOrderInfo", orderInfo);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> EditOrderInfo(OrderInfo orderInfo)
        {
            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
            //OrderInfo orderInfo = context.OrderInfos.FirstOrDefault(x => x.AppUserId == appUser.Id);
            return View("EditOrderInfo", orderInfo);
            return RedirectToAction("EditOrderInfo", orderInfo);
        }

    }
}
