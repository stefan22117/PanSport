using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class SubProduct
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Package { get; set; }
        public string Taste { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public float Price { get; set; } = 0;
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }




    }
}
