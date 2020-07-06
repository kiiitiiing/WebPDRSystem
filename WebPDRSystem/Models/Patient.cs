using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Medications = new HashSet<Medications>();
            Pdr = new HashSet<Pdr>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        [StringLength(255)]
        public string ContactNumber { get; set; }
        public int? Barangay { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(255)]
        public string Occupation { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        [StringLength(50)]
        public string Religion { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(Barangay))]
        [InverseProperty("Patient")]
        public virtual Barangay BarangayNavigation { get; set; }
        [ForeignKey(nameof(Muncity))]
        [InverseProperty("Patient")]
        public virtual Muncity MuncityNavigation { get; set; }
        [ForeignKey(nameof(Province))]
        [InverseProperty("Patient")]
        public virtual Province ProvinceNavigation { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Medications> Medications { get; set; }
        [InverseProperty("PatientNavigation")]
        public virtual ICollection<Pdr> Pdr { get; set; }
    }
}
