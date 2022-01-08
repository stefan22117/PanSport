using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    [NotMapped]
    public class User
    {
        public UserManager<AppUser> userManager { get; set; }

        [Key, Required, MinLength(2, ErrorMessage = "Najmanja duzina je 2"), Display(Name = "Username")]

        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(2, ErrorMessage = "Najmanja duzina je 2")]
        public string Password { get; set; }
        public string AppUserId { get; set; }


        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }

        public List<string> Roles { get; set; }


        public User()
        {
        }

        public bool IsInRole(string role)
        {
            //AppUser user = await userManager.FindByNameAsync(this.UserName);
            //if(user != null)
            //{
            //    return await userManager.IsInRoleAsync(user, role); 
            //}
            //return false;
            bool flag = false;
            Task.Run(async () => {
                AppUser user = await userManager.FindByNameAsync(this.UserName);
                if (user != null)
                {
                    flag = await userManager.IsInRoleAsync(user, role);
                }
            }).Wait();
           
            return flag;


        }
        public User(AppUser appUser, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            Task.Run(async () => {
                this.Roles = new List<string>(await userManager.GetRolesAsync(appUser));
            }).Wait();




            UserName = appUser.UserName;
            Email = appUser.Email;
            Password = appUser.PasswordHash;
            AppUser = appUser;
            AppUserId = appUser.Id;
        }
        public User(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;

            Task.Run( async () => {
                this.Roles = new List<string>(await userManager.GetRolesAsync(AppUser));

            }).Wait();

        }
    }
}
