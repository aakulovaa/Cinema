using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        public TicketSold TicketSold { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public People()
        {
            this.Sessions = new HashSet<Session>();
        }
    }
}