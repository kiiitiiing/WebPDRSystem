using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("QDForm")]
    public partial class Qdform
    {
        /*public Qdform()
        {
            ClinicalParametersQd = new HashSet<ClinicalParametersQd>();
        }*/

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string PatientCode { get; set; }
        public int HealthCareBuddy { get; set; }
        [Column("SignatureOfQD")]
        public string SignatureOfQd { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(HealthCareBuddy))]
        [InverseProperty(nameof(Pdrusers.Qdform))]
        public virtual Pdrusers HealthCareBuddyNavigation { get; set; }
        [InverseProperty("DailyMonitoringFormQdModel")]
        public virtual List<ClinicalParametersQd> ClinicalParametersQd { get; set; }
    }
}
