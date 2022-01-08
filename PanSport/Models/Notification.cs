using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Models
{
    public class Notification
    {
        public Notification(string title)
        {
            this.Title = title;
            this.DateTime = DateTime.Now;
            this.Read = false;
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public bool Read { get; set; } 

        public string AppUserId { get; set; }



        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }

        //public string Description { get; set; }

    }
}
