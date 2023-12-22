using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class TicketSold
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Session")]
        public int SessionId { get; set; }
        [ForeignKey("People")]
        public int PeopleId { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int PlaceNumber { get; set; }
        [ForeignKey("CashRegister")] 
        public int CashRegisterId { get; set; }

        public virtual Session Session { get; set; }
        public virtual CashRegister CashRegister { get; set; }

        public People People { get; set; }
    }
}