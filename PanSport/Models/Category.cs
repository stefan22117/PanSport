using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Naslov kategorije je obavezan")]
        [MinLength(5, ErrorMessage = "Minimalna dužina naslova kategorije je 5")]
        [Display(Name = "Naslov")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Opis kategorije je obavezan")]
        [MinLength(10, ErrorMessage = "Minimalna dužina opisa kategorije je 10")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public string Slug { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
