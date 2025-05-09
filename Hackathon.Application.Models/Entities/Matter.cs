using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Models.Entities
{
    public class Matter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatterId { get; set; }
        public string? AccountNumber { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Participant { get; set; }       
        public string? ClientEmail { get; set; }
        public DateTime Createddate { get; set; } = DateTime.UtcNow;
        public DateTime Modifieddate { get; set; } = DateTime.UtcNow;
        public bool Isdeleted { get; set; }
    }    
}
