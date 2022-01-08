using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class OrderInfo
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string SurName { get; set; }
        public string  Street { get; set; }
        public string  StreetNumber { get; set; } // 25a ==> string
        public string  Phone { get; set; } 
        public string  Comment { get; set; } 

        public string AppUserId { get; set; } 
        public int OrderId { get; set; } 


        //public virtual AppUser AppUser { get; set; } 



    }
}
