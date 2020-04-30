using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPDRSystem.Models
{
    public partial class Muncity
    {
        public Muncity()
        {
            Guardian = new HashSet<Guardian>();
            Patient = new HashSet<Patient>();
        }

        [Key]
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("MuncityNavigation")]
        public virtual ICollection<Guardian> Guardian { get; set; }
        [InverseProperty("MuncityNavigation")]
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
