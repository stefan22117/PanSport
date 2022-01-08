using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class Manufacturer
    {
        [Key]
        public int  Id { get; set; }
        public string  Name { get; set; }
        public string  Url { get; set; }
        public string  Logo { get; set; }
        [NotMapped]
        public IFormFile  LogoFile { get; set; }

        public virtual List<Product> Products { get; set; }


    }
}
