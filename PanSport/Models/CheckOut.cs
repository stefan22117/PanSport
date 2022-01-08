using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    [NotMapped]
    public class CheckOut
    {
        public Login Login { get; set; }
        public OrderInfo OrderInfo { get; set; }
        public AppUser User { get; set; }
        public double CartTotal { get; set; }

    }
}
