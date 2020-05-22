using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    [Table("QDForm")]
    public partial class Qdform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Pdrcode { get; set; }
        [StringLength(255)]
        public string HealthCareBuddy { get; set; }
        public DateTime DateChecked { get; set; }
        public int Day { get; set; }
        public bool NoSymptoms { get; set; }
        public bool Fever { get; set; }
        [StringLength(50)]
        public string Temperature { get; set; }
        public bool Cough { get; set; }
        public bool Breathing { get; set; }
        public bool BodyPain { get; set; }
        public bool MuscleJointPain { get; set; }
        public bool Headache { get; set; }
        public bool ChestPain { get; set; }
        public bool Confusion { get; set; }
        public bool BluishLipsFingers { get; set; }
        public bool MedsTaken { get; set; }
        public bool MentalDistress { get; set; }
        [Column(TypeName = "text")]
        public string OtherDetails { get; set; }
        [Column("SignatureOfQD")]
        public int SignatureOfQd { get; set; }
        public int PdrId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(PdrId))]
        [InverseProperty("Qdform")]
        public virtual Pdr Pdr { get; set; }
        [ForeignKey(nameof(SignatureOfQd))]
        [InverseProperty(nameof(Pdrusers.Qdform))]
        public virtual Pdrusers SignatureOfQdNavigation { get; set; }
    }
}
