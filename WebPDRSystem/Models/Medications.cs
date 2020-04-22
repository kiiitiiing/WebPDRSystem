using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Medications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string MedName { get; set; }
        public bool MedTaken { get; set; }
        public int PatientId { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Medications")]
        public virtual Patient Patient { get; set; }
    }
}
