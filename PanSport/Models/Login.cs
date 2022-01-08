using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PanSport.Models
{
    public class Login
    {
        [Required, EmailAddress, Key]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(2, ErrorMessage = "Najmanja duzina je 2")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
