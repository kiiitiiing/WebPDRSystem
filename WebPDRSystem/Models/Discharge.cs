using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Discharge
    {
        [Key]
        public int Id { get; set; }
        [Column("PDRId")]
        public int Pdrid { get; set; }
        public DateTime DateDischarged { get; set; }
        public int HealthCareBuddy { get; set; }
        [StringLength(255)]
        public string DischargedBy { get; set; }
        [StringLength(255)]
        public string DischargedApprovedBy { get; set; }
        [StringLength(255)]
        public string QuarantineDirectorOrOfficer { get; set; }
        [StringLength(255)]
        public string GuardOnDuty { get; set; }

        [ForeignKey(nameof(HealthCareBuddy))]
        [InverseProperty(nameof(Pdrusers.Discharge))]
        public virtual Pdrusers HealthCareBuddyNavigation { get; set; }
        [ForeignKey(nameof(Pdrid))]
        [InverseProperty("Discharge")]
        public virtual Pdr Pdr { get; set; }
    }
}
