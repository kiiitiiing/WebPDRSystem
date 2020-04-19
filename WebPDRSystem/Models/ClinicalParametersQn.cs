using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("ClinicalParametersQN")]
    public partial class ClinicalParametersQn
    {
        public ClinicalParametersQn()
        {
            Medications = new HashSet<Medications>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime DateChecked { get; set; }
        [Required]
        [Column("BP")]
        [StringLength(255)]
        public string Bp { get; set; }
        [Required]
        [Column("HR")]
        [StringLength(255)]
        public string Hr { get; set; }
        [Required]
        [Column("RR")]
        [StringLength(255)]
        public string Rr { get; set; }
        [Required]
        [Column("O2Sat")]
        [StringLength(255)]
        public string O2sat { get; set; }
        public DateTime TimeFluidStarter { get; set; }
        [Required]
        [StringLength(255)]
        public string TimeFluidChanged { get; set; }
        [Required]
        [StringLength(255)]
        public string UrineOutput { get; set; }
        [Required]
        [Column("SignatureOfQN")]
        [StringLength(255)]
        public string SignatureOfQn { get; set; }
        [Required]
        [StringLength(255)]
        public string Meds { get; set; }
        [StringLength(255)]
        public string Enumerate { get; set; }
        [Column("DailyMonitoringFormQN_ModelId")]
        public int? DailyMonitoringFormQnModelId { get; set; }
        [Required]
        [StringLength(255)]
        public string OtherDetails { get; set; }

        [ForeignKey(nameof(DailyMonitoringFormQnModelId))]
        [InverseProperty(nameof(Qnform.ClinicalParametersQn))]
        public virtual Qnform DailyMonitoringFormQnModel { get; set; }
        [InverseProperty("ClinicalParamQnNavigation")]
        public virtual ICollection<Medications> Medications { get; set; }
    }
}
