using PanSport.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class Order
    {
        PanSportDbContext context { get; set; }
        AppUser user { get; set; }

        public Order(List<CartItem> cartItems, PanSportDbContext context, AppUser user)
        {
            float sum = 0; 
            foreach (var cartItem in cartItems)
            {
                sum += context.SubProducts
                        .Where(x => x.Id == cartItem.SubProductId)
                        .Sum(x => x.Price * cartItem.Amount);
            }

            this.GrandTotal = sum;
            this.AppUserId = user?.Id;
            this.DateTime = DateTime.Now;

            this.Sent = false;
            this.Paused = false;

        }
        public Order()
        {

        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateTime { get; set; }
        public string AppUserId { get; set; }
        public double GrandTotal { get; set; }

        public bool Sent { get; set; }
        public bool Paused { get; set; }

        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

    }
}
