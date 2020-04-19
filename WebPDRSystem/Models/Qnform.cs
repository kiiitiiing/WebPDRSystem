using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("QNForm")]
    public partial class Qnform
    {
        public Qnform()
        {
            ClinicalParametersQn = new HashSet<ClinicalParametersQn>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string PatientCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [InverseProperty("DailyMonitoringFormQnModel")]
        public virtual ICollection<ClinicalParametersQn> ClinicalParametersQn { get; set; }
    }
}
