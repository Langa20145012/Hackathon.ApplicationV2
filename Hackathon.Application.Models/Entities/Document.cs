using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Models.Entities
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [ForeignKey("Matter")]
        public int MatterId { get; set; }
        [ForeignKey("DocumentType")]
        public int DocumentTypeId { get; set; }
        public string? FileName { get; set; }
        //public string? ContentType { get; set; }
		public decimal? ADVPercentage { get; set; }		
		//public string? Additional { get; set; } = "None";
        [Required]
        public byte[]? FileContent { get; set; }
        [Required]
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Isdeleted { get; set; }
        public Matter? Matter { get; set; }
        public DocumentType? DocumentType { get; set; }
    }
}



