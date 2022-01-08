using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Infrastructure
{
    public class PanSportDbContext : IdentityDbContext<AppUser>
    {
        public PanSportDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        public DbSet<SubProduct> SubProducts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        

        //dodati sve DbSet-ove<T>
    }
}
