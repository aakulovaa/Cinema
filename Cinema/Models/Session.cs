using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Start Date Time")]
        [Required]
        public DateTime StartDateTime { get; set; }
        [Display(Name = "Movie Id")]
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [Display(Name = "Hall Id")]
        [ForeignKey("Hall")]
        public int HallId { get; set; }

        public virtual ICollection<TicketSold> TicketSolds { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Hall Hall { get; set; }
        public ICollection<People> Peoples { get; set; }

    }
}