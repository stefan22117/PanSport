using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Naslov proizvoda je obavezan")]
        [MinLength(3, ErrorMessage = "Minimalna dužina naslova proizvoda je 3")]
        [Display(Name = "Naslov")]
        public string Title { get; set; }
        public string ShowImage { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        [Range(1, int.MaxValue , ErrorMessage = "Izaberite kategoriju")]
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; } //da li ovo string ili posebna tabela koja ima i link ka proizvodjacu??


        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual List<SubProduct> SubProducts { get; set; }
    }
}
