using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Movie Name")] 
        public string MovieName { get; set; }
        [Display(Name = "Year Release")]
        public int YearRelease { get; set; }
        public string Director { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}