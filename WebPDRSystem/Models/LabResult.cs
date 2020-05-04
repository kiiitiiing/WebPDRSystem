using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class LabResult
    {
        [Key]
        public int Id { get; set; }
        public int PdrId { get; set; }
        public int AttendingPhysician { get; set; }
        [Required]
        public string ResultPic { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(AttendingPhysician))]
        [InverseProperty(nameof(Pdrusers.LabResult))]
        public virtual Pdrusers AttendingPhysicianNavigation { get; set; }
        [ForeignKey(nameof(PdrId))]
        [InverseProperty("LabResult")]
        public virtual Pdr Pdr { get; set; }
    }
}
