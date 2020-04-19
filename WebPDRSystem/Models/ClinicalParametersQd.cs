using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("ClinicalParametersQD")]
    public partial class ClinicalParametersQd
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateChecked { get; set; }
        public bool NoSymptom { get; set; }
        public bool Fever { get; set; }
        public bool? Temperature { get; set; }
        public bool Cough { get; set; }
        public bool Colds { get; set; }
        public bool Breathing { get; set; }
        public bool BodyMuscleJointPain { get; set; }
        public bool Headache { get; set; }
        public bool ChestPain { get; set; }
        public bool Confusion { get; set; }
        public bool BluishLipsOrFingers { get; set; }
        public bool Maintenance { get; set; }
        public bool MedsTaken { get; set; }
        public bool MentalDistress { get; set; }
        [Column("DailyMonitoringFormQD_ModelId")]
        public int? DailyMonitoringFormQdModelId { get; set; }
        [StringLength(255)]
        public string OtherDetails { get; set; }

        [ForeignKey(nameof(DailyMonitoringFormQdModelId))]
        [InverseProperty(nameof(Qdform.ClinicalParametersQd))]
        public virtual Qdform DailyMonitoringFormQdModel { get; set; }
    }
}
