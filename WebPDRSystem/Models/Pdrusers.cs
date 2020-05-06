using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("PDRUsers")]
    public partial class Pdrusers
    {
        public Pdrusers()
        {
            CensusNodaNavigation = new HashSet<Census>();
            CensusNodbNavigation = new HashSet<Census>();
            CensusOdgNavigation = new HashSet<Census>();
            CensusOdrNavigation = new HashSet<Census>();
            CensusQdNavigation = new HashSet<Census>();
            DischargeDischargedByNavigation = new HashSet<Discharge>();
            DischargeHealthCareBuddyNavigation = new HashSet<Discharge>();
            DoctorOrders = new HashSet<DoctorOrders>();
            LabResult = new HashSet<LabResult>();
            Medications = new HashSet<Medications>();
            Pdr = new HashSet<Pdr>();
            QdformHealthCareBuddyNavigation = new HashSet<Qdform>();
            QdformSignatureOfQdNavigation = new HashSet<Qdform>();
            Qnform = new HashSet<Qnform>();
            Referral = new HashSet<Referral>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [StringLength(255)]
        public string Firstname { get; set; }
        [StringLength(255)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(255)]
        public string Lastname { get; set; }
        [StringLength(100)]
        public string Facility { get; set; }
        [StringLength(255)]
        public string Picture { get; set; }
        public int? Team { get; set; }
        [Required]
        [StringLength(255)]
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(255)]
        public string Schedule { get; set; }
        [StringLength(255)]
        public string Designation { get; set; }

        [ForeignKey(nameof(Team))]
        [InverseProperty(nameof(UserTeams.Pdrusers))]
        public virtual UserTeams TeamNavigation { get; set; }
        [InverseProperty(nameof(Census.NodaNavigation))]
        public virtual ICollection<Census> CensusNodaNavigation { get; set; }
        [InverseProperty(nameof(Census.NodbNavigation))]
        public virtual ICollection<Census> CensusNodbNavigation { get; set; }
        [InverseProperty(nameof(Census.OdgNavigation))]
        public virtual ICollection<Census> CensusOdgNavigation { get; set; }
        [InverseProperty(nameof(Census.OdrNavigation))]
        public virtual ICollection<Census> CensusOdrNavigation { get; set; }
        [InverseProperty(nameof(Census.QdNavigation))]
        public virtual ICollection<Census> CensusQdNavigation { get; set; }
        [InverseProperty(nameof(Discharge.DischargedByNavigation))]
        public virtual ICollection<Discharge> DischargeDischargedByNavigation { get; set; }
        [InverseProperty(nameof(Discharge.HealthCareBuddyNavigation))]
        public virtual ICollection<Discharge> DischargeHealthCareBuddyNavigation { get; set; }
        [InverseProperty("SignatureNavigation")]
        public virtual ICollection<DoctorOrders> DoctorOrders { get; set; }
        [InverseProperty("AttendingPhysicianNavigation")]
        public virtual ICollection<LabResult> LabResult { get; set; }
        [InverseProperty("SignatureNurseNavigation")]
        public virtual ICollection<Medications> Medications { get; set; }
        [InverseProperty("InterviewedByNavigation")]
        public virtual ICollection<Pdr> Pdr { get; set; }
        [InverseProperty(nameof(Qdform.HealthCareBuddyNavigation))]
        public virtual ICollection<Qdform> QdformHealthCareBuddyNavigation { get; set; }
        [InverseProperty(nameof(Qdform.SignatureOfQdNavigation))]
        public virtual ICollection<Qdform> QdformSignatureOfQdNavigation { get; set; }
        [InverseProperty("SignatureOfQnNavigation")]
        public virtual ICollection<Qnform> Qnform { get; set; }
        [InverseProperty("ReferredByNavigation")]
        public virtual ICollection<Referral> Referral { get; set; }
    }
}
