using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class CashRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Working")]
        public DateTime StartWorking { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Working")]
        public DateTime EndWorking { get; set; }
        [Required]
        public string Employee { get; set; }

        public virtual ICollection<TicketSold> TicketSolds { get; set; }
    }
}