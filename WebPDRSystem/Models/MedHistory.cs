using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class MedHistory
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Medname { get; set; }
        [StringLength(100)]
        public string Dosage { get; set; }
        [StringLength(100)]
        public string Route { get; set; }
        public int PdrId { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(PdrId))]
        [InverseProperty("MedHistory")]
        public virtual Pdr Pdr { get; set; }
    }
}
