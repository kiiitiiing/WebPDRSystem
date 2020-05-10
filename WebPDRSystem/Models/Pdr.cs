using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("PDR")]
    public partial class Pdr
    {
        public Pdr()
        {
            Discharge = new HashSet<Discharge>();
            DoctorOrders = new HashSet<DoctorOrders>();
            LabResult = new HashSet<LabResult>();
            Qdform = new HashSet<Qdform>();
            Qnform = new HashSet<Qnform>();
            Referral = new HashSet<Referral>();
            Unusualities = new HashSet<Unusualities>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime? DateOfAdmission { get; set; }
        public string ReferringFacility { get; set; }
        public string QuarantineFacility { get; set; }
        [StringLength(100)]
        public string CaseNumber { get; set; }
        [StringLength(50)]
        public string BedNumber { get; set; }
        public int? Patient { get; set; }
        [Column("PDRCode")]
        [StringLength(255)]
        public string Pdrcode { get; set; }
        public int? Guardian { get; set; }
        public DateTime? DateTesting { get; set; }
        public string Results { get; set; }
        public string History { get; set; }
        public string TravelHistory { get; set; }
        public DateTime? DateOnsetSymptoms { get; set; }
        public string PreExistingConditions { get; set; }
        public string Maintenance { get; set; }
        public bool? MayGoHome { get; set; }
        public string FoodRestrictionsAllergy { get; set; }
        public string AdmissionTemperature { get; set; }
        public int? InterviewedBy { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        public int? SymptomsContactsId { get; set; }
        public bool Attended { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(Guardian))]
        [InverseProperty("Pdr")]
        public virtual Guardian GuardianNavigation { get; set; }
        [ForeignKey(nameof(InterviewedBy))]
        [InverseProperty(nameof(Pdrusers.Pdr))]
        public virtual Pdrusers InterviewedByNavigation { get; set; }
        [ForeignKey(nameof(Patient))]
        [InverseProperty("Pdr")]
        public virtual Patient PatientNavigation { get; set; }
        [ForeignKey(nameof(SymptomsContactsId))]
        [InverseProperty("Pdr")]
        public virtual SymptomsContacts SymptomsContacts { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<Discharge> Discharge { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<DoctorOrders> DoctorOrders { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<LabResult> LabResult { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<Qdform> Qdform { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<Qnform> Qnform { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<Referral> Referral { get; set; }
        [InverseProperty("Pdr")]
        public virtual ICollection<Unusualities> Unusualities { get; set; }
    }
}
