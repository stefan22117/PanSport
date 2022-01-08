using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class OrderItem
    {
        public OrderItem(CartItem cartItem)
        {
            this.Amount = cartItem.Amount;
            this.SubProductId = cartItem.SubProductId;

        }
        public OrderItem()
        {

        }
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public int SubProductId { get; set; }

        [ForeignKey("SubProductId")]
        public virtual SubProduct SubProduct { get; set; }
    }
}
