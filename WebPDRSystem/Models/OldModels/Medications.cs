using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models.OldModels
{
    public partial class Medications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string MedName { get; set; }
        public DateTime MedTaken { get; set; }
        public int ClinicalParamQn { get; set; }

        [ForeignKey(nameof(ClinicalParamQn))]
        [InverseProperty(nameof(ClinicalParametersQn.Medications))]
        public virtual ClinicalParametersQn ClinicalParamQnNavigation { get; set; }
    }
}
