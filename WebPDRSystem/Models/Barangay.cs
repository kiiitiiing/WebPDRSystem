using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Barangay
    {
        public Barangay()
        {
            Patient = new HashSet<Patient>();
        }

        [Key]
        public int Id { get; set; }
        public int? ProvinceId { get; set; }
        public int MuncityId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public int OldTarget { get; set; }
        public int Target { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("BarangayNavigation")]
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
