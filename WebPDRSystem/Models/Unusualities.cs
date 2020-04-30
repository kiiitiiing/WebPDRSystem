using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Unusualities
    {
        [Key]
        public int Id { get; set; }
        public int PdrId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Issue { get; set; }
        [Required]
        [StringLength(255)]
        public string Status { get; set; }
        [StringLength(255)]
        public string Remarks { get; set; }
        public bool Attended { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(PdrId))]
        [InverseProperty("Unusualities")]
        public virtual Pdr Pdr { get; set; }
    }
}
