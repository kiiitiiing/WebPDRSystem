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
        public int? Day { get; set; }
        public int PatientId { get; set; }
        [Required]
        [StringLength(255)]
        public string MedName { get; set; }
        [StringLength(50)]
        public string Comments { get; set; }
        public int SignatureNurse { get; set; }
        public bool Discontinued { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Medications")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(SignatureNurse))]
        [InverseProperty(nameof(Pdrusers.Medications))]
        public virtual Pdrusers SignatureNurseNavigation { get; set; }
    }
}
