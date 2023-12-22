using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Models
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Screen Size")] 
        public int ScreenSize { get; set; }

        [Required]
        [Display(Name = "Hall Size")]
        public int HallSize { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}