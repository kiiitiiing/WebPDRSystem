using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Referral
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfReferral { get; set; }
        public string ReferringQuarantineFacility { get; set; }
        public string ReferredTo { get; set; }
        [Column("PDRId")]
        public int Pdrid { get; set; }
        public string PertinentFindings { get; set; }
        public string Diagnosis { get; set; }
        public string Reason { get; set; }
        public string ReferredBy { get; set; }

        [ForeignKey(nameof(Pdrid))]
        [InverseProperty("Referral")]
        public virtual Pdr Pdr { get; set; }
    }
}
