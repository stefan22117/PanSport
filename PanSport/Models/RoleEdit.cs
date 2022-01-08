using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class RoleEdit
    {
        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public RoleEdit(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            //nije neophodan ovaj kontroler za sad
        }


        public RoleEdit(IdentityRole role, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
            //user i role manager moraju biti ovde, jer su u protivnom null


            this.Role = role;
            this.RoleName = role.Name;
            IList<AppUser> _members = null;
            IList<AppUser> _nonMembers = null;
            Task.Run(async () =>
            {
                _members = await userManager.GetUsersInRoleAsync(role.Name);

                _nonMembers = userManager.Users.Where(x => !_members.Contains(x)).ToList();

            }).Wait();

            this.Members = _members;
            this.NonMembers = _nonMembers;

        }
        public RoleEdit()
        {
        }
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
        public string RoleName { get; set; }
        public string[] AddIds { get; set; } = new string[] { };
        public string[] DeleteIds { get; set; } = new string[] { };
    }
}
